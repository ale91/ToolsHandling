using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public partial class Repository
    {
        public List<Machines> GetAllMachines()
        {
            using (MyDBContext myDb = new MyDBContext())
            {

                return myDb.Machines
                    //.Include("Tools")
                    .ToList();

            }
        }

        //Metodo Get By Id (aggiunto)
        public Machines GetMachineById(int id)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Machines.Find(id);
            }
        }

        //Metodo Insert (aggiunto), aggiornamento per impostare il valore del ToolType
        public void InsertMachine(Machines machine)
        {
            using (MyDBContext myDb = new MyDBContext())
            {                
                myDb.Machines.Add(machine);
                myDb.SaveChanges();
            }
        }

        //Metodo Update (aggiunto)
        public void UpdateMachine(Machines machine)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.Machines.AddOrUpdate(machine);
                myDb.SaveChanges();
            }
        }

        //Metodo Delete per MachineCode (aggiunto)
        public void DeleteMachine(string machineCode)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                var machine = myDb.Machines.Where(m => m.MachineCode == machineCode).FirstOrDefault();  //In questo caso, stiamo cercando tutte le macchine (m) il cui Id è uguale al valore di id
                if (machine != null)
                {
                    myDb.Machines.Remove(machine);
                    myDb.SaveChanges();
                }
            }
        }

        //Metodo Delete per macchina
        public void DeleteMachine(Machines machine)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                myDb.Machines.Remove(machine);
                myDb.SaveChanges();
            }
        }

        //Metodo Update per tutte le machines
        public int UpdateAllMachines(List<Machines> machines)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                foreach (var machine in machines) //per ogni machine nella lista
                {
                    myDb.Machines.AddOrUpdate(machine); //viene chiamato il metodo AddOrUpdate del contesto del db, aggiunge una machine se non esiste, altrimenti lo aggiorna
                }
                return myDb.SaveChanges();
            }
        }
    }
}
