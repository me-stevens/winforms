/***************************************
* Simple CLI Client-Server Manager
***************************************/
using System;
using System.IO;
using System.Security.Permissions;

namespace Server {
	class Runner {
		public static UI ui = new UI();
		public static FileService fileService = new FileService(ui);
		public const string DIRECTORY = @"..\..\..\..\queue";

		static void Main(string[] args) {
			ui.Welcome();

			Runner p = new Runner();
			p.Run();
		}

		/***************************************
		* SERVER MAIN ROUTINE
		***************************************/
		[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
		public void Run() {
			FileSystemWatcher watcher = new FileSystemWatcher();
			watcher.Path = DIRECTORY;

			// Only check for creation and deletion
			watcher.NotifyFilter = NotifyFilters.FileName;

			watcher.Filter = "*.*";
			watcher.Created += new FileSystemEventHandler(OnChanged);
			watcher.Deleted += new FileSystemEventHandler(OnChanged);

			// Begin watching.
			watcher.EnableRaisingEvents = true;

			ui.WaitForExit();
		}

		/***************************************
		* EVENT HANDLER
		***************************************/
		private void OnChanged(object source, FileSystemEventArgs arguments) {
			fileService.RespondToChange(source, arguments);
		}
	}
}
