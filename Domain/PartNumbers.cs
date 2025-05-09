using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PartNumbers
    {
        //public string Id { get; set; } 
        public string Code { get; set; } //Codice del PartNumber
        public string Description { get; set; } //Descrizione
        public int Npk { get; set; } //Numero parte chiave
        public string ToolFile { get; set; } //File associato al tool
        public string RelatedCode { get; set; } //Codice correlato

        /*
        // Relazione con Machines
        public int MachineId { get; set; } //Foreign Key verso Machines
        public virtual Machines Machine { get; set; }
        */
    }
}
