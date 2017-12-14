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
            this.listBoxDevices = new System.Windows.Forms.ListBox();
            this.listBoxConnected = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxConsole = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFindDevices = new System.Windows.Forms.Button();
            this.buttonPairWithDevice = new System.Windows.Forms.Button();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.buttonUnpair = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxDevices
            // 
            this.listBoxDevices.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDevices.FormattingEnabled = true;
            this.listBoxDevices.ItemHeight = 15;
            this.listBoxDevices.Location = new System.Drawing.Point(15, 41);
            this.listBoxDevices.Name = "listBoxDevices";
            this.listBoxDevices.ScrollAlwaysVisible = true;
            this.listBoxDevices.Size = new System.Drawing.Size(497, 94);
            this.listBoxDevices.TabIndex = 0;
            // 
            // listBoxConnected
            // 
            this.listBoxConnected.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxConnected.FormattingEnabled = true;
            this.listBoxConnected.ItemHeight = 15;
            this.listBoxConnected.Location = new System.Drawing.Point(15, 176);
            this.listBoxConnected.Name = "listBoxConnected";
            this.listBoxConnected.ScrollAlwaysVisible = true;
            this.listBoxConnected.Size = new System.Drawing.Size(497, 109);
            this.listBoxConnected.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wykryte urządzenia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Połączono z urządzeniem";
            // 
            // textBoxConsole
            // 
            this.textBoxConsole.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxConsole.Location = new System.Drawing.Point(15, 315);
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
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Komunikaty";
            // 
            // buttonFindDevices
            // 
            this.buttonFindDevices.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonFindDevices.Location = new System.Drawing.Point(182, 12);
            this.buttonFindDevices.Name = "buttonFindDevices";
            this.buttonFindDevices.Size = new System.Drawing.Size(182, 23);
            this.buttonFindDevices.TabIndex = 6;
            this.buttonFindDevices.Text = "Szukaj urządzeń";
            this.buttonFindDevices.UseVisualStyleBackColor = true;
            this.buttonFindDevices.Click += new System.EventHandler(this.buttonFindDevices_Click);
            // 
            // buttonPairWithDevice
            // 
            this.buttonPairWithDevice.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPairWithDevice.Location = new System.Drawing.Point(182, 147);
            this.buttonPairWithDevice.Name = "buttonPairWithDevice";
            this.buttonPairWithDevice.Size = new System.Drawing.Size(156, 23);
            this.buttonPairWithDevice.TabIndex = 7;
            this.buttonPairWithDevice.Text = "Połącz";
            this.buttonPairWithDevice.UseVisualStyleBackColor = true;
            this.buttonPairWithDevice.Click += new System.EventHandler(this.buttonPairWithDevice_Click);
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAddFile.Location = new System.Drawing.Point(52, 552);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFile.TabIndex = 8;
            this.buttonAddFile.Text = "Dodaj plik";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSendFile.Location = new System.Drawing.Point(237, 552);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSendFile.TabIndex = 10;
            this.buttonSendFile.Text = "Wyślij plik";
            this.buttonSendFile.UseVisualStyleBackColor = true;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonSendFile_Click);
            // 
            // buttonUnpair
            // 
            this.buttonUnpair.Enabled = false;
            this.buttonUnpair.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUnpair.Location = new System.Drawing.Point(344, 147);
            this.buttonUnpair.Name = "buttonUnpair";
            this.buttonUnpair.Size = new System.Drawing.Size(168, 23);
            this.buttonUnpair.TabIndex = 12;
            this.buttonUnpair.Text = "Rozłącz";
            this.buttonUnpair.UseVisualStyleBackColor = true;
            this.buttonUnpair.Click += new System.EventHandler(this.buttonUnpair_Click);
            // 
            // openFile
            // 
            this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.HorizontalScrollbar = true;
            this.listBoxFiles.ItemHeight = 15;
            this.listBoxFiles.Location = new System.Drawing.Point(502, 281);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.ScrollAlwaysVisible = true;
            this.listBoxFiles.Size = new System.Drawing.Size(12, 4);
            this.listBoxFiles.TabIndex = 11;
            this.listBoxFiles.Visible = false;
            this.listBoxFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxFiles_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(524, 577);
            this.Controls.Add(this.buttonUnpair);
            this.Controls.Add(this.listBoxFiles);
            this.Controls.Add(this.buttonSendFile);
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
        private System.Windows.Forms.Button buttonSendFile;
        private System.Windows.Forms.Button buttonUnpair;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ListBox listBoxFiles;
    }
}

