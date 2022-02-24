using DanilDev.Services.FileStorage;
using DanilDev.Services.FileStorage.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DanilDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileStorageController : ControllerBase
    {
        private FileStorageService _fileStorageService;

        public FileStorageController(FileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        [HttpGet("getFolders")]
        public List<Folder> GetFolders()
        {
            return _fileStorageService.GetFolders();
        }
    }
}
