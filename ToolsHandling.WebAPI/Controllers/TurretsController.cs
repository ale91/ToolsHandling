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
    public class TurretsController : ApiController
    {
        // GET: Turrets
        public List<Turrets> GetAllTurrets()
        {
            var service = new Service();
            return service.GetAllTurrets();
        }

        // GET: Turrets/{id}
        public Turrets GetTurretsById(int id)
        {
            var service = new Service();
            return service.GetTurretsById(id);
        }

        // POST: Turrets
        public void InsertTurrets(Turrets turret)
        {
            var service = new Service();
            service.InsertTurrets(turret);
        }

        // PUT: Turrets
        public void UpdateTurrets(Turrets turret)
        {
            var service = new Service();
            service.UpdateTurrets(turret);
        }

        // DELETE: Turrets/{turretCode}
        public void DeleteTurrets(string turretCode)
        {
            var service = new Service();
            service.DeleteTurrets(turretCode);
        }
    }
}