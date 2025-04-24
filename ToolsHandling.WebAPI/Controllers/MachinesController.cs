using DAO;
using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;



namespace ToolsHandling.WebAPI.Controllers
{
    public class MachinesController : ApiController
    {
        // GET: GetAllMachines
        [System.Web.Http.Route("api/Machines/GetAllMachines")]
        [System.Web.Http.HttpGet]
        public List<Machines> GetAllMachines()
        {
            var service = new Services.Service();
            return service.GetAllMachines();
        }

        // GET: Machines/{id}
        public Machines GetMachineById(int id)
        {
            var service = new Services.Service();
            return service.GetMachineById(id);
        }

        // POST: InsertMachines
        public void InsertMachine(Machines machine)
        {
            var service = new Services.Service();
            service.InsertMachine(machine);
        }

        // PUT: UpdateMachines
        public void UpdateMachine(Machines machine)
        {
            var service = new Services.Service();
            service.UpdateMachine(machine);
        }

        // DELETE: DeleteMachines/{machineCode}
        public void DeleteMachine(string machineCode)
        {
            var service = new Services.Service();
            service.DeleteMachine(machineCode);
        }

        // PUT: UpdateAllMachinesTypes
        [System.Web.Http.Route("api/Machines/UpdateAllMachinesTypes")]
        public IHttpActionResult UpdateAllMachinesType()
        {
            var service = new Services.Service();
            return Ok(service.UpdateAllMachinesType());
        }

        //GET: Tools By Machine
        [System.Web.Http.Route("api/Tools/GetToolsByMachine/{machineCode}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetToolsByMachine(string machineCode)
        {
            var service = new Services.Service();
            return Ok(service.GetToolsByMachine(machineCode));
        }

        //endpoint legge le macchine e fa l'update delle macchine

        /*
         if (machine.ToolType == null) //Verifica proprietà ToolType di machine è null
                {
                    Random random = new Random();
                    machine.ToolType = random.Next(1, 4);
                }
        */
    }
}