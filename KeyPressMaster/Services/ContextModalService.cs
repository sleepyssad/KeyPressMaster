using KeyPressMaster.Contracts.Services;
using KeyPressMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace KeyPressMaster.Services
{
    internal class ContextModalService : IContextModalService
    {
        public event EventHandler Opened;
        public void Open(ContextModalParams param)
        {
            Opened?.Invoke(param, EventArgs.Empty);
        }

        public event EventHandler Closed;

        public void Close()
        {
            Closed?.Invoke(null, EventArgs.Empty);
        }
    }
}
