using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazor.EventsLog.Common
{
    public interface ICrud<T>
    {
        List<T> ItemsList { get; set; }

        bool Add(string name, object data, out int newId, out string result);
        bool Exists(string name);
        bool Delete(int id, out string result);

        List<T> GetItemsList();
    }
}
