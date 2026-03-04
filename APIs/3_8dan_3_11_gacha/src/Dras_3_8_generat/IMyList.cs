namespace Dras_3_8_generat
{
    public interface IMyList<T> where T : class, new()

    {
        public bool Add(T num);
        public bool RemoveAll(T num);
        public bool Remove(T num);
        public bool Contains(T num);
        public int IndexOf(T num);
        public bool RemoveAt(int index);
        public T GetById(int index);
        public void DisplayElements();
    }
}