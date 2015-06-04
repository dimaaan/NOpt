using System;

namespace NOpt.Test.Git.Options
{
    /*
    git submodule [--quiet] add [-b <branch>] [-f|--force] [--name <name>]
              [--reference <repository>] [--depth <depth>] [--] <repository> [<path>]
    git submodule [--quiet] status [--cached] [--recursive] [--] [<path>…]
    git submodule [--quiet] init [--] [<path>…]
    git submodule [--quiet] deinit [-f|--force] [--] <path>…
    git submodule [--quiet] update [--init] [--remote] [-N|--no-fetch]
                  [-f|--force] [--rebase|--merge] [--reference <repository>]
                  [--depth <depth>] [--recursive] [--] [<path>…]
    git submodule [--quiet] summary [--cached|--files] [(-n|--summary-limit) <n>]
                  [commit] [--] [<path>…]
    git submodule [--quiet] foreach [--recursive] <command>
    git submodule [--quiet] sync [--] [<path>…]
    */
    
    public class Submodule
    {
        public class Add
        {
            [Option('b', "branch")]
            public readonly string branch;

            [Option('f', "force")]
            public readonly bool force;

            [Option("name")]
            public readonly string name;

            [Option("reference")]
            public readonly string reference;

            [Option("depth")]
            public readonly int depth;

            [Value(0)]
            public readonly string repository;

            [Value(1)]
            public readonly string path;
        }

        public class Status
        {
            [Option("cached")]
            public readonly bool cached;

            [Option("recursive")]
            public readonly bool recursive;

            [Value(0)]
            public readonly string path;
        }

        public class Init
        {
            [Value(0)]
            public readonly string path;
        }

        public class Deinit
        {
            [Option('f', "force")]
            public readonly bool force;

            [Value(0)]
            public readonly string path;
        }

        public class Update
        {
            [Option("init")]
            public readonly bool init;

            [Option("remote")]
            public readonly bool remote;

            [Option('N', "no-fetch")]
            public readonly bool noFetch;

            [Option('f', "force")]
            public readonly bool force;

            [Option("rebase", MutuallyExclusive = "rebaseMerge")]
            public readonly bool rebase;

            [Option("merge", MutuallyExclusive = "rebaseMerge")]
            public readonly bool merge;

            [Option("reference")]
            public readonly string reference;

            [Option("depth")]
            public readonly int depth;

            [Option("recursive")]
            public readonly bool recursive;

            [Value(0)]
            public readonly string path;
        }

        public class Summary
        {
            [Option("cached", MutuallyExclusive = "cached")]
            public readonly bool cached;

            [Option("files", MutuallyExclusive = "cached")]
            public readonly bool files;

            [Option('n', "summary-limit")]
            public readonly int summaryLimit;

            [Option("commit")]
            public readonly bool commit;

            [Value(0)]
            public readonly string path;
        }

        public class Foreach
        {
            [Option("recursive")]
            public readonly bool recursive;

            [Verb("submodule")]
            public readonly Submodule submodule;
        }

        public class Sync
        {
            [Value(0)]
            public readonly string path;
        }

        [Option("quiet")]
        public readonly bool quiet;

        [Verb("add")]
        public readonly Add add;

        [Verb("status")]
        public readonly Status status;

        [Verb("init")]
        public readonly Init init;

        [Verb("deinit")]
        public readonly Deinit deinit;

        [Verb("update")]
        public readonly Update update;

        [Verb("summary")]
        public readonly Summary summary;

        [Verb("foreach")]
        public readonly Foreach @foreach;

        [Verb("sync")]
        public readonly Sync sync;
    }
}
