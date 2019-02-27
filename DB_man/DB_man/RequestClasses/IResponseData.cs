using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_man.RequestInterfaces
{
    public interface IResponseData
    {
        IResponseData FromJson(string json);
        //string ToJson(IResponseData self);
    }
}
