using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public partial class Service : IService
    {
        //Istanza di Random per generare numeri casuali da 1 a 3
        private static readonly Random rdm = new Random();

        //Metodo per generare numero casuale da 1 a 3
        private int GeneraNumeri()
        {
            //random.Next resistuisce i valori da 1 a 3
            return rdm.Next(1, 4);
        }

        //Metodi per Machines
        public List<Machines> GetAllMachines()
        {
            return _repository.GetAllMachines();
        }

        public Machines GetMachineById(int id)
        {
            return _repository.GetMachineById(id);
        }

        public void InsertMachine(Machines machine)
        {
            _repository.InsertMachine(machine);
        }

        public void UpdateMachine(Machines machine)
        {
            _repository.UpdateMachine(machine);
        }

        public void DeleteMachine(string machineCode)
        {
            _repository.DeleteMachine(machineCode);
        }

        public void DeleteMachine(Machines machine)
        {
            _repository.DeleteMachine(machine);
        }

        public void InsertMachine(Machines machine, int ToolType)
        {
            _repository.InsertMachine(machine);
        }

        public int UpdateAllMachinesType()
        {
            var machines = _repository.GetAllMachines().Where(machine => machine.ToolType == null).ToList();

            //Per ogni machine genera un numero casuale
            foreach(var machine in machines)
            {
                machine.ToolType = GeneraNumero();
            }

            //Richiamo metodo UpdateMachine
            int UpdateMachine = _repository.UpdateAllMachines(machines);

            return UpdateMachine;
        }

    }
}
