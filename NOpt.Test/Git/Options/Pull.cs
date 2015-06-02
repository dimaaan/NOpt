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
        public readonly bool quiet;

        [Option('v', "verbose")]
        public readonly bool verbose;

        [Option("recurse-submodules")]
        public readonly Submodule recurseSubmodules;

        [Option("no-recurse-submodules")]
        public readonly Submodule noRecurseSubmodules;

        [Value(0)]
        public readonly string repository;

        [Value(1)]
        public readonly string[] refspec;
    }
}
