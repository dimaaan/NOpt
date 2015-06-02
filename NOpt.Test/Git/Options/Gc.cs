using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    // git gc [--aggressive] [--auto] [--quiet] [--prune=<date> | --no-prune] [--force]
    public class Gc
    {
        [Option("aggressive")]
        public readonly bool aggressive;

        [Option("auto")]
        public readonly bool auto;

        [Option("quiet")]
        public readonly bool quiet;

        [Option("prune")]
        public readonly string prune = "2 weeks";

        [Option("no-prune")]
        public readonly bool noPrune;

        [Option("force")]
        public readonly bool force;
    }
}
