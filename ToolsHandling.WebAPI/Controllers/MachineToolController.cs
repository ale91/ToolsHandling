using DAO;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Domain;

namespace ToolsHandling.WebAPI.Controllers
{
    public class MachineToolsController : ApiController
    {
        // GET: MachineTools
        public List<MachineTools> GetAllMachineTools()
        {
            var service = new Service();
            return service.GetAllMachineTools();
        }

        // GET: MachineTools/{id}
        public MachineTools GetMachineToolsById(int id)
        {
            var service = new Service();
            return service.GetMachineToolsById(id);
        }

        // POST: MachineTools
        public void InsertMachineTools(MachineTools machineTools)
        {
            var service = new Service();
            service.InsertMachineTools(machineTools);
        }

        // PUT: MachineTools
        public void UpdateMachineTools(MachineTools machineTools)
        {
            var service = new Service();
            service.UpdateMachineTools(machineTools);
        }

        // DELETE: MachineTools/{idTool}
        public void DeleteMachineTools(string idTool)
        {
            var service = new Service();
            service.DeleteMachineTools(idTool);
        }
    }
}