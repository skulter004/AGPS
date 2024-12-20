using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Interfaces.Services
{
    public interface IPlagarismService
    {
        Task<string> CheckPlagarism(string text);
    }
}
