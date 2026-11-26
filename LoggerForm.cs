namespace YMH219_KeyEventLogger
{
    public partial class LoggerForm : Form
    {
        private readonly KeyLog _keyLog = new();

        public LoggerForm()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_keyLog.IsRecording && (keyData == Keys.Tab || keyData == Keys.Up ||
                keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right))
            {
                RecordKey("KeyDown", keyData);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RecordKey(string eventType, Keys key)
        {
            var entry = _keyLog.AddEvent(eventType, key);
            if (entry != null)
            {
                lstLogs.Items.Add(entry.ToString());
                lstLogs.TopIndex = lstLogs.Items.Count - 1;
            }
        }

        private void LoggerForm_KeyDown(object? sender, KeyEventArgs e)
        {
            RecordKey("KeyDown", e.KeyCode);
        }

        private void LoggerForm_KeyUp(object? sender, KeyEventArgs e)
        {
            RecordKey("KeyUp", e.KeyCode);
        }

        private void btnStartStop_Click(object? sender, EventArgs e)
        {
            if (_keyLog.IsRecording)
            {
                _keyLog.Stop();
                btnStartStop.Text = "Başlat";
                lblStatus.Text = "● Durum: Durduruldu";
                lblStatus.ForeColor = Color.DarkRed;
            }
            else
            {
                _keyLog.Start();
                btnStartStop.Text = "Durdur";
                lblStatus.Text = "● Durum: Kayıt Yapılıyor...";
                lblStatus.ForeColor = Color.DarkGreen;
                this.Focus();
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            _keyLog.Clear();
            lstLogs.Items.Clear();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (_keyLog.Entries.Count == 0)
            {
                MessageBox.Show("Kaydedilecek herhangi bir tuş kaydı bulunmuyor.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using SaveFileDialog sfd = new()
            {
                Filter = "Metin Dosyası (*.txt)|*.txt",
                FileName = $"KeyLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _keyLog.SaveToFile(sfd.FileName);
                    MessageBox.Show("Kayıtlar başarıyla dosyaya yazıldı.", "Başarılı",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Dosya kaydedilirken hata oluştu:\n{ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}