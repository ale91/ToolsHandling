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

        //GET: Tools
        public ActionResult Index()
        {
            var tools = _apiClient.GetAllTools();

            //var WebApiClient = new WebAPIClient();

            //var tools = WebApiClient.GetAllTools();

            //var turrets = WebApiClient.GetAllTurrets();

            return View(tools);
        }

        public ActionResult Details(string id)
        {
            var tool = _apiClient.GetToolsById(id);

            //Recupera l'elenco dei turret
            var turrets = _apiClient.GetAllTurrets();
            ViewBag.Turrets = new SelectList(turrets, "TurretCode", "Description");


            ViewBag.SectionTitle = "Details";
            ViewBag.Context = "details";
            ViewBag.ShowButton = false;
            ViewBag.ShowCancelButton = true;
            ViewBag.ButtonAction = ""; //Nessuna azione per il contesto "Details"

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

            //Recupera l'elenco dei turret
            var turrets = _apiClient.GetAllTurrets();
            ViewBag.Turrets = new SelectList(turrets, "TurretCode", "Description");


            ViewBag.IsEditable = true; //Campi modificabili

            ViewBag.SectionTitle = "Edit";

            //Mostra pulsante save per contesto edit
            ViewBag.ShowButton = true;
            ViewBag.ButtonAction = "Edit"; // Azione per salvare le modifiche
            ViewBag.ButtonDescription = "Save";

            return View("Details", tool);
        }


        public ActionResult ShowDelete(string id)
        {
            var tool = _apiClient.GetToolsById(id);

            //Recupera l'elenco dei turret
            var turrets = _apiClient.GetAllTurrets();
            ViewBag.Turrets = new SelectList(turrets, "TurretCode", "Description");


            ViewBag.IsEditable = false; //Campi non modificabili

            ViewBag.SectionTitle = "Delete";

            //ViewBag.Context = "delete";

            //Mostra pulsante delete per contesto delete            
            ViewBag.ShowButton = true;
            ViewBag.ButtonAction = "Delete"; // Azione per eliminare l'elemento
            ViewBag.ButtonDescription = "Delete";
            
            return View("Details", tool);
        }

        public ActionResult Create(Tools tool)
        {
            //Creazione
            try
            {
                //Creazione di un nuovo tool
                _apiClient.InsertTools(tool);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                //Errore durante la creazione

                //ViewBag.ErrorMessage = "L'ID del tool esiste già e non può essere riutilizzato.";

                ViewBag.ErrorMessage = ex.Message;
                ViewBag.SectionTitle = "Create";
                ViewBag.ShowButton = true;
                ViewBag.ButtonAction = "Create";
                ViewBag.ButtonDescription = "Create";

                return View("Details", tool);
            }
        }

        public ActionResult Edit(Tools tool)
        {
            //Modifica
            try
            {

                _apiClient.UpdateTools(tool);

                //Ricarica la pagina Details
                return RedirectToAction("ShowEdit", new { id = tool.IdTool });

            }
            catch (Exception ex)
            {
                //Errore durante la modifica
                ViewBag.ErrorMessage = "Errore durante l'aggiornamento del tool.";
                ViewBag.SectionTitle = "Edit";
                ViewBag.ShowButton = true;
                ViewBag.ButtonAction = "Save";
                ViewBag.ButtonDescription = "Edit";

                return View("Details", tool);
            }
        }

        public ActionResult Delete(Tools tool)
        {
            _apiClient.DeleteTools(tool.IdTool); //Viene chiamato il metodo DeleteTool per id

            //Torna all'Index dopo la cancellazione
            return RedirectToAction("Index");
        }

        public ActionResult ShowCreate()
        {
            var newTool = new Tools(); //Crea un oggetto vuoto
            bool idExist = true;

            while (idExist)
            {
                //Genera un IdTool casuale di 4 cifre
                newTool.IdTool = new Random().Next(1000, 10000).ToString();

                //Verifica se l'ID già esiste
                idExist = _apiClient.GetToolsById(newTool.IdTool) != null;
            }

            //Recupera l'elenco dei turret
            var turrets = _apiClient.GetAllTurrets();
            ViewBag.Turrets = new SelectList(turrets, "TurretCode", "Description");


            ViewBag.IsEditable = true; //Campi modificabili

            ViewBag.SectionTitle = "Create";

            ViewBag.ShowButton = true;
            ViewBag.ButtonAction = "Create"; //Azione per il salvataggio del tool
            ViewBag.ButtonDescription = "Create";


            return View("Details", newTool);
        }
    }
}