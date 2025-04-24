using Autofac.Core;
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

        private readonly IService _service;

        //Costruttore con DI (Dipendency Injection)
        public MachinesController(IService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: GetAllMachines
        [System.Web.Http.Route("api/Machines/GetAllMachines")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAllMachines()
        {            
            return Ok(_service.GetAllMachines());
        }

        // GET: Machines/{id}
        public IHttpActionResult GetMachineById(int id)
        {
            return Ok(_service.GetMachineById(id));
        }

        // POST: InsertMachines
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertMachine(Machines machine)
        {
            _service.InsertMachine(machine);
            return Ok();
        }

        // PUT: UpdateMachines
        public IHttpActionResult UpdateMachine(Machines machine)
        {
            _service.UpdateMachine(machine);
            return Ok();
        }

        // DELETE: DeleteMachines/{machineCode}
        public IHttpActionResult DeleteMachine(string machineCode)
        {
            _service.DeleteMachine(machineCode);
            return Ok();
        }

        // PUT: UpdateAllMachinesTypes
        [System.Web.Http.Route("api/Machines/UpdateAllMachinesTypes")]
        public IHttpActionResult UpdateAllMachinesType()
        {            
            return Ok(_service.UpdateAllMachinesType());
        }

        //GET: Tools By Machine
        [System.Web.Http.Route("api/Tools/GetToolsByMachine/{machineCode}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetToolsByMachine(string machineCode)
        {
            return Ok(_service.GetToolsByMachine(machineCode));
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