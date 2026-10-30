namespace Lab13
{
    public class JournalEntry
    {
        public string NameCollection { get; set; }
        public string ChangeType { get; set; }
        public string ObjData { get; set; }

        public JournalEntry(string nameCollection, string changeType, string objData)
        {
            NameCollection = nameCollection;
            ChangeType = changeType;
            ObjData = objData;
        }

    }
}
