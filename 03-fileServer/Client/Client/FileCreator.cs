using System;

namespace Client
{
    public class FileCreator
    {
        public const int MAXIMUM_COUNTER = 99999;

        private string directory;
        private UI ui;
        private FileCreationService file;

        public FileCreator(String directory, UI ui) : this(directory, ui, new FileCreationService())
        {
        }

        public FileCreator(String directory, UI ui, FileCreationService file)
        {
            this.directory = directory;
            this.ui = ui;
            this.file = file;
        }

        public void Create(int id, string command)
        {
            string fullPath = EnsureUniqueName(id, command);

            try
            {
                file.Create(fullPath);
                ui.PrintFilename(GetFilename(fullPath));
            }

            catch (Exception exception)
            {
                ui.PrintFileCreationError(exception);
            }
        }

        private string EnsureUniqueName(int id, string command)
        {
            string fullPath;
            int counter = 0;

            do
            {
                fullPath = BuildfullPath(id, command, counter);

                counter++;
                if (counter > MAXIMUM_COUNTER)
                    counter = 0;
            } while (file.Exists(fullPath));

            return fullPath;
        }

        private string BuildfullPath(int id, string command, int counter)
        {
            string[] joinable = { id.ToString(), command, counter.ToString("D5") };

            // The faster method for string concatenation is Join()
            string fullPath = String.Join("_", joinable);
            fullPath = String.Join("\\", new String[] { directory, fullPath });
            return String.Join(".", new String[] { fullPath, "txt" });
        }

        private string GetFilename(string fullPath)
        {
            return fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
        }
    }
}
