using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySestem.BLL.Interfaces
{
    public interface IReaderService
    {
        void AddNewReader(DTOModels.ReaderDTO reader);

        DTOModels.ReaderDTO GetReader(int readerId);

        void UpdateReader(DTOModels.ReaderDTO reader);

        void DeleteReader(int readerId);

        IEnumerable<DTOModels.ReaderDTO> GetAll();
    }
}
