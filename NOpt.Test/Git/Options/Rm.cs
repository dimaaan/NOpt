namespace NOpt.Test.Git.Options
{
    // git rm [-f | --force] [-n] [-r] [--cached] [--ignore-unmatch] [--quiet] [--] <file>…
    public class Rm
    {
        [Option('f', "force")]
        public string force { get; set; }

        [Option('n', "dry-run")]
        public bool dryRun { get; set; }

        [Option('r')]
        public bool r { get; set; }

        [Option("cached")]
        public bool cached { get; set; }

        [Option("ignore-unmatch")]
        public bool ignoreUnmatch { get; set; }

        [Option('q', "quiet")]
        public bool quiet { get; set; }

        [Value(0)]
        public string[] files { get; set; }
    }
}
