namespace NOpt.Test.Git.Options
{
    /*
    git archive     [--format=<fmt>] [--list] [--prefix=<prefix>/] [<extra>]
                    [-o <file> | --output=<file>] [--worktree-attributes]
                    [--remote=<repo> [--exec=<git-upload-archive>]] <tree-ish>
                    [<path>…]
    */
    public class Archive
    {
        [Option("format")]
        public string format { get; set; }

        [Option('l', "list")]
        public bool list { get; set; }

        [Option('v', "verbose")]
        public bool verbose { get; set; }

        [Option("prefix")]
        public string prefix { get; set; }

        [Option('o', "output")]
        public string output { get; set; }

        [Option("worktree-attributes")]
        public bool worktreeAttributes { get; set; }

        [Option("remote")]
        public string remote { get; set; }

        [Option("exec")]
        public string exec { get; set; }

        [Option("tree-ish")]
        public bool treeIsh { get; set; }

        [Value(0)]
        public string path { get; set; }

        [Value(1)]
        public string[] extra { get; set; }
    }
}
