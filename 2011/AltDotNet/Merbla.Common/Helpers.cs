using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Merbla.Common
{
    public static class Helpers
    {
        public static byte[] ToByteArray(this Object obj)
        {
            if (obj == null)
                return null;
            var bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static T To<T>(this byte[] byteArray)
        {
            var ms = new MemoryStream();
            var bf = new BinaryFormatter();
            ms.Write(byteArray, 0, byteArray.Length);
            ms.Seek(0, SeekOrigin.Begin);
            var deserialisedObject = (T) bf.Deserialize(ms);
            return deserialisedObject;
        }
    }
}