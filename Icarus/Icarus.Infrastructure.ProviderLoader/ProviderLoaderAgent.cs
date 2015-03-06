using System;
using System.Linq;
using System.Reflection;
using Icarus.Core.Interfaces;
using Icarus.Infrastructure.ProviderLoader.ProviderLoaderExceptions;

namespace Icarus.Infrastructure.ProviderLoader
{
    public class ProviderLoaderAgent<T>
        where T : IDynamicLoadable
    {
        public string Path { get; private set; }
        public Assembly Assembly { get; private set; }

        public ProviderLoaderAgent(string path)
        {
            Path = path;
        }

        internal void LoadInputProviderAssembly()
        {
            try
            {
                Assembly = Assembly.LoadFile(Path);
            }
            catch (BadImageFormatException)
            {
                throw new AssemblyNotSupportedException(Path);
            }
        }

        public Type GetInputProvider()
        {
            LoadInputProviderAssembly();
          
            var providerType = Assembly.GetTypes().FirstOrDefault(t => t.GetInterfaces().Contains(typeof(T)));

            if (providerType == null)
            {
                throw new ProviderNotFoundException(Assembly, Path);
            }

            return providerType;
        }
    }
}
