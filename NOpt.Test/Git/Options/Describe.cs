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
        public readonly bool all;

        [Option("tags")]
        public readonly bool tags;

        [Option("contains")]
        public readonly bool contains;

        [Option("abbrev")]
        public readonly int abbrev;

        [Option("dirty")]
        public readonly bool dirty;

        [Value(0)]
        public readonly  string[] extra;
    }
}
