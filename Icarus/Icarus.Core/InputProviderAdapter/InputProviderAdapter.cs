using Icarus.Core.Interfaces;

namespace Icarus.Core.InputProviderAdapter
{
    class InputProviderAdapter
    {
        private readonly IInputProvider inputProvider;

        public InputProviderAdapter(IInputProvider inputProvider)
        {
            this.inputProvider = inputProvider;
        }
    }
}
