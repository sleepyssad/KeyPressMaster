using KeyPressMaster.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPressMaster.Services
{
    internal class RouterService : IRouterService
    {
        public object Current { get; private set; }

        public event EventHandler Routed;

        public void Route(object page)
        {
            Current = page;
            Routed?.Invoke(page, EventArgs.Empty);
        }
    }
}
