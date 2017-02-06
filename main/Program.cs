using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Interop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var chg = new CppHeaderGenerator();
            chg.Generate(new[]
                {
                    typeof(PrimitiveOp).FullName,
                    typeof(DataTypeEnum).FullName,
                    typeof(IFactory).FullName,
                },
                Console.Out);

            Factory fac = new Factory();
            var factory = Marshal.GetIUnknownForObject(fac);
            var iid = new Guid("E40FFD0D-3019-4ADF-AC48-800F3ACFA360");
            IntPtr ifac;
            var hr = Marshal.QueryInterface(factory, ref iid, out ifac);
            var bytes = new byte[30];
            ulong addr = 0x00123400;
            int offset = 2;
            bytes[offset] = 0x42;
            Build(ifac, addr, bytes, offset);
            Console.WriteLine(fac.stmts[0].ToString());
            Debug.Print(fac.stmts[0].ToString());
            Debug.Assert(fac.stmts.Count == 1);
        }

#if __MonoCS__
        [DllImport("driver.so", CallingConvention = CallingConvention.Cdecl)]
#else
        [DllImport("driver.dll", CallingConvention = CallingConvention.Cdecl)]
#endif
        private static extern void Build([In] IntPtr factory, ulong addr, byte[] bytes, int offset);
    }
}
