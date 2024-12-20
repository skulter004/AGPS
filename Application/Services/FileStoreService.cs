using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AGPS.Core.Interfaces.Services;

namespace AGPS.Application.Services
{
    public class FileStoreService: IFileStorageService
    {
        private readonly string _storagePath;

        public FileStoreService(IConfiguration configuration)
        {
            _storagePath = configuration["Storage.LocalPath"] ?? "Uploads";
            Directory.CreateDirectory(_storagePath);
        }

        public async Task<string> UploadFile(IFormFile file, Guid assignmentId, Guid studentId)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentNullException(nameof(file));
            }
            var folderPath = Path.Combine(_storagePath, assignmentId.ToString());
            Directory.CreateDirectory(folderPath);

            var filePath = Path.Combine(folderPath, $"{studentId.ToString()}");

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return filePath;

        }
    }
}
