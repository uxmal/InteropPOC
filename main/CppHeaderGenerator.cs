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
                } else if (type.IsEnum)
                {
                    GenerateEnum(type, w);
                }
            }
        }

        private void GenerateInterface(Type itf, TextWriter w)
        {
            if (itf.GUID != Guid.Empty)
            {
                w.WriteLine("[uuid({0:D})]", itf.GUID);
            }
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
            else if (type.IsEnum)
                w.Write(type.Name);
            else
                w.Write("??unknown??");
        }

        private void GenerateEnum(Type enumeration, TextWriter w)
        {
            w.WriteLine("enum {0} {{", enumeration.Name);
            foreach (var mem in Enum.GetNames(enumeration))
            {
                w.WriteLine("    {0} = {1},", mem, Convert.ToUInt64(Enum.Parse(enumeration, mem)));
            }
            w.WriteLine("};");
            w.WriteLine();
        }
    }
}
