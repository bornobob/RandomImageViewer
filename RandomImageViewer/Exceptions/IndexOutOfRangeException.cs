using System;

namespace RandomImageViewer.Exceptions
{
    public class IndexOutOfRangeException : Exception
    {
        public IndexOutOfRangeException(int index) : base($"Index {index} is out of range")
        {
        }
    }
}
