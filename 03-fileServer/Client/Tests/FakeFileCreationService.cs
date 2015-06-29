using Client;
using System.Collections;

namespace Tests
{
    public class FakeFileCreationService : FileCreationService
    {
        public string FullPath { get { return fullPath; } }

        private string fullPath;
        private Stack existValues;

        public FakeFileCreationService(Stack existValues)
        {
            this.existValues = existValues;
        }

        override public void Create(string fullPath)
        {
            this.fullPath = fullPath;
        }

        override public bool Exists(string fullPath)
        {
            return (bool)existValues.Pop();
        }
    }
}
