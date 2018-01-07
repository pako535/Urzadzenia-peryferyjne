#ifdef _MSC_VER
#define _CRT_SECURE_NO_WARNINGS
#endif

#include "windows.h"
#include "mmsystem.h"
#include <dsound.h>
#include <iostream>
#pragma comment( lib, "Winmm.lib" )
#pragma comment( lib, "dsound.lib" )
#include <conio.h>
#include <string>
#include <atlbase.h>

using namespace std;

WAVEFORMATEX    WaveFormat;
HWAVEIN         WaveHandle;
HWAVEOUT        WaveOUTHandle;
WAVEHDR         WaveHeader;
WAVEHDR         WaveOutHeader;
char*           Buffer = NULL;
unsigned int    BufferSize = 0;

bool InfoOWawie(char nazwa[], int pom) {
	FILE *bin_file;
	bin_file = fopen(nazwa, "rb");
	if (!bin_file) {
		cout << "Blad wczytywania pliku " << endl;
		fclose(bin_file);
		return 1;
	}
	BYTE id[5];
	DWORD size;
	id[4] = 0;
	fread(id, sizeof(BYTE), 4, bin_file);

	if (!strcmp((char *)id, "RIFF")) {
		fread(&size, sizeof(DWORD), 1, bin_file);
		fseek(bin_file, 20, SEEK_SET);
		fread(&(WaveFormat.wFormatTag), 2, 1, bin_file);
		fread(&(WaveFormat.nChannels), 2, 1, bin_file);
		fread(&(WaveFormat.nSamplesPerSec), 4, 1, bin_file);
		fread(&(WaveFormat.nAvgBytesPerSec), 4, 1, bin_file);
		fread(&(WaveFormat.nBlockAlign), 2, 1, bin_file);
		fread(&(WaveFormat.wBitsPerSample), 2, 1, bin_file);
		fseek(bin_file, 40, SEEK_SET);
		fread(&(WaveHeader.dwBufferLength), 4, 1, bin_file);
		WaveHeader.lpData = (LPSTR)malloc(WaveHeader.dwBufferLength);
		WaveHeader.dwFlags = 0;
		WaveHeader.dwLoops = 0;
		WaveFormat.cbSize = 0;
		fread(WaveHeader.lpData, WaveHeader.dwBufferLength, 1, bin_file);
		waveOutPrepareHeader(WaveOUTHandle, &WaveHeader, sizeof(WAVEHDR));
		waveOutWrite(WaveOUTHandle, &WaveHeader, sizeof(WAVEHDR));
		if (pom != 1) {
			cout << "Rozmiar: " << size << " bajtow" << endl;
			cout << "Kanal: " << WaveFormat.nChannels << endl;
			cout << "Ilosc probek na sekunde: " << WaveFormat.nSamplesPerSec << endl;
			cout << "Bajtow na sekunde: " << WaveFormat.nAvgBytesPerSec << endl;
			cout << "Block align: " << WaveFormat.nBlockAlign << endl;
			cout << "Bitow na probke: " << WaveFormat.wBitsPerSample << endl;
		}
	}
	fclose(bin_file);
	return 0;
}

void grajOWawie() {
	int Res = waveOutOpen(&WaveOUTHandle, WAVE_MAPPER, &WaveFormat, 0, 0, WAVE_FORMAT_QUERY);
	if (Res == WAVERR_BADFORMAT)
		return;
	Res = waveOutOpen(&WaveOUTHandle, WAVE_MAPPER, &WaveFormat, 0, 0, CALLBACK_WINDOW);
	waveOutPrepareHeader(WaveOUTHandle, &WaveHeader, sizeof(WAVEHDR));
	waveOutWrite(WaveOUTHandle, &WaveHeader, sizeof(WAVEHDR));
}

bool pause = false;
void pauzujWWawie() {
	if (pause == true) {
		pause = false;
		waveOutRestart(WaveOUTHandle);
	}
	else {
		if (waveOutPause(WaveOUTHandle) != MMSYSERR_NOERROR)
			cout << "Blad pauzowania." << endl;
		else
			pause = true;
	}
}
void stojOWawie() {
	if (!pause)
		waveOutPause(WaveOUTHandle);
	else
		waveOutRestart(WaveOUTHandle);
	pause = !pause;
}

void nagrajWav(int sek) {

	unsigned short Channels = 1;
	unsigned long SamplesPerSecond = 44100;
	unsigned short BitsPerSample = 8;
	unsigned long RecordSeconds = sek;//dlugosc nagrania 

	WaveFormat.wFormatTag = WAVE_FORMAT_PCM;
	WaveFormat.nChannels = Channels;
	WaveFormat.nSamplesPerSec = SamplesPerSecond;
	WaveFormat.wBitsPerSample = BitsPerSample;
	WaveFormat.nAvgBytesPerSec = SamplesPerSecond * Channels;
	WaveFormat.nBlockAlign = (Channels*BitsPerSample) / 8;
	WaveFormat.cbSize = 0;

	int Res = waveInOpen(&WaveHandle, WAVE_MAPPER, &WaveFormat, 0, 0, WAVE_FORMAT_QUERY);
	if (Res == WAVERR_BADFORMAT) return;

	Res = waveInOpen(&WaveHandle, WAVE_MAPPER, &WaveFormat, 0, 0, CALLBACK_WINDOW);

	BufferSize = RecordSeconds * (BitsPerSample / 8) * SamplesPerSecond * Channels;
	Buffer = new char[BufferSize];

	WaveHeader.dwBufferLength = BufferSize;
	WaveHeader.dwFlags = 0;
	WaveHeader.lpData = Buffer;

	Res = waveInPrepareHeader(WaveHandle, &WaveHeader, sizeof(WAVEHDR));
	if (Res) {
		cout << "Blad przygotowania naglowka" << endl;
		if (Buffer)
			delete Buffer;
		return;
	}

	Res = waveInAddBuffer(WaveHandle, &WaveHeader, sizeof(WAVEHDR));

	Res = waveInStart(WaveHandle);
	if (Res != MMSYSERR_NOERROR) {
		cout << "Blad nagrywania dzwieku" << endl;
		if (Buffer)
			delete Buffer;
		return;
	}
}


void odtworzWav() {
	int Res = waveOutOpen(&WaveOUTHandle, WAVE_MAPPER, &WaveFormat, 0, 0, WAVE_FORMAT_QUERY);
	if (Res == WAVERR_BADFORMAT)
		return;

	//otwieramy urzadzenie
	Res = waveOutOpen(&WaveOUTHandle, WAVE_MAPPER, &WaveFormat, 0, 0, CALLBACK_WINDOW);
	waveOutPrepareHeader(WaveOUTHandle, &WaveHeader, sizeof(WAVEHDR));
	waveOutWrite(WaveOUTHandle, &WaveHeader, sizeof(WAVEHDR));
}

void grajPlaySound(LPCSTR nazwa) {
	USES_CONVERSION;
	PlaySound(A2W(nazwa), NULL, SND_FILENAME | SND_ASYNC);
}
void stopPlaySound() {
	USES_CONVERSION;
	PlaySound(NULL, NULL, SND_FILENAME | SND_ASYNC);
}

int menu() {
	system("cls");
	int wybor;
	cout << "Super program muzyczny Mikoaja i Jarka!!\n\n";
	cout << "\t1 - PlaySound() - gramy\n";
	cout << "\t2 - Stop, Hammer time dla tego u gory\n";
	cout << "\t3 - Info o wavie\n";
	cout << "\t4 - WaveOutOpen - muzyczka\n";
	cout << "\t5 - Pauza/Graj WaveOut\n";
	cout << "\t6 - Stop WaveOut\n";
	cout << "\t7 - WindowsMediaPlajer\n";
	cout << "\t8 - Nagrywaj dzwiek\n";
	cout << "\t9 - Odtworz nagranie";


	cout << "\nwybor: ";
	cin >> wybor;
	return wybor;
}

int main() {
	char filename[100];
	int wybor = menu();
	while (true) {
		switch (wybor) {
		case 1: {
			cout << "Jaki pliczek?\n>";
			cin >> filename;
			grajPlaySound(filename);
			break;
		}
		case 2: {
			stopPlaySound();
			break;
		}
		case 3: {
			cout << "Jaki pliczek?\n>";
			cin >> filename;
			InfoOWawie(filename, 0);
			system("pause");
			break;
		}
		case 4: {
			cout << "Jaki pliczek?\n>";
			cin >> filename;
			InfoOWawie(filename, 1);
			grajOWawie();
			break;
		}
		case 5: {
			pauzujWWawie();
			break;
		}
		case 6: {
			stojOWawie();
			break;
		}
		case 7: {
			string komenda;
			komenda = "wmplayer \"C:\\Users\\lab\\Desktop\\dzwiek\\dzwiek\\";
			cout << "Jaki pliczek?\n>";
			cin >> filename;
			komenda = komenda + filename + "\"";

			char *cstr = new char[komenda.length() + 1];
			strcpy(cstr, komenda.c_str());

			system(cstr);
			system("pause");
			break;
		}
		case 8: {
			int sek;
			cout << "Ile sekund?\n>";
			cin >> sek;
			nagrajWav(sek);
			break;
		}
		case 9: {
			grajOWawie();
			break;
		}
		default:
			wybor = menu();
			break;

		}
		//wybor = 9999999;
		wybor = menu();
	}
	system("pause");
	return 0;
}