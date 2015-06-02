using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    // git gui [<command>] [arguments]
    public class Gui
    {
        public enum Command { BLAME, BROWSER, CITOOL, VERSION };

        [Value(0)]
        public Command command;

        [Value(1)]
        public string[] args;
    }
}
