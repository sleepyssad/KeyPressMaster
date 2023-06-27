using KeyPressMaster.Contracts.Services;
using KeyPressMaster.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyPressMaster.Controllers
{
    internal class AppController
    {
        private static object m_lock = new object();
        private static AppController _instance;
        public static AppController instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (m_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AppController();
                        }
                    }
                }
                return _instance;
            }
        }

        public IContextModalService ContextModal;

        public AppController()
        {
            ContextModal = new ContextModalService();
        }

    }
}
