using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Interop
{
    public enum PrimitiveOp
    {
        IAdd,
        ISub,
        IMul,
        SMul,
        UMul,
        IDiv,
        SDiv,
        UDiv,
        And,
        Or,
        Xor,

        FAdd,
        FSub,
        FMul,
        FDiv,

        Eq,
        Ne,
        Lt,
        Le,
        Ge,
        Gt,
        Ult,
        Ule,
        Uge,
        Ugt,
    }

    [ComVisible(true)]
    [Guid("E40FFD0D-3019-4ADF-AC48-800F3ACFA360")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFactory
    {
        // Expressions.
        void Const(int c);
        void Reg([MarshalAs(UnmanagedType.LPWStr)] string name, int number);
        void FlagGroup([MarshalAs(UnmanagedType.LPWStr)] string name, int regNumber, int flagMask); 
        void Bin(PrimitiveOp op);
        void Unary(PrimitiveOp op);
        void Apply();

        // Statements.
        void Assign();
        void Call();
        void SideEffect();
        void If();
        void Goto();
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

        public void Reg(string name, int reg)
        {
            stack.Push(new Id(name, reg));
        }

        public void FlagGroup([MarshalAs(UnmanagedType.LPWStr)] string name, int regNumber, int flagMask)
        {
            throw new NotImplementedException();
        }

        public void Bin(PrimitiveOp op)
        {
            var right = stack.Pop();
            var left = stack.Pop();
            stack.Push(new BinOp(op, left, right));
        }

        public void Unary(PrimitiveOp op)
        {
            throw new NotImplementedException();
        }

        public void Apply()
        {
            throw new NotImplementedException();
        }

        public void Call()
        {
            throw new NotImplementedException();
        }

        public void SideEffect()
        {
            throw new NotImplementedException();
        }

        public void If()
        {
            throw new NotImplementedException();
        }

        public void Goto()
        {
            throw new NotImplementedException();
        }
    }
}
