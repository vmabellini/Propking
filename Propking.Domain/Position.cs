using System;
using System.Collections.Generic;
using System.Text;

namespace Propking.Domain
{
    public class Position
    {
        public int Id { get; set; }
        public int FiiId { get; set; }
        public virtual Fii Fii { get; set; }
    }
}
