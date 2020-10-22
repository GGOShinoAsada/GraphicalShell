using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalShell.Resourses
{
    public struct Element<T>
    {
        public int Id { get; }
        public string Description { get; set; }
        public T Value { get; set; }
        public bool Visible { get; set; }
        public T MaxValue { get; }
        public T MinVaule { get; }
        public string Mask { get; set; }
        public string Parent { get; }
        public bool IsFinalVaue { get; }
        public Element(int id, string desc, string parent, T value, T min, T max, string mask,bool isfinv=false, bool v =true)
        {
            Id = id;
            Description = desc;
            Parent = parent;
            Mask = mask;
            Value = value;
            MinVaule = min;
            MaxValue = max;
            Visible = v;
            IsFinalVaue = isfinv;
           
        }

    }
}
