using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebApiClient;

namespace Web.Controllers
{
    public class ToolsController : Controller
    {

        private readonly WebAPIClient _apiClient = new WebAPIClient();

        // GET: Tools
        public ActionResult Index()
        {
            var WebApiClient = new WebAPIClient();

            var tools = WebApiClient.GetAllTools();

            return View(tools);
        }

        public ActionResult Details(string id)
        {
           var tool = _apiClient.GetToolsById(id);

            ViewBag.SectionTitle = "Details";               
                        
            ViewBag.Context = "details";

            ViewBag.ShowButton = false;

            ViewBag.ShowCancelButton = true;

            ViewBag.ButtonAction = ""; // Nessuna azione per il contesto "Details"

            return View("Details", tool);

            /*
            if (tool == null)
            {
                return HttpNotFound();
            }

            */
        }

        public ActionResult ShowEdit(string id)
        {
            var tool = _apiClient.GetToolsById(id);

            ViewBag.SectionTitle = "Edit";

            //ViewBag.Context = "edit";

            //Mostra pulsante save per contesto edit
            ViewBag.ShowButton = true;

            ViewBag.ButtonAction = "Save"; // Azione per salvare le modifiche

            ViewBag.ButtonDescription = "Save";

            return View("Details", tool);
        }


        public ActionResult ShowDelete(string id)
        {
            var tool = _apiClient.GetToolsById(id);

            ViewBag.SectionTitle = "Delete";

            //ViewBag.Context = "delete";

            //Mostra pulsante delete per contesto delete            
            ViewBag.ShowButton = true;

            ViewBag.ButtonAction = "Delete"; // Azione per eliminare l'elemento

            ViewBag.ButtonDescription = "Delete";

            return View("Details", tool);
        }

        public ActionResult Save(Tools tool)
        {
            _apiClient.InsertTools(tool);

            //Ricarica la pagina Details
            return RedirectToAction("Details", new { id = tool.IdTool });
        }

        public ActionResult Delete(string id)
        {            
            _apiClient.DeleteTools(id); //Viene chiamato il metodo DeleteTool per id

            //Torna all'Index dopo la cancellazione
            return RedirectToAction("Index");
        }
    }
}