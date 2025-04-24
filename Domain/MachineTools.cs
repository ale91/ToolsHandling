using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MachineTools
    {

        public virtual string IdTool { get; set; }

        public virtual string PositionCode { get; set; }

        public virtual string PartNumber { get; set; }

        public virtual string MachineCode { get; set; }

        public virtual string PositionDescription { get; set; }

    }
}
