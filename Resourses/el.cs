namespace GraphicalShell.Resourses
{
    public class Element<T>
    {
        public int id { get; private set; }
        public string Description { get; private set; }
        public T  Value { get; private set; }
        public T  MinValue { get; private set; }
        public T  MaxValue { get; private set; }
        public bool Visible { get; private set; }
        public string Mask { get; private set; }
   
        public Element(int id, T val, T min, T max, string desc, string mask, bool v = true)
        {
            this.id = id;
            Description = desc;
            this.Value = val;
            this.MinValue = min;
            this.MaxValue = max;
            this.Visible = v;
            Mask = mask;
        }
        public Element()
        {

        }

        public static System.Type GetT()
        {
            return typeof(T);
        }
    }
}