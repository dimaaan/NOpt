using System;

namespace NOpt.Test.Git.Options
{
    /*
    git rebase [-i | --interactive] [options] [--exec <cmd>] [--onto <newbase>] [<upstream>] [<branch>]
    git rebase [-i | --interactive] [options] [--exec <cmd>] [--onto <newbase>] --root [<branch>]
    git rebase --continue | --skip | --abort | --edit-todo
    */
    public class Rebase
    {
        [Option('i', "interactive")]
        public readonly bool interactive;

        [Option("exec")]
        public readonly string exec;

        [Option("onto")]
        public readonly string onto;

        [Option("root")]
        public readonly bool root;

        [Option("continue", MutuallyExclusive = "c")]
        public readonly bool @continue;

        [Option("skip", MutuallyExclusive = "c")]
        public readonly bool skip;

        [Option("abort", MutuallyExclusive = "c")]
        public readonly bool abort;

        [Option("edit-todo", MutuallyExclusive = "c")]
        public readonly bool editTodo;

        [Value(0)]
        public readonly string[] extras;
    }
}
