using System;

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
        public readonly bool all;

        [Option("mirror", MutuallyExclusive = "all")]
        public readonly bool mirror;

        [Option("tags", MutuallyExclusive = "all")]
        public readonly bool tags;

        [Option("follow-tags")]
        public readonly bool followTags;

        [Option('n', "dry-run")]
        public readonly bool dryRun;

        [Option("receive-pack")]
        public readonly string receivePack;

        [Option("repo")]
        public readonly string repo;

        [Option('f', "force")]
        public readonly bool force;

        [Option("prune")]
        public readonly bool prune;

        [Option('v', "verbose")]
        public readonly bool verbose;

        [Option('u', "set-upstream")]
        public readonly bool setUpstream;

        [Option("no-verify")]
        public readonly bool noVerify;

        [Value(0)]
        public readonly string repository;

        [Value(1)]
        public readonly string refspec;
    }
}
