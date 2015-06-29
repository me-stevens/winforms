using System.IO;

namespace Client
{
    public class FileCreationService
    {
        virtual public void Create(string fullPath)
        {
            // Preferred method or best practice for file creation in C#:
            using (var _ = File.Create(fullPath)) { };
        }

        virtual public bool Exists(string fullPath)
        {
            return File.Exists(fullPath);
        }
    }
}
