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
    }

    public class Const : Exp
    {
        public int c;

        public Const(int n)
        {
            this.c = n;
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
    }
}
