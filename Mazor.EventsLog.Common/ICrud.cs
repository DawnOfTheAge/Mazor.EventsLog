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

        bool Add(string name, object data, out Guid newId, out string result);
        bool Exists(string name);
        bool Delete(Guid id, out string result);

        List<T> GetItemsList();
    }
}
