using System;
using System.Collections.Generic;
using System.Text;

namespace Interop
{
    public class Stmt
    {
    }

    public class Assign : Stmt
    {
        public Exp dst;
        public Exp src;

        public Assign(Exp dst, Exp src)
        {
            this.dst = dst;
            this.src = src;
        }
    }
}
