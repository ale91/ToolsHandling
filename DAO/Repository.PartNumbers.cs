using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public partial class Repository
    {
        public List<PartNumbers> GetAllPartNumbers()
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.PartNumbers.ToList();
            }
        }

        public PartNumbers GetPartNumberById(string id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.PartNumbers.FirstOrDefault(p => p.Code == id);
            }
        }

        /*
        public void InsertPartNumber(PartNumbers partNumber)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.PartNumbers.Add(partNumber);
                myDb.SaveChanges();
            }
        }

        public void UpdatePartNumber(PartNumbers partNumber)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.PartNumbers.AddOrUpdate(partNumber);
                myDb.SaveChanges();
            }
        }

        public void DeletePartNumber(string id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                var partNumber = myDb.PartNumbers.Find(id);
                if (partNumber != null)
                {
                    myDb.PartNumbers.Remove(partNumber);
                    myDb.SaveChanges();
                }
            }
        }
        */
    }
}
