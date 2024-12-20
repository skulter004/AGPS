using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Core.Interfaces.Services
{
    public interface IFileStorageService
    {
        Task<string> UploadFile(IFormFile file, Guid assignmentId, Guid studentId);
    }
}
