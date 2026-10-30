using System;

namespace Lab13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string NameCollection { get; set; }
        public string ChangeType { get; set; }
        public object Obj { get; set; }     

        public CollectionHandlerEventArgs(string nameCollection, string changeType, object obj)
        {
            NameCollection = nameCollection;
            ChangeType = changeType;
            Obj = obj;
        }
    }
}
