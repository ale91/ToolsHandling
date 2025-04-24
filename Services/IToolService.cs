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
        List<Tools> GetAllTools();
        Tools GetToolsById(string idTool);
        void InsertTools(Tools tool);
        void UpdateTools(Tools tool);
        void DeleteTools(string tool);

        int UpdateAllToolsType();
        List<Tools> GetToolsByToolType(int toolType, bool isMounted = true);
        int UpdateAllToolTypes();

        List<Tools> GetToolsByMachine(string machineCode);
    }
}
