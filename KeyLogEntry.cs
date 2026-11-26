namespace YMH219_KeyEventLogger
{
    public class KeyLogEntry
    {
        public DateTime Timestamp { get; }
        public string EventType { get; }
        public Keys Key { get; }

        public KeyLogEntry(string eventType, Keys key)
        {
            Timestamp = DateTime.Now;
            EventType = eventType;
            Key = key;
        }

        public override string ToString()
        {
            return $"[{Timestamp:HH:mm:ss.fff}] {EventType,-8} | Tuş: {Key}";
        }
    }
}