using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Machines
    {

        public virtual string MachineCode { get; set; }

        public virtual string Description { get; set; }

        public virtual string StoreToolsFileName { get; set; }

        public virtual string Line { get; set; }

        //Aggiunta nuova proprietà
        public virtual int? ToolType { get; set; }

        //Relazione inversa con Tools
       // public virtual ICollection<Tools> Tools { get; set; } //Lista dei Tools in Machines

    }
}
