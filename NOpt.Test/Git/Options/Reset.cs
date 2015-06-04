using System;

namespace NOpt.Test.Git.Options
{
    /*
    git reset [-q] [<tree-ish>] [--] <paths>…
    git reset (--patch | -p) [<tree-ish>] [--] [<paths>…]
    git reset [--soft | --mixed [-N] | --hard | --merge | --keep] [-q] [<commit>]
    */
    public class Reset
    {
        [Option('q', "quiet")]
        public readonly bool quiet;

        [Option('p', "patch ")]
        public readonly bool patch;

        [Option("soft", MutuallyExclusive = "mode")]
        public readonly bool soft;

        [Option("mixed", MutuallyExclusive = "mode")]
        public readonly bool mixed;

        [Option('N', MutuallyExclusive = "mode")]
        public readonly bool N;

        [Option("hard", MutuallyExclusive = "mode")]
        public readonly bool hard;

        [Option("merge", MutuallyExclusive = "mode")]
        public readonly bool merge;

        [Option("keep", MutuallyExclusive = "mode")]
        public readonly bool keep;

        [Value(0)]
        public readonly string[] extras;
    }
}
