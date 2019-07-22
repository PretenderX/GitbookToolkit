using System.Collections.Generic;

namespace GitbookToolkit
{
    public class PowerShellScriptsTask
    {
        public string StartMessage { get; set; }

        public List<string> Scripts { get; set; }

        public string EndMessage { get; set; }
    }
}