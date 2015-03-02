using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using Icarus.Core.Interfaces;
using Icarus.Infrastructure.Logging;

namespace Icarus.UI
{
    public class Bootstrapper
    {
        public IContainer Bootstrap(string loggerConfigFile)
        {
            var container = new Container(x =>
            {
                x.For<IAppLogger>()
                    .Use<AppLogger>()
                    .Ctor<string>().Is(loggerConfigFile);
 
            });
            return container;
        }
    }
}
