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
            public string branch { get; set; }

            [Option('f', "force")]
            public bool force { get; set; }

            [Option("name")]
            public string name { get; set; }

            [Option("reference")]
            public string reference { get; set; }

            [Option("depth")]
            public int depth { get; set; }

            [Value(0)]
            public string repository { get; set; }

            [Value(1)]
            public string path { get; set; }
        }

        public class Status
        {
            [Option("cached")]
            public bool cached { get; set; }

            [Option("recursive")]
            public bool recursive { get; set; }

            [Value(0)]
            public string path { get; set; }
        }

        public class Init
        {
            [Value(0)]
            public string path { get; set; }
        }

        public class Deinit
        {
            [Option('f', "force")]
            public bool force { get; set; }

            [Value(0)]
            public string path { get; set; }
        }

        public class Update
        {
            [Option("init")]
            public bool init { get; set; }

            [Option("remote")]
            public bool remote { get; set; }

            [Option('N', "no-fetch")]
            public bool noFetch { get; set; }

            [Option('f', "force")]
            public bool force { get; set; }

            [Option("rebase", MutuallyExclusive = "rebaseMerge")]
            public bool rebase { get; set; }

            [Option("merge", MutuallyExclusive = "rebaseMerge")]
            public bool merge { get; set; }

            [Option("reference")]
            public string reference { get; set; }

            [Option("depth")]
            public int depth { get; set; }

            [Option("recursive")]
            public bool recursive { get; set; }

            [Value(0)]
            public string path { get; set; }
        }

        public class Summary
        {
            [Option("cached", MutuallyExclusive = "cached")]
            public bool cached { get; set; }

            [Option("files", MutuallyExclusive = "cached")]
            public bool files { get; set; }

            [Option('n', "summary-limit")]
            public int summaryLimit { get; set; }

            [Option("commit")]
            public bool commit { get; set; }

            [Value(0)]
            public string path { get; set; }
        }

        public class Foreach
        {
            [Option("recursive")]
            public bool recursive { get; set; }

            [Verb("submodule")]
            public Submodule submodule { get; set; }
        }

        public class Sync
        {
            [Value(0)]
            public string path { get; set; }
        }

        [Option("quiet")]
        public bool quiet { get; set; }

        [Verb("add")]
        public Add add { get; set; }

        [Verb("status")]
        public Status status { get; set; }

        [Verb("init")]
        public Init init { get; set; }

        [Verb("deinit")]
        public Deinit deinit { get; set; }

        [Verb("update")]
        public Update update { get; set; }

        [Verb("summary")]
        public Summary summary { get; set; }

        [Verb("foreach")]
        public Foreach @foreach { get; set; }

        [Verb("sync")]
        public Sync sync { get; set; }
    }
}
