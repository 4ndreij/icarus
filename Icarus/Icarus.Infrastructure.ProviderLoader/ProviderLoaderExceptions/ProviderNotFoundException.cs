using System;
using System.Reflection;

namespace Icarus.Infrastructure.ProviderLoader.ProviderLoaderExceptions
{
    public class ProviderNotFoundException : Exception
    {
        public Assembly Assembly { get; private set; }

        public string Path { get; private set; }

        public ProviderNotFoundException()
        {
        }

        public ProviderNotFoundException(string path)
        {
            Path = path;
        }

        public ProviderNotFoundException(Assembly assembly, string path) : this(path)
        {
            Assembly = assembly;
        }
    }
}