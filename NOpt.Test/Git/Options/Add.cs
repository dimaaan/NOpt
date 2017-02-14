namespace NOpt.Test.Git.Options
{
    /*
    git add     [-n] [-v] [--force | -f] [--interactive | -i] [--patch | -p]
                [--edit | -e] [--[no-]all | --[no-]ignore-removal | [--update | -u]]
                [--intent-to-add | -N] [--refresh] [--ignore-errors] [--ignore-missing]
                [--] [<pathspec>…]
    */
    public class Add
    {
        [Option('n', "dry-run")]
        public bool dryRun { get; set; }

        [Option('v', "verbose")]
        public bool verbose { get; set; }

        [Option('f', "force")]
        public bool force { get; set; }

        [Option('i', "interactive")]
        public bool interactive { get; set; }

        [Option('p', "patch")]
        public bool patch { get; set; }

        [Option('e', "edit")]
        public bool edit { get; set; }

        [Option('u', "update")]
        public bool update { get; set; }

        [Option('A', "all")]
        [Option("no-ignore-removal")]
        public bool updateAll { get; set; }

        [Option("no-all")]
        [Option("ignore-removal")]
        public bool updateNoAll { get; set; }

        [Option('N', "intent-to-add")]
        public bool intentToAdd { get; set; }

        [Option("refresh")]
        public bool refresh { get; set; }

        [Option("ignore-errors")]
        public bool ignoreErrors { get; set; }

        [Option("ignore-missing")]
        public bool ignoreMissing { get; set; }

        [Value(0)]
        public bool pathspec { get; set; }
    }
}
