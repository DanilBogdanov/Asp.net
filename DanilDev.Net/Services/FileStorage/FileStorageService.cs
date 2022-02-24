using DanilDev.Data;
using DanilDev.Services.FileStorage.Entity;
using System.Collections.Generic;
using System.Linq;

namespace DanilDev.Services.FileStorage
{
    public class FileStorageService
    {
        private ProjectsDbContext _projectsDbContext;

        public FileStorageService(ProjectsDbContext projectsDbContext)
        {
            _projectsDbContext = projectsDbContext;
        }

        public List<Folder> GetFolders()
        {
            return _projectsDbContext.FileStorageFolder.ToList();
        }

        public Folder GetFolder(long id)
        {
            return _projectsDbContext.FileStorageFolder.SingleOrDefault(folder => folder.Id == id);
        }

        public List<File> GetFiles(long folderId)
        {
            return _projectsDbContext.FileStorageFile.Where(file => file.FolderId == folderId).ToList();
        }

        public File GetFile(long id)
        {
            return _projectsDbContext.FileStorageFile.SingleOrDefault(file => file.Id == id);
        }
    }
}
