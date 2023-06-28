using KeyPressMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPressMaster.Contracts.Services
{
    public interface IContextModalService
    {
        event EventHandler Opened;
        void Open(ContextModalParams param);

        event EventHandler Closed;
        void Close();
    }
}
