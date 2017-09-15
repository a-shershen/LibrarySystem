using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySestem.BLL.DTOModels;

using LibrarySestem.BLL.Mappers;

namespace LibrarySestem.BLL.Services
{
    public class ReaderService:Interfaces.IReaderService
    {
        private DAL.Interfaces.IUnitOfWork db;

        public ReaderService(DAL.Interfaces.IUnitOfWork iUow)
        {
            db = iUow;
        }

        public void AddNewReader(ReaderDTO reader)
        {
            db.Readers.Add(reader.ToDal());
            db.Save();
        }

        public void DeleteReader(int readerId)
        {
            db.Readers.Delete(r => r.Id == readerId);
            db.Save();
        }

        public ReaderDTO GetReader(int readerId)
        {
            return db.Readers.Get(r => r.Id == readerId).ToDto();
        }

        public void UpdateReader(ReaderDTO reader)
        {
            db.Readers.Update(reader.ToDal());
            db.Save();
        }

        public IEnumerable<DTOModels.ReaderDTO> GetAll()
        {
            return db.Readers.GetAll().ToDto();
        }
    }
}
