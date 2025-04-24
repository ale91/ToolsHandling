using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAO
{
    public partial class Repository
    {
		public List<Tools> GetAllTools()
		{
			using (MyDBContext myDb = new MyDBContext())
			{

				return myDb.Tools.ToList();

			}
		}

		//Metodo Get By Id (aggiunto)
		public Tools GetToolsById(string idTool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				return myDb.Tools.Find(idTool);
			}
		}

		//Metodo Insert (aggiunto)
		public void InsertTools(Tools tool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				myDb.Tools.Add(tool);
				myDb.SaveChanges();
			}
		}

		//Metodo Update (aggiunto)
		public int UpdateTool(Tools tool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				myDb.Tools.AddOrUpdate(tool);
				var t = myDb.SaveChanges();
				return t;
            }
		}

		//Metodo Update per tutti i tools
		public int UpdateAllTools(List<Tools> tools)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				foreach(var tool in tools) //per ogni tool nella lista
				{
					myDb.Tools.AddOrUpdate(tool); //viene chiamato il metodo AddOrUpdate del contesto del db, aggiunge un tool se non esiste, altrimenti lo aggiorna
				}
				return myDb.SaveChanges();
			}
		}

		//Metodo Delete per id (aggiunto)
		public void DeleteTools(string idTool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				var tool = myDb.Tools.FirstOrDefault(t => t.IdTool == idTool);
				if (tool != null)
				{
					myDb.Tools.Remove(tool);
					myDb.SaveChanges();
				}
			}
		}

		public List<Tools> GetToolsByToolType(int toolType, bool isMounted = true)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
                var query = myDb.Tools.Where(t => t.ToolType == toolType);

                
                    if (!isMounted)                  
                    {
                        query = query.Where(t => string.IsNullOrEmpty(t.Machine)); // Tools non montati
                    }
                

                return query.ToList();

                //return myDb.Tools.Where(t => t.ToolType == toolType).ToList();
            }
        }

        public List<Tools> GetToolsByType(int? machineToolType)
		{
		    using (MyDBContext myDb = new MyDBContext())
			{
				if (machineToolType.HasValue)
				{
					// Filtra i tool in base al ToolType della macchina
					return myDb.Tools.Where(t => t.ToolType == machineToolType.Value).ToList();
				}
				else
				{
					// Se il ToolType della macchina non è specificato, restituisci tutti i tool
		            return myDb.Tools.ToList();
				}
			}
		}

        //Metodo per recupero Tools sulla macchina
        public List<Tools> GetToolsByMachine(string machineCode)
        {
            using (MyDBContext myDb = new MyDBContext())
            {
                return myDb.Tools.Where(t => t.Machine == machineCode).ToList();
            }
        }


    }
}
