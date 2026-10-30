namespace Lab13
{
    public class MyNewCollection : MyCollection
    {
        public string Name { get; set; }
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public MyNewCollection(string name)
        {
            Name = name;
        }

        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }

        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(source, args);
        }

        public override void AddDefaults(int count = 5)
        {
            for (int i = 0; i < count; i++)
            {
                Student s = CreateRandom();
                list.Add(s);
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "добавлен элемент", s));
            }
        }

        public override void Add(params Student[] students)
        {
            foreach (Student s in students)
            {
                list.Add(s);
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "добавлен элемент", s));
            }
        }
        public override bool Remove(int j)
        {
            if (j < 0 || j >= list.Count) return false;
            Student removed = list[j];
            list.RemoveAt(j);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "удалён элемент", removed));
            return true;
        }

        public override Student this[int index]
        {
            get { return base[index]; }
            set
            {
                base[index] = value;
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "заменён элемент", value));
            }
        }
    }
}
