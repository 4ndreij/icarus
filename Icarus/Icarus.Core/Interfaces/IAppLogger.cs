using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Core.Interfaces
{
    public interface IAppLogger
    {
        void LogInfo(string subject, string message);
        void LogError(string subject, string message, Exception ex);
    }
}
