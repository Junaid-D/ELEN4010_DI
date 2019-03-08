using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_man.Classification
{
   public interface ICategoryFinder
    {
        List<string> getCategories(List<string> inputData);
    }
}
