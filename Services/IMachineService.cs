using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public partial interface IService
    {
        List<Machines> GetAllMachines();
        Machines GetMachineById(int id);
        void InsertMachine(Machines machine);
        void UpdateMachine(Machines machine);
        void DeleteMachine(string machineCode);

        int UpdateAllMachinesType();

        void InsertMachine(Machines machine, int ToolType); //Overload che accetta il valore di ToolType

        /*
        
        Inserimento services per il ToolType
        int UpdateAllToolsType();
        List<Machines> GetToolsByToolType(int toolType);
        int UpdateAllToolTypes();

        */
    }
}
