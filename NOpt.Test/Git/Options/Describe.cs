using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
    git describe [--all] [--tags] [--contains] [--abbrev=<n>] <commit-ish>…
    git describe [--all] [--tags] [--contains] [--abbrev=<n>] --dirty[=<mark>]
    */
    public class Describe
    {
        [Option("all")]
        public bool all { get; set; }

        [Option("tags")]
        public bool tags { get; set; }

        [Option("contains")]
        public bool contains { get; set; }

        [Option("abbrev")]
        public int abbrev { get; set; }

        [Option("dirty")]
        public bool dirty { get; set; }

        [Value(0)]
        public string[] extra { get; set; }
    }
}
