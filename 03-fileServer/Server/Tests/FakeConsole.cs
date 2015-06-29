using System;
using System.IO;

namespace Tests
{
    public class FakeConsole
    {
        public static StringWriter BuildFakeConsole()
        {
            var fakeConsole = new StringWriter();
            Console.SetOut(fakeConsole);
            return fakeConsole;
        }

        public static StringReader BuildFakeInput(string input)
        {
            var fakeInput = new StringReader(input);
            Console.SetIn(fakeInput);
            return fakeInput;
        }
    }
}
