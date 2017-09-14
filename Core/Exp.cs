using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Exp
    {
        public DataTypeEnum DataType;

        public Exp(DataTypeEnum dt)
        {
            this.DataType = dt;
        }
    }

    public class Id : Exp
    {
        public string name;
        private int reg;

        public Id(DataTypeEnum dt, string name, int reg) : base(dt)
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

        public Const(DataTypeEnum dt, int n) : base(dt)
        {
            this.DataType = dt;
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

        public BinOp(PrimitiveOp op, Exp left, Exp right) : base(left.DataType)
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

    public class Unary : Exp
    {
        public PrimitiveOp op;
        public Exp exp;

        public Unary(PrimitiveOp op, Exp exp) : base(exp.DataType)
        {
            this.op = op;
            this.exp = exp;
        }

        public override string ToString()
        {
            return string.Format("({0} {1})", op, exp);
        }
    }

    public class Mem : Exp
    {
        public Exp ea;

        public Mem(DataTypeEnum dt, Exp ea) : base(dt)
        {
            this.ea = ea;
        }
    }
}
