using DB_man.Classification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_man.Classifier
{
    /// <summary>
    /// Highest level text analytics class.
    /// </summary>
    public class TextAnalyser
    {
        private ICategoryFinder categoryFinder;

        public TextAnalyser(ICategoryFinder catFinder)
        {
            categoryFinder = catFinder;
        }

        public List<string> getCategories(List<string> input)
        {
            return categoryFinder.getCategories(input);
        }
    }
}
