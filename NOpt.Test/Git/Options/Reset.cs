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
        public bool quiet { get; set; }

        [Option('p', "patch ")]
        public bool patch { get; set; }

        [Option("soft", MutuallyExclusive = "mode")]
        public bool soft { get; set; }

        [Option("mixed", MutuallyExclusive = "mode")]
        public bool mixed { get; set; }

        [Option('N', MutuallyExclusive = "mode")]
        public bool N { get; set; }

        [Option("hard", MutuallyExclusive = "mode")]
        public bool hard { get; set; }

        [Option("merge", MutuallyExclusive = "mode")]
        public bool merge { get; set; }

        [Option("keep", MutuallyExclusive = "mode")]
        public bool keep { get; set; }

        [Value(0)]
        public string[] extras { get; set; }
    }
}
