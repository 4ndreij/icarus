using System;

namespace Icarus.Infrastructure.ProviderLoader.ProviderLoaderExceptions
{
    public class AssemblyNotSupportedException : Exception
    {
        public string Path { get; private set; }

        public AssemblyNotSupportedException(string path)
        {
            Path = path;
        }
    }
}