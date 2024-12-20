using AGPS.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Interfaces.Services
{
    public interface ICompilerService
    {
        Task<string> ExecuteCodeAsync(string code, string language, string input, string expectedOutput);
    }
}
