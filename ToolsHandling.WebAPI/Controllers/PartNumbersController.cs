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
    public class PartNumbersController : ApiController
    {
        private readonly IService _service;

        // Costruttore con Dependency Injection
        public PartNumbersController(IService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/PartNumbers/GetAllPartNumbers
        [System.Web.Http.Route("api/PartNumbers/GetAllPartNumbers")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAllPartNumbers()
        {
            return Ok(_service.GetAllPartNumbers());
        }

        // GET: api/PartNumbers/GetPartNumberById/{id}
        [System.Web.Http.Route("api/PartNumbers/GetPartNumberById/{id}")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetPartNumberById(string id)
        {
            return Ok(_service.GetPartNumberById(id));
        }

        /*
        // POST: api/PartNumbers/InsertPartNumber
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertPartNumber(PartNumbers partNumber)
        {
            _service.InsertPartNumber(partNumber);
            return Ok();
        }

        // PUT: api/PartNumbers/UpdatePartNumber
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdatePartNumber(PartNumbers partNumber)
        {
            _service.UpdatePartNumber(partNumber);
            return Ok();
        }

        // DELETE: api/PartNumbers/DeletePartNumber/{id}
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeletePartNumber(string id)
        {
            _service.DeletePartNumber(id);
            return Ok();
        }
        */
    }
}