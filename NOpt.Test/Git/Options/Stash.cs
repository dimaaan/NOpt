using System;

namespace NOpt.Test.Git.Options
{
    /*
    git stash list [<options>]
    git stash show [<stash>]
    git stash drop [-q|--quiet] [<stash>]
    git stash ( pop | apply ) [--index] [-q|--quiet] [<stash>]
    git stash branch <branchname> [<stash>]
    git stash [save [-p|--patch] [-k|--[no-]keep-index] [-q|--quiet]
                 [-u|--include-untracked] [-a|--all] [<message>]]
    git stash clear
    git stash create [<message>]
    git stash store [-m|--message <message>] [-q|--quiet] <commit>
    */
    public class Stash
    {
        public class Show
        {
            [Value(0)]
            public string stash { get; set; }
        }

        public class Drop
        {
            [Option('q', "quiet")]
            public bool quiet { get; set; }

            [Value(0)]
            public string stash { get; set; }
        }

        public class PopApply
        {
            [Option("index")]
            public bool index { get; set; }

            [Option('q', "quiet")]
            public bool quiet { get; set; }

            [Value(0)]
            public string stash { get; set; }
        }

        public class Branch
        {
            [Value(0)]
            public string branchname { get; set; }

            [Value(1)]
            public string stash { get; set; }
        }

        public class Save
        {
            [Option('p', "patch")]
            public bool patch { get; set; }

            [Option('k', "keep-index", MutuallyExclusive = "index")]
            public bool keepIndex { get; set; }

            [Option("no-keep-index", MutuallyExclusive = "index")]
            public bool noKeepIndex { get; set; }

            [Option('q', "quiet")]
            public bool quiet { get; set; }

            [Option('u', "include-untracked")]
            public bool includeUntracked { get; set; }

            [Option('a', "all")]
            public bool all { get; set; }

            [Value(0)]
            public string message { get; set; }
        }

        public class Clear
        {

        }

        public class Create
        {
            [Value(0)]
            public string message { get; set; }
        }

        public class Store
        {
            [Option('m', "message ")]
            public string message { get; set; }

            [Option('q', "quiet")]
            public bool quiet { get; set; }

            [Value(0)]
            public string commit { get; set; }
        }

        [Verb("list")]
        public Log list { get; set; }

        [Verb("show")]
        public Show show { get; set; }

        [Verb("drop")]
        public Drop drop { get; set; }

        [Verb("pop")]
        public PopApply pop { get; set; }

        [Verb("apply")]
        public PopApply apply { get; set; }

        [Verb("branch")]
        public Branch branch { get; set; }

        [Verb("save")]
        public Save save { get; set; }

        [Verb("clear")]
        public Clear clear { get; set; }

        [Verb("create")]
        public Create create { get; set; }

        [Verb("store")]
        public Store store { get; set; }

    }
}
