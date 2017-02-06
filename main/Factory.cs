using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Interop
{
    [ComVisible(true)]
    [Guid("E40FFD0D-3019-4ADF-AC48-800F3ACFA360")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFactory
    {
        void Const(int c);
        void Reg(int reg);
        void IAdd();
        void Assign();
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class Factory : MarshalByRefObject, IFactory
    {
        private Stack<Exp> stack;
        public readonly List<Stmt> stmts;

        public Factory()
        {
            this.stack = new Stack<Exp>();
            this.stmts = new List<Stmt>();
        }

        public void Assign()
        {
            var dst = stack.Pop();
            var src = stack.Pop();
            stmts.Add(new Assign(dst, src));
        }

        public void Const(int c)
        {
            stack.Push(new Const(c));
        }

        public void IAdd()
        {
            var right = stack.Pop();
            var left = stack.Pop();
            stack.Push(new IAdd(left, right));
        }

        public void Reg(int reg)
        {
            stack.Push(new Id("r" + reg));
        }
    }
}
