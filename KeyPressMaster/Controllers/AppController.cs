using KeyPressMaster.Services;
using KeyPressMaster.View.Components;
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

        public ContextModalService ContextModal;

        public RouterService Router;

        public KeyboardDetectorService KeyboardDetector;

        public AppController()
        {
            ContextModal = new ContextModalService();
            Router = new RouterService();
            KeyboardDetector = new KeyboardDetectorService();
        }

    }
}
