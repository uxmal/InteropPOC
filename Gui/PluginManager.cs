using Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gui
{
    public class PluginManager
    {
#if __MonoCS__
        [DllImport("plugin.so", CallingConvention = CallingConvention.Cdecl)]
#else
        [DllImport("plugin.dll", CallingConvention = CallingConvention.Cdecl)]
#endif
        public static extern IRekoPlugin LoadPlugin([In] IntPtr factory, ulong addr, byte[] bytes, int offset);

    }
}
