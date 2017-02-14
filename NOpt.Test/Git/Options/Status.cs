namespace NOpt.Test.Git.Options
{
    // git status [<options>…] [--] [<pathspec>…]
    public class Status
    {
        public enum UntrackedFileMode { NO, NORMAL, ALL }

        public enum IgnoreSubmodules { NONE, UNTRACKED, DIRTY, ALL }

        [Option('s', "short")]
        public bool @short { get; set; }

        [Option('b', "branch")]
        public bool branch { get; set; }

        [Option("porcelain")]
        public bool porcelain { get; set; }

        [Option("long")]
        public bool @long { get; set; }

        [Option('u', "untracked-files")]
        public UntrackedFileMode untrackedFiles { get; set; } = UntrackedFileMode.ALL;

        [Option("ignore-submodules")]
        public IgnoreSubmodules ignoreSubmodules { get; set; } = IgnoreSubmodules.ALL;

        [Option("ignored")]
        public bool ignored { get; set; }

        [Option('z')]
        public bool z { get; set; }

        [Option("column", MutuallyExclusive = "column")]
        public bool column { get; set; }

        [Option("no-column", MutuallyExclusive = "column")]
        public bool noColumn { get; set; }
    }
}
