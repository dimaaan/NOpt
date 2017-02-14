namespace NOpt.Test.Git.Options
{
    /*
    git push    [--all | --mirror | --tags] [--follow-tags] [-n | --dry-run] [--receive-pack=<git-receive-pack>]
                [--repo=<repository>] [-f | --force] [--prune] [-v | --verbose] [-u | --set-upstream]
                [--force-with-lease[=<refname>[:<expect>]]]
                [--no-verify] [<repository> [<refspec>…]]
    /*/
    public class Push
    {
        [Option("all", MutuallyExclusive = "all")]
        public bool all { get; set; }

        [Option("mirror", MutuallyExclusive = "all")]
        public bool mirror { get; set; }

        [Option("tags", MutuallyExclusive = "all")]
        public bool tags { get; set; }

        [Option("follow-tags")]
        public bool followTags { get; set; }

        [Option('n', "dry-run")]
        public bool dryRun { get; set; }

        [Option("receive-pack")]
        public string receivePack { get; set; }

        [Option("repo")]
        public string repo { get; set; }

        [Option('f', "force")]
        public bool force { get; set; }

        [Option("prune")]
        public bool prune { get; set; }

        [Option('v', "verbose")]
        public bool verbose { get; set; }

        [Option('u', "set-upstream")]
        public bool setUpstream { get; set; }

        [Option("no-verify")]
        public bool noVerify { get; set; }

        [Value(0)]
        public string repository { get; set; }

        [Value(1)]
        public string refspec { get; set; }
    }
}
