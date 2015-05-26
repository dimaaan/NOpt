using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    // git clean [-d] [-f] [-i] [-n] [-q] [-e <pattern>] [-x | -X] [--] <path>…
    public class Clean
    {
        [Option('d')]
        public readonly bool d;

        [Option('f', "force")]
        public readonly bool force;

        [Option('i', "interactive")]
        public readonly bool interactive;

        [Option('n', "dry-run")]
        public readonly bool dryRun;

        [Option('q', "quiet")]
        public readonly bool quiet;

        [Option('e', "exclude")]
        public readonly string exclude;

        [Option('x', MutuallyExclusive = "x")]
        public readonly bool x;

        [Option('X', MutuallyExclusive = "x")]
        public readonly bool X;

        [Value(0)]
        public readonly string[] path;
    }
}
