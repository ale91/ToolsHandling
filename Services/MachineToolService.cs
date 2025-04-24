using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public partial class Service 
    {
        //Metodi per MachineTools
        public List<MachineTools> GetAllMachineTools()
        {
            return _repository.GetAllMachineTools();
        }

        public MachineTools GetMachineToolsById(int id)
        {
            return _repository.GetMachineToolsById(id);
        }

        public void InsertMachineTools(MachineTools machineTool)
        {
            _repository.InsertMachineTools(machineTool);
        }

        public void UpdateMachineTools(MachineTools machineTool)
        {
            _repository.UpdateMachineTools(machineTool);
        }

        public void DeleteMachineTools(string idTool)
        {
            _repository.DeleteMachineTools(idTool);
        }
    }
}
