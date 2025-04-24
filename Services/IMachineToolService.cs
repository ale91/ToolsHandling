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
        List<MachineTools> GetAllMachineTools();
        MachineTools GetMachineToolsById(int id);
        void InsertMachineTools(MachineTools machineTools);
        void UpdateMachineTools(MachineTools machineTools);
        void DeleteMachineTools(string idTool);
    }
}
