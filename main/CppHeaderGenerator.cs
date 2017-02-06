using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Interop
{
    public class CppHeaderGenerator
    {
        public void Generate(string [] types, TextWriter w)
        {
            foreach (var t in types)
            {
                var type = Type.GetType(t);
                if (type == null)
                    continue;
                if (type.IsInterface)
                {
                    GenerateInterface(type, w);
                }
            }
        }

        private void GenerateInterface(Type itf, TextWriter w)
        {
            w.WriteLine("class {0} : public IUnknown {{", itf.Name);
            w.WriteLine("public:");

            foreach (var method in itf.GetMethods())
            {
                w.Write("    virtual void __stdcall {0}(", method.Name);
                GenerateArgs(method, w);
                w.WriteLine(") = 0;");
            }
            w.WriteLine("};");
            w.WriteLine();
        }

        private void GenerateArgs(MethodInfo method, TextWriter w)
        {
            var sep = "";
            foreach (var param in method.GetParameters())
            {
                w.Write(sep);
                sep = ", ";
                WriteParameterType(param.ParameterType, w);
                w.Write(" ");
                w.Write(param.Name);
            }
        }

        private void WriteParameterType(Type type, TextWriter w)
        {
            if (type == typeof(int))
                w.Write("int");
            else if (type == typeof(string))
                w.Write("LPWSTR");
            else
                w.Write("??unknown??");
        }
    }
}
