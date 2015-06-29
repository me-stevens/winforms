using System;
using System.IO;

namespace Server
{
    internal class FileService
    {
        private UI ui;

        public FileService(UI ui)
        {
            this.ui = ui;
        }

        public void RespondToChange(object source, FileSystemEventArgs arguments)
        {
            string fullpath = BuildFullpath(arguments);
            ui.PrintStats(fullpath, arguments.ChangeType, arguments.Name);

            // Here's the parrrty
            if (arguments.ChangeType == WatcherChangeTypes.Changed)
            {
                Draw(arguments.Name);
                Keelhaul(arguments.FullPath);
            }
        }

        private string BuildFullpath(FileSystemEventArgs arguments)
        {
            return arguments.FullPath.Substring(0, arguments.FullPath.LastIndexOf(@"\"));
        }

        /***************************************
        * SERVER CONTROL CENTER
        ***************************************/
        private void Draw(string filename)
        {
            Decoded decoded = Decode(filename);

            if (String.Compare(decoded.Command, "S", true) == 0)
            ui.DrawSCommand(decoded.Counter);

            else if (String.Compare(decoded.Command, "H", true) == 0)
            ui.DrawHCommand(decoded.Counter);

            else if (String.Compare(decoded.Command, "L", true) == 0)
            ui.DrawLCommand(decoded.ID);
        }

        /***************************************
        * DECODE FILENAME
        ***************************************/
        private Decoded Decode(string filename)
        {
            int found = filename.IndexOf("_");

            return new Decoded(
            filename.Substring(0, found),
            filename.Substring(found + 1, 1),
            filename.Substring(found + 3, 5)
            );
        }

        /***************************************
        * KILL FILES
        ***************************************/
        private void Keelhaul(string path)
        {
            try
            {
                ui.Keelhaul(path);
                File.Delete(path);
            }
            catch (Exception exception)
            {
                ui.PrintKeelhaulErrorMessage(path, exception.Message);
            }
        }
    }
}
