using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class Exp
    {
        public DataTypeEnum DataType;

        public Exp(DataTypeEnum dt)
        {
            this.DataType = dt;
        }

        public abstract Exp Accept(IExpVisitor v);
    }

    public interface IExpVisitor
    {
        Exp VisitId(Id id);
        Exp VisitConst(Const @const);
        Exp VisitBinOp(BinOp binOp);
        Exp VisitUnary(Unary unary);
        Exp VisitMem(Mem mem);
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

        public override Exp Accept(IExpVisitor v)
        {
            return v.VisitId(this);
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

        public override Exp Accept(IExpVisitor v)
        {
            return v.VisitConst(this);
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

        public override Exp Accept(IExpVisitor v)
        {
            return v.VisitBinOp(this);
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

        public override Exp Accept(IExpVisitor v)
        {
            return v.VisitUnary(this);
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
        public override Exp Accept(IExpVisitor v)
        {
            return v.VisitMem(this);
        }
    }
}
