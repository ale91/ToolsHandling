using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public partial interface IService
    {
        List<PartNumbers> GetAllPartNumbers();
        PartNumbers GetPartNumberById(string id);

        /*
        void InsertPartNumber(PartNumbers partNumber);
        void UpdatePartNumber(PartNumbers partNumber);
        void DeletePartNumber(string id);
        */
    }
}
