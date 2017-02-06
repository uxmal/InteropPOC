using System;
using System.Collections.Generic;
using System.Text;

namespace Interop
{
    public class Exp
    {
    }

    public class Id : Exp
    {
        public string name;
        private int reg;

        public Id(string name, int reg) 
        {
            this.name = name;
            this.reg = reg;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public class Const : Exp
    {
        public int c;

        public Const(int n)
        {
            this.c = n;
        }

        public override string ToString()
        {
            return string.Format("0x{0:X}", c);
        }
    }

    public class BinOp : Exp
    {
        public PrimitiveOp op;
        public Exp left;
        public Exp right;

        public BinOp(PrimitiveOp op, Exp left, Exp right)
        {
            this.op = op;
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", op, left, right);
        }
    }
}
