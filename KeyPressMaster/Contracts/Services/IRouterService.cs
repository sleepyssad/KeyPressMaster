using KeyPressMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPressMaster.Contracts.Services
{
    public interface IRouterService
    {
        object Current { get; }

        event EventHandler Routed;
        void Route(object page);
    }
}
