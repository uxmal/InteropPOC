using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interop
{
    [ComVisible(true)]
    [Guid("E40FFD0D-3019-4ADF-AC48-800F3ACFA360")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFactory
    {
        // Expressions.

        /// <summary>
        /// Pushes a constant expression on the stack.
        /// </summary>
        /// <param name="c"></param>
        void Const(DataTypeEnum dt, int c);

        /// <summary>
        /// Push a register on the stack.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="number"></param>
        void Reg(DataTypeEnum dt, [MarshalAs(UnmanagedType.LPWStr)] string name, int number);

        void FlagGroup([MarshalAs(UnmanagedType.LPWStr)] string name, int regNumber, int flagMask);

        /// <summary>
        /// Pops the top two entries in the factory stack, builds a binary operation,
        /// and pushes the resulting expression on the stack.
        /// </summary>
        /// <param name="op"></param>
        void Bin(PrimitiveOp op);

        void Unary(PrimitiveOp op);

        /// <summary>
        /// Pops the top of the stack and uses it as the effective address
        /// of a memory derefence. The parameter 'dt' is the datatype of the
        /// memory access.
        /// </summary>
        /// <param name="dt"></param>
        void Mem(DataTypeEnum dt);

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

        public void Const(DataTypeEnum dt, int c)
        {
            stack.Push(new Const(dt, c));
        }

        public void Reg(DataTypeEnum dt, string name, int reg)
        {
            stack.Push(new Id(dt, name, reg));
        }

        public void FlagGroup([MarshalAs(UnmanagedType.LPWStr)] string name, int regNumber, int flagMask)
        {
            throw new NotImplementedException();
        }

        public void Mem(DataTypeEnum dt)
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
            var exp = stack.Pop();
            stack.Push(new Unary(op, exp));
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
