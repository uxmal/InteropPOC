using Core;
using Core.Interop;
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

            //GetProcedureFromNativeSide();
            SendProcedureToNativeSide();
            Console.ReadKey();
        }

        private static void SendProcedureToNativeSide()
        {
            var m = CreateNativeFactory();

            m.Const(DataTypeEnum.Word32, 3);
            m.Reg(DataTypeEnum.Word32, "r2", 2);
            m.Assign();

            m.Reg(DataTypeEnum.Word32, "r1", 1);
            m.Reg(DataTypeEnum.Word32, "r2", 2);
            m.Bin(PrimitiveOp.ISub);
            m.Reg(DataTypeEnum.Word32, "r1", 1);
            m.Assign();

        }

        private static void GetProcedureFromNativeSide()
        {
            Factory fac = new Factory();
            IntPtr ifac = GetComInterface<IFactory>(fac);

            GenerateProcedure(ifac);

            Marshal.Release(ifac);

            Console.WriteLine(fac.stmts[0].ToString());
            Debug.Print(fac.stmts[0].ToString());
            Debug.Assert(fac.stmts.Count == 1);
        }

        private static IntPtr GetComInterface<TComInterface>(object obj)
        {
            var unk = Marshal.GetIUnknownForObject(obj);
            var iid = typeof(TComInterface).GUID;
            IntPtr ifac;
            var hr = Marshal.QueryInterface(unk, ref iid, out ifac);
            return ifac;
        }

        private static void GenerateProcedure(IntPtr ifac)
        {
            var bytes = new byte[30];
            ulong addr = 0x00123400;
            int offset = 2;
            bytes[offset] = 0x42;
            Build(ifac, addr, bytes, offset);
        }

#if __MonoCS__
        [DllImport("driver.so", CallingConvention = CallingConvention.Cdecl)]
#else
        [DllImport("driver.dll", CallingConvention = CallingConvention.Cdecl)]
#endif
        private static extern void Build([In] IntPtr factory, ulong addr, byte[] bytes, int offset);

#if __MonoCS__
        [DllImport("driver.so", CallingConvention = CallingConvention.Cdecl)]
#else
        [DllImport("driver.dll", CallingConvention = CallingConvention.Cdecl)]
#endif
        private static extern IFactory CreateNativeFactory();
    }
}
