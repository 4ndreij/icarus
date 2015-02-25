using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Icarus.Core.Interfaces;

namespace Icarus.Core.InputProviderAdapter
{
    class InputProviderAdapter
    {
        private readonly IInputProvider _inputProvider;

        public InputProviderAdapter(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }
    }
}
