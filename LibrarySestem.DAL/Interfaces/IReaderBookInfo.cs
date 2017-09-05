using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.DAL.Interfaces
{
    interface IReaderBookInfo:IGenericRepo<Models.ReaderBook>
    {
        IEnumerable<ExtendedModels.ReaderBookInfo> GetAllInfo(Func<Models.ReaderBook, bool> predicate = null);
    }
}
