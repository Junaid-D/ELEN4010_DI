using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_man.Classification
{
    /// <summary>
    /// Responsible for generating a list of strings (keywords) from a list of strings(articles).
    /// </summary>
    public interface ICategoryFinder
    {
        List<string> getCategories(List<string> inputData);
    }
}
