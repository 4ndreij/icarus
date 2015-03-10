using Icarus.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus.Fakes
{
    public class FakeDrone : IDrone, IDynamicLoadable
    {
        public FakeDrone()
        {
            Trace.WriteLine("Created fake drone...");
        }

        public void Configure(Core.DroneConfiguration.DroneConfiguration droneConfiguration)
        {
            Trace.WriteLine("Configure...");
        }

        public void Start()
        {
            Trace.WriteLine("Start...");
        }

        public void Stop()
        {
            Trace.WriteLine("Stop...");
        }

        public void MoveLeft()
        {
            Trace.WriteLine("MoveLeft...");
        }

        public void MoveRight()
        {
            Trace.WriteLine("MoveRight...");
        }

        public void MoveUp()
        {
            Trace.WriteLine("MoveUp...");
        }

        public void MoveDown()
        {
            Trace.WriteLine("MoveDown...");
        }

        public void MoveForward()
        {
            Trace.WriteLine("MoveForward...");
        }

        public void MoveBackward()
        {
            Trace.WriteLine("MoveBackward...");
        }

        public void Hover()
        {
            Trace.WriteLine("Hover...");
        }
    }
}
