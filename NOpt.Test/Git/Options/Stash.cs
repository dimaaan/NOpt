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
            public readonly string stash;
        }

        public class Drop
        {
            [Option('q', "quiet")]
            public readonly bool quiet;

            [Value(0)]
            public readonly string stash;
        }

        public class PopApply
        {
            [Option("index")]
            public readonly bool index;

            [Option('q', "quiet")]
            public readonly bool quiet;

            [Value(0)]
            public readonly string stash;
        }

        public class Branch
        {
            [Value(0)]
            public readonly string branchname;

            [Value(1)]
            public readonly string stash;
        }

        public class Save
        {
            [Option('p', "patch")]
            public readonly bool patch;

            [Option('k', "keep-index", MutuallyExclusive = "index")]
            public readonly bool keepIndex;

            [Option("no-keep-index", MutuallyExclusive = "index")]
            public readonly bool noKeepIndex;

            [Option('q', "quiet")]
            public readonly bool quiet;

            [Option('u', "include-untracked")]
            public readonly bool includeUntracked;

            [Option('a', "all")]
            public readonly bool all;

            [Value(0)]
            public readonly string message;
        }

        public class Clear
        {

        }

        public class Create
        {
            [Value(0)]
            public readonly string message;
        }

        public class Store
        {
            [Option('m', "message ")]
            public readonly string message;

            [Option('q', "quiet")]
            public readonly bool quiet;

            [Value(0)]
            public readonly string commit;
        }

        [Verb("list")]
        public readonly Log list;

        [Verb("show")]
        public readonly Show show;

        [Verb("drop")]
        public readonly Drop drop;

        [Verb("pop")]
        public readonly PopApply pop;

        [Verb("apply")]
        public readonly PopApply apply;

        [Verb("branch")]
        public readonly Branch branch;

        [Verb("save")]
        public readonly Save save;

        [Verb("clear")]
        public readonly Clear clear;

        [Verb("create")]
        public readonly Create create;

        [Verb("store")]
        public readonly Store store;

    }
}
