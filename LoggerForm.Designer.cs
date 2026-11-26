namespace YMH219_KeyEventLogger
{
    partial class LoggerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnStartStop = new Button();
            btnClear = new Button();
            btnSave = new Button();
            lblStatus = new Label();
            lstLogs = new ListBox();
            SuspendLayout();

            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.DarkRed;
            lblStatus.Location = new Point(15, 18);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(155, 19);
            lblStatus.Text = "● Durum: Durduruldu";

            // btnStartStop
            btnStartStop.Location = new Point(220, 12);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(110, 32);
            btnStartStop.TabStop = false;
            btnStartStop.Text = "Başlat";
            btnStartStop.UseVisualStyleBackColor = true;
            btnStartStop.Click += btnStartStop_Click;

            // btnClear
            btnClear.Location = new Point(338, 12);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 32);
            btnClear.TabStop = false;
            btnClear.Text = "Temizle";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            // btnSave
            btnSave.Location = new Point(446, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 32);
            btnSave.TabStop = false;
            btnSave.Text = "Kaydet (.txt)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // lstLogs
            lstLogs.Font = new Font("Consolas", 9.75F);
            lstLogs.FormattingEnabled = true;
            lstLogs.ItemHeight = 15;
            lstLogs.Location = new Point(15, 55);
            lstLogs.Name = "lstLogs";
            lstLogs.Size = new Size(541, 319);
            lstLogs.TabStop = false;

            // LoggerForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 390);
            Controls.Add(lstLogs);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(btnStartStop);
            Controls.Add(lblStatus);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "LoggerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "YMH219 - Key Event Logger | Büşra Yeşilbulut";
            KeyDown += LoggerForm_KeyDown;
            KeyUp += LoggerForm_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnStartStop;
        private Button btnClear;
        private Button btnSave;
        private Label lblStatus;
        private ListBox lstLogs;
    }
}