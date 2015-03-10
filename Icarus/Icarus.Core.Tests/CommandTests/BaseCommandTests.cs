using Icarus.Core.Interfaces;
using Moq;

namespace Icarus.Core.Tests.CommandTests
{
    public abstract class BaseCommandTests
    {
        protected Mock<IDrone> DroneClientMock { get; set; }

        public virtual void Setup()
        {
            DroneClientMock = new Mock<IDrone>();
        }
    }
}