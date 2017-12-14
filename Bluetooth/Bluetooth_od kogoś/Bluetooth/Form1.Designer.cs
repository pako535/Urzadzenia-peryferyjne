namespace Bluetooth
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBoxDevices = new System.Windows.Forms.ListBox();
            this.listBoxConnected = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFindDevices = new System.Windows.Forms.Button();
            this.buttonPairWithDevice = new System.Windows.Forms.Button();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonDeleteFile = new System.Windows.Forms.Button();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.buttonUnpair = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.textBoxReceivedFiles = new System.Windows.Forms.TextBox();
            this.labelReceivedFiles = new System.Windows.Forms.Label();
            this.labelFilesToSend = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxDevices
            // 
            this.listBoxDevices.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxDevices.FormattingEnabled = true;
            this.listBoxDevices.ItemHeight = 19;
            this.listBoxDevices.Location = new System.Drawing.Point(12, 67);
            this.listBoxDevices.Name = "listBoxDevices";
            this.listBoxDevices.ScrollAlwaysVisible = true;
            this.listBoxDevices.Size = new System.Drawing.Size(182, 99);
            this.listBoxDevices.TabIndex = 0;
            // 
            // listBoxConnected
            // 
            this.listBoxConnected.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxConnected.FormattingEnabled = true;
            this.listBoxConnected.ItemHeight = 19;
            this.listBoxConnected.Location = new System.Drawing.Point(200, 67);
            this.listBoxConnected.Name = "listBoxConnected";
            this.listBoxConnected.ScrollAlwaysVisible = true;
            this.listBoxConnected.Size = new System.Drawing.Size(312, 99);
            this.listBoxConnected.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wykryte urządzenia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(200, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Połączono z urządzeniem";
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxConsole.Location = new System.Drawing.Point(13, 181);
            this.textBoxConsole.Multiline = true;
            this.textBoxConsole.Name = "textBoxConsole";
            this.textBoxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxConsole.Size = new System.Drawing.Size(499, 213);
            this.textBoxConsole.TabIndex = 4;
            this.textBoxConsole.WordWrap = false;
            this.textBoxConsole.TextChanged += new System.EventHandler(this.textBoxConsole_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Komunikaty";
            // 
            // buttonFindDevices
            // 
            this.buttonFindDevices.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonFindDevices.Location = new System.Drawing.Point(12, 12);
            this.buttonFindDevices.Name = "buttonFindDevices";
            this.buttonFindDevices.Size = new System.Drawing.Size(182, 23);
            this.buttonFindDevices.TabIndex = 6;
            this.buttonFindDevices.Text = "Szukaj urządzeń";
            this.buttonFindDevices.UseVisualStyleBackColor = true;
            this.buttonFindDevices.Click += new System.EventHandler(this.buttonFindDevices_Click);
            // 
            // buttonPairWithDevice
            // 
            this.buttonPairWithDevice.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPairWithDevice.Location = new System.Drawing.Point(200, 12);
            this.buttonPairWithDevice.Name = "buttonPairWithDevice";
            this.buttonPairWithDevice.Size = new System.Drawing.Size(203, 23);
            this.buttonPairWithDevice.TabIndex = 7;
            this.buttonPairWithDevice.Text = "Sparuj z wybranym urządzeniem";
            this.buttonPairWithDevice.UseVisualStyleBackColor = true;
            this.buttonPairWithDevice.Click += new System.EventHandler(this.buttonPairWithDevice_Click);
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAddFile.Location = new System.Drawing.Point(518, 179);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFile.TabIndex = 8;
            this.buttonAddFile.Text = "Dodaj plik";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonDeleteFile
            // 
            this.buttonDeleteFile.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteFile.Location = new System.Drawing.Point(599, 179);
            this.buttonDeleteFile.Name = "buttonDeleteFile";
            this.buttonDeleteFile.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteFile.TabIndex = 9;
            this.buttonDeleteFile.Text = "Usuń plik";
            this.buttonDeleteFile.UseVisualStyleBackColor = true;
            this.buttonDeleteFile.Click += new System.EventHandler(this.buttonDeleteFile_Click);
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSendFile.Location = new System.Drawing.Point(680, 179);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSendFile.TabIndex = 10;
            this.buttonSendFile.Text = "Wyślij plik";
            this.buttonSendFile.UseVisualStyleBackColor = true;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonSendFile_Click);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.HorizontalScrollbar = true;
            this.listBoxFiles.ItemHeight = 19;
            this.listBoxFiles.Location = new System.Drawing.Point(518, 234);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.ScrollAlwaysVisible = true;
            this.listBoxFiles.Size = new System.Drawing.Size(237, 156);
            this.listBoxFiles.TabIndex = 11;
            // 
            // buttonUnpair
            // 
            this.buttonUnpair.Enabled = false;
            this.buttonUnpair.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUnpair.Location = new System.Drawing.Point(409, 12);
            this.buttonUnpair.Name = "buttonUnpair";
            this.buttonUnpair.Size = new System.Drawing.Size(103, 23);
            this.buttonUnpair.TabIndex = 12;
            this.buttonUnpair.Text = "Rozłącz";
            this.buttonUnpair.UseVisualStyleBackColor = true;
            this.buttonUnpair.Click += new System.EventHandler(this.buttonUnpair_Click);
            // 
            // openFile
            // 
            this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
            // 
            // textBoxReceivedFiles
            // 
            this.textBoxReceivedFiles.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxReceivedFiles.Location = new System.Drawing.Point(518, 28);
            this.textBoxReceivedFiles.Multiline = true;
            this.textBoxReceivedFiles.Name = "textBoxReceivedFiles";
            this.textBoxReceivedFiles.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxReceivedFiles.Size = new System.Drawing.Size(237, 134);
            this.textBoxReceivedFiles.TabIndex = 13;
            this.textBoxReceivedFiles.TextChanged += new System.EventHandler(this.textBoxReceivedFiles_TextChanged);
            // 
            // labelReceivedFiles
            // 
            this.labelReceivedFiles.AutoSize = true;
            this.labelReceivedFiles.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceivedFiles.Location = new System.Drawing.Point(521, 12);
            this.labelReceivedFiles.Name = "labelReceivedFiles";
            this.labelReceivedFiles.Size = new System.Drawing.Size(120, 16);
            this.labelReceivedFiles.TabIndex = 14;
            this.labelReceivedFiles.Text = "Odebrane pliki";
            // 
            // labelFilesToSend
            // 
            this.labelFilesToSend.AutoSize = true;
            this.labelFilesToSend.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilesToSend.Location = new System.Drawing.Point(521, 209);
            this.labelFilesToSend.Name = "labelFilesToSend";
            this.labelFilesToSend.Size = new System.Drawing.Size(144, 16);
            this.labelFilesToSend.TabIndex = 15;
            this.labelFilesToSend.Text = "Pliki do wysłania";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BackgroundImage = global::Bluetooth.Properties.Resources.Tlo;
            this.ClientSize = new System.Drawing.Size(766, 406);
            this.Controls.Add(this.labelFilesToSend);
            this.Controls.Add(this.labelReceivedFiles);
            this.Controls.Add(this.textBoxReceivedFiles);
            this.Controls.Add(this.buttonUnpair);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.buttonSendFile);
            this.Controls.Add(this.buttonDeleteFile);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.buttonPairWithDevice);
            this.Controls.Add(this.buttonFindDevices);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxConsole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxConnected);
            this.Controls.Add(this.listBoxDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Bluetooth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDevices;
        private System.Windows.Forms.ListBox listBoxConnected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxConsole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonFindDevices;
        private System.Windows.Forms.Button buttonPairWithDevice;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonDeleteFile;
        private System.Windows.Forms.Button buttonSendFile;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button buttonUnpair;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.TextBox textBoxReceivedFiles;
        private System.Windows.Forms.Label labelReceivedFiles;
        private System.Windows.Forms.Label labelFilesToSend;
    }
}

