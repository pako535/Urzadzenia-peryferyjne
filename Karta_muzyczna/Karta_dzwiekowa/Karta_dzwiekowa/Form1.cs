using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Karta_dzwiekowa
{
    public partial class Form1 : Form
    {
        private string filePath = "";
        // private SoundPlayer player;
        private bool wasPlayed, wasRecored = false;
        private string fileRecordPath = "";


        NAudio.Wave.WaveIn sourceStream = null;
        NAudio.Wave.DirectSoundOut waveOut = null;
        NAudio.Wave.WaveFileWriter waveWriter = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFile_Click(object sender, EventArgs e)   // Wybranie pliku do odtworzenia
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Audio files (.wav)|*.wav";     // Akceptowalne formaty plików to WAV
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                labelFilePath.Text = $"Wybrany plik: {filePath}";
                FillListBox();
            }
        }

        private void FillListBox()  // funkcja zczytująca nagłowek pliku WAV
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                BinaryReader reader = new BinaryReader(fileStream);

                byte[] wave = reader.ReadBytes(24);

                fileStream.Position = 0;

                int chunkID = reader.ReadInt32();
                int fileSize = reader.ReadInt32();
               // int riffType = reader.ReadInt32();

                var fileFormat = Encoding.Default.GetString(wave);
                string format = fileFormat.Substring(8, 4);
                string subchunk1ID = fileFormat.Substring(12, 8);
                int subchunk1Size = reader.ReadInt32(); 


                reader.Close();

                string chunkIDStr = $"Chunk ID: {chunkID}";
                string fileSizeStr = $"Chunk size: {fileSize}";
               
                string fileFormatStr = $"Format: {format}";
                string subchunk1IDStr = $"Subchunk ID: {subchunk1ID}";
                string subchunk1SizeStr = $"Subchunk Size ID: {subchunk1Size}";
              


                listBoxFileInfo.Items.Clear();
                listBoxFileInfo.Items.AddRange(new string[]
                {
                    "\tNagłówek pliku:",chunkIDStr, fileSizeStr, fileFormatStr,"\tOpis struktury audio:",subchunk1IDStr
                   ,subchunk1SizeStr
                });
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {


            if (filePath == String.Empty)
                MessageBox.Show("Wybierz plik!");
            else
            {
                SoundPlayer simpleSound = new SoundPlayer(@filePath);
                if (!wasPlayed)
                {
                    buttonPlay.Text = "STOP";
                    wasPlayed = !wasPlayed;
                    simpleSound.Play();
                }
                else
                {
                    buttonPlay.Text = "PLAY";
                    wasPlayed = !wasPlayed;
                    simpleSound.Stop();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }


        private void buttonFindDevice_Click(object sender, EventArgs e)
        {

            label1.Visible = true;
            List<NAudio.Wave.WaveInCapabilities> sources = new List<NAudio.Wave.WaveInCapabilities>();

            for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
                sources.Add(NAudio.Wave.WaveIn.GetCapabilities(i));

            listBoxDevices.Items.Clear();

            int counter = 0;
            foreach (var source in sources)
            {
                string item = source.ProductName;
                listBoxDevices.Items.Add("Mikrofon "+ counter + "->" + item);
                counter++;
            }
        }

        private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (waveWriter == null) return;

            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        private void buttonRecord_Click(object sender, EventArgs e)
        {
            if (wasRecored == false)
            {
                if (listBoxDevices.SelectedItems.Count == 0) return;
               

                if (fileRecordPath == "")
                {
                    MessageBox.Show("Wybierz miejsce w którym chcesz zapisać plik!");
                }
                else
                {


                    int deviceNumber = listBoxDevices.SelectedIndex;

                    sourceStream = new NAudio.Wave.WaveIn();
                    sourceStream.DeviceNumber = deviceNumber;
                    sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

                    sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
                    waveWriter = new NAudio.Wave.WaveFileWriter(fileRecordPath, sourceStream.WaveFormat);

                    sourceStream.StartRecording();
                    
                    buttonRecord.Text = "Nagrywanie...";
                    wasRecored = true;
                }
            }
            else if (wasRecored == true)
            {
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                    buttonRecord.Text = "Nagraj";
                }
                if (sourceStream != null)
                {
                    sourceStream.StopRecording();
                    sourceStream.Dispose();
                    sourceStream = null;
                    buttonRecord.Text = "Nagraj";
                }
                if (waveWriter != null)
                {
                    waveWriter.Dispose();
                    waveWriter = null;
                    buttonRecord.Text = "Nagraj";
                }

                labelRecording.Text = "";
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Wave File (*.wav)|*.wav;";
            if (save.ShowDialog() != DialogResult.OK) return ;
            else
                fileRecordPath = save.FileName;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
           
        }


















        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
