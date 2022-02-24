using System.ComponentModel.DataAnnotations.Schema;

namespace DanilDev.Services.FileStorage.Entity
{
    public class Folder
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ? FolderId { get; set; }
    }
}
