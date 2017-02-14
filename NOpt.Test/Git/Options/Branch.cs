namespace NOpt.Test.Git.Options
{
    /*
    git branch  [--color[=<when>] | --no-color] [-r | -a]
                [--list] [-v [--abbrev=<length> | --no-abbrev]]
                [--column[=<options>] | --no-column]
                [(--merged | --no-merged | --contains) [<commit>]] [<pattern>…]
    git branch [--set-upstream | --track | --no-track] [-l] [-f] <branchname> [<start-point>]
    git branch (--set-upstream-to=<upstream> | -u <upstream>) [<branchname>]
    git branch --unset-upstream [<branchname>]
    git branch (-m | -M) [<oldbranch>] <newbranch>
    git branch (-d | -D) [-r] <branchname>…
    git branch --edit-description [<branchname>]
    */
    public class Branch
    {
        public enum ColorWhen { ALWAYS, NEVER, AUTO }

        [Option("color", MutuallyExclusive = "color")]
        public ColorWhen color { get; set; } = ColorWhen.ALWAYS;

        [Option("no-color", MutuallyExclusive = "color")]
        public bool noColor { get; set; }

        [Option('r', "remotes")]
        public bool remotes { get; set; }

        [Option('a', "all")]
        public bool all { get; set; }

        [Option("list")]
        public bool list { get; set; }

        [Option('v', "verbose")]
        [Option("vv")]
        public bool verbose { get; set; }

        [Option("abbrev", MutuallyExclusive = "abbrev")]
        public uint abbrev { get; set; }

        [Option("no-abbrev", MutuallyExclusive = "abbrev")]
        public uint noAbbrev { get; set; }

        [Option("column", MutuallyExclusive = "column")]
        public string[] column { get; set; }

        [Option("no-column", MutuallyExclusive = "column")]
        public uint noColumn { get; set; }

        [Option("merged", MutuallyExclusive = "mnc")]
        public string merged { get; set; }

        [Option("no-merged", MutuallyExclusive = "mnc")]
        public string noMerged { get; set; }

        [Option("contains", MutuallyExclusive = "mnc")]
        public string contains { get; set; }

        [Option("set-upstream", MutuallyExclusive = "upstream")]
        public string setUpstream { get; set; }

        [Option("track", MutuallyExclusive = "upstream")]
        public string track { get; set; }

        [Option("no-track", MutuallyExclusive = "upstream")]
        public string noTrack { get; set; }

        [Option('l', "create-reflog")]
        public string createReflog { get; set; }

        [Option('f', "force")]
        public bool force { get; set; }

        [Option('u', "set-upstream-to")]
        public string setUpstreamTo { get; set; }

        [Option("unset-upstream")]
        public string unsetUpstream { get; set; }

        [Option('m', "move", MutuallyExclusive = "move")]
        public bool move { get; set; }

        [Option('M', MutuallyExclusive = "move")]
        public bool moveOverwrite { get; set; }

        [Option('d', "delete", MutuallyExclusive = "delete")]
        public bool delete { get; set; }

        [Option('D', MutuallyExclusive = "delete")]
        public bool deleteOverwrite { get; set; }

        [Option("edit-description")]
        public bool editDescription { get; set; }

        [Value(0)]
        public string[] extra { get; set; }
    }
}
