using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_man.RequestInterfaces
{
    /// <summary>
    /// Common interface of API request classes. Responsible for generating a JSON string per request
    /// </summary>
    public interface IRequestData
    {
        string getRecent();
    }
}
