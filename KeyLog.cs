using System.Text;

namespace YMH219_KeyEventLogger
{
    public class KeyLog
    {
        private readonly List<KeyLogEntry> _entries = new();
        public bool IsRecording { get; private set; }
        public IReadOnlyList<KeyLogEntry> Entries => _entries.AsReadOnly();

        public void Start() => IsRecording = true;
        public void Stop() => IsRecording = false;

        public KeyLogEntry? AddEvent(string eventType, Keys key)
        {
            if (!IsRecording) return null;

            var entry = new KeyLogEntry(eventType, key);
            _entries.Add(entry);
            return entry;
        }

        public void Clear()
        {
            _entries.Clear();
        }

        public void SaveToFile(string filePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("YMH219 - Eğitsel Klavye Olay Kaydı");
            sb.AppendLine($"Öğrenci: Büşra Yeşilbulut (240541094)");
            sb.AppendLine($"Oluşturulma Tarihi: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
            sb.AppendLine(new string('-', 50));

            foreach (var entry in _entries)
            {
                sb.AppendLine(entry.ToString());
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
}