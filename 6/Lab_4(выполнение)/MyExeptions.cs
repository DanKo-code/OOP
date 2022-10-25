using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public class NullCollectionException : Exception
    {
        public NullCollectionException(string message) : base(message) { }
    }

    public class WrongIndexException : Exception
    {
        public WrongIndexException(string message) : base(message) { }
    }

    public class OutOfTvProgramRange : OverflowException
    {
        public OutOfTvProgramRange(string message) : base(message) { }
    }

    public class TestNullObject : NullReferenceException
    {
        public TestNullObject(string message) : base(message) { }
    }
}
