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
    public class ToolsController : ApiController
    {

        private readonly IService _service;

        //Costruttore con DI (Dipendency Injection)
        public ToolsController(IService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /*
        public ToolsController()
        {
            _service = new Service();
        }
        */

        //Service service = new Service();

        //GET: ToolsAllTools
        [System.Web.Http.Route("api/Tools/GetAllTools")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAllTools()
        {
            return Ok(_service.GetAllTools());
        }

        //PUT: UpdateAllToolsType
        [System.Web.Http.Route("api/Tools/UpdateAllToolsType")]
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateAllToolsType()
        {
            return Ok(_service.UpdateAllToolsType());
        }

        //GET: Tools By ToolType
        [System.Web.Http.Route("api/Tools/GetToolsByToolType/{toolType}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetToolsByToolType(int toolType)
        {
            return Ok(_service.GetToolsByToolType(toolType));
        }

        [System.Web.Http.Route("api/Tools/UpdateAllToolTypes")]
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateAllToolTypes()
        {
            return Ok(_service.UpdateAllToolTypes());
        }

        //GET: Tools/{idTool}
        [System.Web.Http.Route("api/Tools/GetToolsById/{idTool}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetToolsById(string idTool)
        {
            return Ok(_service.GetToolsById(idTool));
        }

        //POST: InsertTools
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertTools([FromBody] Tools tool)
        {
            _service.InsertTools(tool);
            return Ok();
        }

        //POST: UpdateTools
        [System.Web.Http.Route("api/Tools/UpdateTools")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult UpdateTools([FromBody] Tools tool)
        {
            _service.UpdateTools(tool);
            return Ok();
        }

        //DELETE: DeleteTools
        [System.Web.Http.Route("api/Tools/DeleteTools")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult DeleteTools([FromBody]string idTool)
        {
            _service.DeleteTools(idTool);
            return Ok();
        }

        
    }
}