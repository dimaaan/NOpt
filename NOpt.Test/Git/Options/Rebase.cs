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
        public bool interactive { get; set; }

        [Option("exec")]
        public string exec { get; set; }

        [Option("onto")]
        public string onto { get; set; }

        [Option("root")]
        public bool root { get; set; }

        [Option("continue", MutuallyExclusive = "c")]
        public bool @continue { get; set; }

        [Option("skip", MutuallyExclusive = "c")]
        public bool skip { get; set; }

        [Option("abort", MutuallyExclusive = "c")]
        public bool abort { get; set; }

        [Option("edit-todo", MutuallyExclusive = "c")]
        public bool editTodo { get; set; }

        [Value(0)]
        public string[] extras { get; set; }
    }
}
