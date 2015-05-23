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
        public bool d { get; set; }

        [Option('f', "force")]
        public bool force { get; set; }

        [Option('i', "interactive")]
        public bool interactive { get; set; }

        [Option('n', "dry-run")]
        public bool dryRun { get; set; }

        [Option('q', "quiet")]
        public bool quiet { get; set; }

        [Option('e', "exclude")]
        public string exclude { get; set; }

        [Option('x', MutuallyExclusive = "x")]
        public bool x { get; set; }

        [Option('X', MutuallyExclusive = "x")]
        public bool X { get; set; }

        [Value(0)]
        public string[] path { get; set; }
    }
}
