using DAO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public partial class Service : IService
    {
        public List<PartNumbers> GetAllPartNumbers()
        {
            return _repository.GetAllPartNumbers();
        }

        public PartNumbers GetPartNumberById(string id)
        {
            return _repository.GetPartNumberById(id);
        }

        /*

        public void InsertPartNumber(PartNumbers partNumber)
        {
            _repository.InsertPartNumber(partNumber);
        }

        public void UpdatePartNumber(PartNumbers partNumber)
        {
            _repository.UpdatePartNumber(partNumber);
        }

        public void DeletePartNumber(string id)
        {
            _repository.DeletePartNumber(id);
        }
        */
    }
}
