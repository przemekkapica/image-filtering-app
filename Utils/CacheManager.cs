using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace image_filtering_app
{
    static class CacheManager
    {
        public static List<string> filterState;
        public static Dictionary<List<string>, Bitmap> cachedFilterStates = null;

        public static void InitializeWithOriginal(Bitmap bmp)
        {
            filterState = new List<string>();

            cachedFilterStates = new Dictionary<List<string>, Bitmap>(new StringListEqComparer())
            {
                { new List<string>(), DeepCopy(bmp)}
            };
        }

        public static void UpdateFilterState(string filter, bool newChecked)
        {
            if (newChecked)
            {
                filterState.Add(filter);
            }
            else
            {
                filterState.Remove(filter);
            }
        }

        public static void ResetCache(Bitmap bmp)
        {
            cachedFilterStates.Clear();

            cachedFilterStates = new Dictionary<List<string>, Bitmap>(new StringListEqComparer())
            {
                { new List<string>(), DeepCopy(bmp)}
            };
        }

        public static Bitmap GetBitmapForFilterState() => cachedFilterStates.ContainsKey(filterState) ? cachedFilterStates[filterState] : null;

        public static void SetBitmapForFilterState(Bitmap bmp) => cachedFilterStates[filterState] = DeepCopy(bmp);

        public static Bitmap GetOriginalImage()
        {
            try
            {
                return cachedFilterStates[new List<string>()];
            }
            catch
            {
                throw new Exception(message: "Nie ma co resetowac debilu");
            }
        }

        public static T DeepCopy<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Type must be serializable.", "source");
            }

            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }

    public class StringListEqComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            if (x.Count != y.Count)
            {
                return false;
            }
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(List<string> obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Count; i++)
            {
                unchecked
                {
                    result = result * 23 + obj[i].GetHashCode();
                }
            }
            return result;
        }
    }
}
