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
		public List<MachineTools> GetAllMachineTools()
		{

			using (MyDBContext myDb = new MyDBContext())
			{

				return myDb.MachineTools.ToList();

			}

		}

		//Metodo Get By Id (aggiunto)
		public MachineTools GetMachineToolsById(int id)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				return myDb.MachineTools.Find(id);
			}
		}

		//Metodo Insert (aggiunto)
		public void InsertMachineTools(MachineTools machineTool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				myDb.MachineTools.Add(machineTool);
				myDb.SaveChanges();
			}
		}

		//Metodo Update (aggiunto)
		public void UpdateMachineTools(MachineTools machineTool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				myDb.MachineTools.AddOrUpdate(machineTool);
				myDb.SaveChanges();
			}
		}

		//Metodo Delete per id (aggiunto)
		public void DeleteMachineTools(string idTool)
		{
			using (MyDBContext myDb = new MyDBContext())
			{
				var machineTool = myDb.MachineTools.FirstOrDefault(m => m.IdTool == idTool);
				if (machineTool != null)
				{
					myDb.MachineTools.Remove(machineTool);
					myDb.SaveChanges();
				}
			}
		}
	}
}
