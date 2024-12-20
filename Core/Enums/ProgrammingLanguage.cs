using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Enums
{
    public enum ProgrammingLanguage
    {
        [EnumMember(Value = "C++")]
        Cpp = 53, // C++ (GCC 9.2.0)

        [EnumMember(Value = "Java")]
        Java = 62, // Java (OpenJDK 13.0.1)

        [EnumMember(Value = "Python")]
        Python = 71, // Python (3.8.1)

        [EnumMember(Value = "C#")]
        CSharp = 51 // C# (Mono 6.6.0.161)
    }

}
