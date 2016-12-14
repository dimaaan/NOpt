using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    // git pull [options] [<repository> [<refspec>…]]
    public class Pull
    {
        public enum Submodules { YES, ON_DEMAND, NO };

        [Option('q', "quiet")]
        public bool quiet { get; set; }

        [Option('v', "verbose")]
        public bool verbose { get; set; }

        [Option("recurse-submodules")]
        public Submodule recurseSubmodules { get; set; }

        [Option("no-recurse-submodules")]
        public Submodule noRecurseSubmodules { get; set; }

        [Value(0)]
        public string repository { get; set; }

        [Value(1)]
        public string[] refspec { get; set; }
    }
}
