using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAO
{
    public partial class Repository
    {
        public List<Turrets> GetAllTurrets()
        {
            using (MyDBContext myDb = new MyDBContext())
            {

                return myDb.Turrets.ToList();

            }
        }

        //Metodo Get By Id (aggiunto)
        public Turrets GetTurretById(int id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Turrets.Find(id);
            }
        }

        //Metodo Insert (aggiunto)
        public void InsertTurret(Turrets turret)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.Turrets.Add(turret);
                myDb.SaveChanges();
            }
        }

        //Metodo Update (aggiunto)
        public void UpdateTurret(Turrets turret)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.Turrets.AddOrUpdate(turret);
                myDb.SaveChanges();
            }
        }

        //Metodo Delete per TurretCode (aggiunto)
        public void DeleteTurrets(string turretCode)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                var turret = myDb.Turrets.FirstOrDefault(t => t.TurretCode == turretCode);
                if (turret != null)
                {
                    myDb.Turrets.Remove(turret);
                    myDb.SaveChanges();
                }
            }
        }
    }
}
