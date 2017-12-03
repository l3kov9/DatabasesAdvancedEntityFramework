using System.Collections.Generic;
using System.Text;

namespace StorageBox
{
    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public void AddElement(T element)
        {
            this.data.Add(element);
        }

        public void Remove()
        {
            this.data.RemoveAt(this.data.Count - 1);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < this.data.Count-1; i++)
            {
                sb.Append(this.data[i]);
                sb.Append(", ");
            }

            sb.Append(this.data[this.data.Count - 1]);

            return sb.ToString();
        }
    }
}
