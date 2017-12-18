using System;
using System.Collections.Generic;

namespace Collections2
{
    class Segment : IComparable<Segment>, IComparer<Segment>
    {
        private int len;
        private int num = 1;

        public int Len { get => len; set => len = value; }
        public int Num { get => num; set => num = value; }

        public Segment() { }
        public Segment(int len, int num)
        {
            this.len = len;
            this.num = num;
        }
        public Segment(int len)
        {
            this.len = len;
        }

        public int CompareTo(Segment other)
        {
            if (len == other.Len)
            {
                return 0;
            }
            else if (len > other.Len)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public int Compare(Segment x, Segment y)
        {
            return -(x.num.CompareTo(y.Num));
        }

        public override string ToString()
        {
            return (len + ";" + num);
        }
    }
}
