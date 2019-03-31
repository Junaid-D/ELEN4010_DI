using NewsResponse;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_man.DataAccess
{
   /// <summary>
   /// Highest level story storage class.
   /// </summary>
   public class StorySaver
    {
        private IResponseSaver responseSaver;

        public StorySaver([Named("Multi")] IResponseSaver saver)
        {
            responseSaver = saver;
        }

        public void saveStories(List<Article> toSave)
        {
            responseSaver.saveData(toSave);
        }
    }
}
