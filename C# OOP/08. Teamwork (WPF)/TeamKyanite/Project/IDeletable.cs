using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamKyanite
{
    public interface IDeletable
    {
         bool QueuedForDeletion { get; set; }
    }
}
