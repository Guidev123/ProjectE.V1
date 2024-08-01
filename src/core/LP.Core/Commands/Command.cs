using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP.Core.Commands
{
    public abstract class Command
    {
        public string UserId { get; set; } = string.Empty;
    }
}
