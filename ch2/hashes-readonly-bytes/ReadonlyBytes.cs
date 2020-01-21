using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hashes
{
    class ReadonlyBytes : IEnumerable<byte>
    {
        private byte[] array;
        private int elementHashCode = Int32.MinValue;
        public int Length => array.Length;

        public ReadonlyBytes(params byte[] newArray)
        {
            if (newArray == null)
                throw new ArgumentNullException();
            array = newArray;
        }

        public IEnumerator<byte> GetEnumerator()
        {
            foreach (var e in array)
                yield return e;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            var newArray = obj as ReadonlyBytes;
            return newArray.Length != array.Length ? false : (array.SequenceEqual(newArray));
        }

        public override int GetHashCode()
        {
            if (elementHashCode != int.MinValue)
                return elementHashCode;
            elementHashCode = 1;
            unchecked
            {
                for (int i = 0; i < array.Length; i++)
                    elementHashCode = elementHashCode * 971 + array[i];
            }

            return elementHashCode;
        }

        public byte this[int index] => array[index];

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append('[' + string.Join(", ", array) + ']');
            return str.ToString();
        }
    }
}