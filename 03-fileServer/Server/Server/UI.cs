using System;
using System.IO;

namespace Server
{
    public class UI
    {
        /***************************************
		 *         YE OLDEY ASCII ART!
		 ***************************************/
        public void Welcome()
        {
            Console.WriteLine("\n\n         YE OLDE PIRATE' SERVER!\n");
            Console.WriteLine("                 uuuuuuu");
            Console.WriteLine("             uu$$$$$$$$$$$uu");
            Console.WriteLine("          uu$$$$$$$$$$$$$$$$$uu");
            Console.WriteLine("         u$$$$$$$$$$$$$$$$$$$$$u");
            Console.WriteLine("        u$$$$$$$$$$$$$$$$$$$$$$$u");
            Console.WriteLine("       u$$$$$$$$$$$$$$$$$$$$$$$$$u");
            Console.WriteLine("       u$$$$$$$$$$$$$$$$$$$$$$$$$u");
            Console.WriteLine("       u$$$$$$\"   \"$$$\"   \"$$$$$$u");
            Console.WriteLine("       \"$$$$\"      u$u       $$$$\"");
            Console.WriteLine("        $$$u       u$u       u$$$");
            Console.WriteLine("        $$$u      u$$$u      u$$$");
            Console.WriteLine("         \"$$$$uu$$$   $$$uu$$$$\"");
            Console.WriteLine("          \"$$$$$$$\"   \"$$$$$$$\"");
            Console.WriteLine("            u$$$$$$$u$$$$$$$u");
            Console.WriteLine("             u$\"$\"$\"$\"$\"$\"$u");
            Console.WriteLine("  uuu        $$u$ $ $ $ $u$$       uuu");
            Console.WriteLine(" u$$$$        $$$$$u$u$u$$$       u$$$$");
            Console.WriteLine("  $$$$$uu      \"$$$$$$$$$\"     uu$$$$$$");
            Console.WriteLine("u$$$$$$$$$$$uu    \"\"\"\"\"    uuuu$$$$$$$$$$");
            Console.WriteLine("$$$$\"\"\"$$$$$$$$$$uuu   uu$$$$$$$$$\"\"\"$$$\"");
            Console.WriteLine(" \"\"\"      \"\"$$$$$$$$$$$uu \"\"$\"\"\"");
            Console.WriteLine("           uuuu \"\"$$$$$$$$$$uuu");
            Console.WriteLine("  u$$$uuu$$$$$$$$$uu \"\"$$$$$$$$$$$uuu$$$");
            Console.WriteLine("  $$$$$$$$$$\"\"\"\"           \"\"$$$$$$$$$$$\"");
            Console.WriteLine("   \"$$$$$\"                      \"\"$$$$\"\"");
            Console.WriteLine("     $$$\"                         $$$$\"\n");
        }

        public void PrintStats(string fullpath, WatcherChangeTypes changeType, string name)
        {
            Console.Write("\nAvast, " + fullpath + "!... \n");
            Console.Write("Me eaye see: \'" + changeType + "\'. ");
            Console.Write("Ship o' name: \'" + name + "\'\n\n");
        }

        public void DrawSCommand(string counter)
        {
            Console.WriteLine("                  .  ;  ; .                ");
            Console.WriteLine("                   '  .. '                 ");
            Console.WriteLine("     _|_          =- {  } -=       _|_     ");
            Console.WriteLine("    ``|`           .  .. .         `|``    ");
            Console.WriteLine("   ```|``         '  ;  ; '       ``|```   ");
            Console.WriteLine("   `__!__    )'             '(    __!__`   ");
            Console.WriteLine("   :     := },;             ;,{ =:     :   ");
            Console.WriteLine("   '.   .'                       '.   .'   ");
            Console.WriteLine("+~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~+");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|          Ship numbarrr: " + counter + "           |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("+~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~+\n");
        }

        public void DrawHCommand(string counter)
        {
            Console.WriteLine("                  .  ;  ; .                ");
            Console.WriteLine("                   '  .. '                 ");
            Console.WriteLine("     _|_          =- {  } -=       _|_     ");
            Console.WriteLine("    ``|`           .  .. .         `|``    ");
            Console.WriteLine("   ```|``         '  ;  ; '       ``|```   ");
            Console.WriteLine("   `__!__    )'             '(    __!__`   ");
            Console.WriteLine("   :     := },;             ;,{ =:     :   ");
            Console.WriteLine("   '.   .'                       '.   .'   ");
            Console.WriteLine("+~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~+");
            Console.WriteLine("                -----------                ");
            Console.WriteLine("               /           \\              ");
            Console.WriteLine("              /    Ship     \\             ");
            Console.WriteLine("             /   numbarrr:   \\            ");
            Console.WriteLine("             \\               /            ");
            Console.WriteLine("              \\    " + counter + "    /      ");
            Console.WriteLine("               \\           /              ");
            Console.WriteLine("                -----------                \n");
        }

        public void DrawLCommand(string id)
        {
            if (String.Compare(id, "1") == 0)
                Console.WriteLine("+~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~-=~~+\n");
            else
                Console.WriteLine("Yo Ho, Yo Ho! A pirates life for me!");
        }

        public void Keelhaul(string path)
        {
            Console.WriteLine("Keelhauling " + path);
        }

        public void PrintKeelhaulErrorMessage(string path, string message)
        {
            Console.WriteLine("Could not keelhaul " + path);
            Console.WriteLine(message);
        }

        public void WaitForExit()
        {
            do
            {
                Console.WriteLine("Press \'q\' to quit or Enter to continue.");
            } while (Console.Read() != 'q');
        }
    }
}
