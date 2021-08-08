using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Asignment003
{
    public class SerializedFile : IComparable<SerializedFile>
    {
        public long Size { get; set; }
        public string Name { get; set; }

        public int CompareTo(SerializedFile other)
        {
            if (other == null)
                return 1;
            else
                return Size.CompareTo(other.Size);
        }
    }
}
