using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public partial class Program
    {
        sealed public partial class News : TvProgram
        {
            public override string ToString()
            {
                return $"Type: {this.GetType()}, Duration: {Duration}, Name: {Name}, Define: {Define}";
            }

            public override int GetHashCode()
            {
                return (int)(this.Duration - 456 * 10 / 20 + 9786 - 3);
            }

            private int id;

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (obj.GetType() != this.GetType()) return false;
                News test_equals = (News)obj;
                return ((this.Duration == test_equals.Duration) &&
                        (this.Define == test_equals.Define) &&
                        (this.Name == test_equals.Name) &&
                        (this.id == test_equals.id));
            }
        }
    }
}
