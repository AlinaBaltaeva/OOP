using System;
using System.Collections.Generic;

namespace Lab13
{
    public class Journal
    {
        private List<JournalEntry> journal = new List<JournalEntry>();

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs e)
        {
            journal.Add(new JournalEntry(e.NameCollection, e.ChangeType, e.Obj.ToString()));
        }
        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs e)
        {
            journal.Add(new JournalEntry(e.NameCollection, e.ChangeType, e.Obj.ToString()));
        }

        public void Print()
        {
            if (journal.Count == 0) Console.WriteLine("  (пусто)");
            foreach (JournalEntry je in journal)
                Console.WriteLine("  " + je);
        }
    }
}
