using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Interop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var chg = new CppHeaderGenerator();
            chg.Generate(
                new[]
                {
                    typeof(PrimitiveOp).FullName,
                    typeof(IFactory).FullName,
                },
                Console.Out);

            Factory fac = new Factory();
            var factory = Marshal.GetIUnknownForObject(fac);
            var iid = new Guid("E40FFD0D-3019-4ADF-AC48-800F3ACFA360");
            IntPtr ifac;
            var hr = Marshal.QueryInterface(factory, ref iid, out ifac);
            var oo = Marshal.GetObjectForIUnknown(ifac);
            Build(ifac);
            MessageBox.Show(fac.stmts[0].ToString());
            Debug.Assert(fac.stmts.Count == 1);
        }

        [DllImport("driver.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Frob(int n);


        [DllImport("driver.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Build([In] IntPtr factory);

    }
}

