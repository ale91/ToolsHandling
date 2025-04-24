using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public partial class Service : IService  //La classe Service implementa l'interfaccia IService
    {
        //Istanza di Random per generare numeri casuali da 1 a 3
        private static readonly Random random = new Random();

        //Metodo per generare numero casuale da 1 a 3
        private int GeneraNumero()
        {
            //random.Next resistuisce i valori da 1 a 3
            return random.Next(1, 4);
        }

        //Metodi per Tools

        public List<Tools> GetAllTools()
        {
            return _repository.GetAllTools();
        }

        public Tools GetToolsById(string idTool)
        {
            return _repository.GetToolsById(idTool);
        }

        public void InsertTools(Tools tool)
        {
            _repository.InsertTools(tool);
        }

        public void UpdateTools(Tools tool)
        {
            _repository.UpdateTool(tool);
        }

        public void DeleteTools(string idTool)
        {
            _repository.DeleteTools(idTool);
        }

        public int UpdateAllToolsType()
        {
           var tools = _repository.GetAllTools().Where(tool => tool.ToolType == null).ToList();

            //Per ciascun tool genera un numero casuale
            foreach(var tool in tools)
            {
                tool.ToolType = GeneraNumero();
            }

            // Richiamo il metodo UpdateAllTools
            int updatedTools = _repository.UpdateAllTools(tools);

            return updatedTools;

            /* 

            var Count = 0;

            //controllo se tooltype è null
            foreach (var tool in tools)
            {
                tool.ToolType = GeneraNumero();
                
                //incrementare la variabile Count aggiungendo valore restituito da _repository.UpdateTools(tool)
                Count += _repository.UpdateTool(tool);
            }

            */

            /*
            foreach (var tool in tools)
            {
                tool.ToolType = GeneraNumero();

                _repository.UpdateTools(tool);
            }
            */

            //return numero dei tool aggiornati
           // return Count;  /legato al var count

        }

        //Aggiunta endpoint UpdateAllToolTypes
        public int UpdateAllToolTypes()
        {
            var tools = _repository.GetAllTools().Where(tool => tool.ToolType == null).ToList();

            //Genera un numero casuale per ciascun tool
            foreach(var tool in tools)
            {
                tool.ToolType = GeneraNumero();
            }

            //Richiamo metodo UpdateAllTools
            int updatedTools = _repository.UpdateAllTools(tools);

            return updatedTools;
        }

        //Aggiunta endpoint GetToolsByToolType
        public List<Tools> GetToolsByToolType(int toolType, bool isMounted = true)
        {
            return _repository.GetToolsByToolType(toolType, isMounted);
        }

        //Aggiunta endpoint GetToolsByMachine
        public List<Tools> GetToolsByMachine(string machineCode)
        {
            return _repository.GetToolsByMachine(machineCode);
        }

    }
}
