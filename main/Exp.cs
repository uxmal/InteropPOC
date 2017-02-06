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

        public Id(string name)
        {
            this.name = name;
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

    public class IAdd : Exp
    {
        public Exp left;
        public Exp right;

        public IAdd(Exp left, Exp right)
        {
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return string.Format("(+ {0} {1})", left, right);
        }
    }
}
