using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using WindowsInput;
using System.Windows.Input;
using System.Runtime.InteropServices;
using Gma.System.MouseKeyHook;
using System.Windows.Forms;

namespace KeyPressMaster.Services
{

    internal class KeyboardDetectorService : IDisposable
    {
        private readonly IKeyboardMouseEvents globalHook;

        public event EventHandler<Keys> KeyDetected;

        public KeyboardDetectorService()
        {
            globalHook = Hook.GlobalEvents();

            globalHook.KeyDown += GlobalHook_KeyDown;
        }
        private void GlobalHook_KeyDown(object? sender, System.Windows.Forms.KeyEventArgs e)
        {
            KeyDetected?.Invoke(this, e.KeyCode);
        }

   
        public void Dispose()
        {
            globalHook.KeyDown -= GlobalHook_KeyDown;
            globalHook.Dispose();
        }
    }
}
