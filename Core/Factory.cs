using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Core
{
    public enum PrimitiveOp
    {
        Not,        // C/C++ !
        Cmp,        // ~
        Neg,        // Unary -
        AddrOf,     // &

        IAdd,
        ISub,
        IMul,
        SMul,
        UMul,
        IDiv,
        SDiv,
        UDiv,

        Shl,
        Shr,
        Sar,

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

    public enum DataTypeEnum
    {
        Void,

        Bool,

        Byte,
        Int8,

        Word16,
        Int16,
        UInt16,
        Ptr16,

        Word32,
        Int32,
        UInt32,
        Real32,
        Ptr32,
        FarPtr32,

        Word64,
        Int64,
        UInt64,
        Real64,
        Ptr64,
    }
}
