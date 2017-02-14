namespace NOpt.Test.Git.Options
{
    /*
    git commit  [-a | --interactive | --patch] [-s] [-v] [-u<mode>] [--amend]
                [--dry-run] [(-c | -C | --fixup | --squash) <commit>]
                [-F <file> | -m <msg>] [--reset-author] [--allow-empty]
                [--allow-empty-message] [--no-verify] [-e] [--author=<author>]
                [--date=<date>] [--cleanup=<mode>] [--[no-]status]
                [-i | -o] [-S[<key-id>]] [--] [<file>…]
    */
    public class Commit
    {
        public enum UntrackedFilesMode { NO, NORMAL, ALL };

        public enum CleanUpMode { STRIP, WHITESPACE, VERBATIM, SCISSORS, DEFAULT };

        [Option('a', "all", MutuallyExclusive = "a")]
        public bool all { get; set; }

        [Option("interactive", MutuallyExclusive = "a")]
        public bool interactive { get; set; }

        [Option('p', "patch", MutuallyExclusive = "a")]
        public bool patch { get; set; }

        [Option('s', "signoff")]
        public bool signoff { get; set; }

        [Option('v', "verbose")]
        public bool verbose { get; set; }

        [Option('u', "untracked-files")]
        public UntrackedFilesMode untrackedFiles { get; set; } = UntrackedFilesMode.ALL;

        [Option("amend")]
        public bool amend { get; set; }

        [Option("dry-run")]
        public bool dryRun { get; set; }

        [Option('c', "reedit-message", MutuallyExclusive = "commit")]
        public string reeditMessage { get; set; }

        [Option('C', "reuse-message", MutuallyExclusive = "commit")]
        public string reuseMessage { get; set; }

        [Option("fixup", MutuallyExclusive = "commit")]
        public string fixup { get; set; }

        [Option("squash", MutuallyExclusive = "commit")]
        public string squash { get; set; }

        [Option('F', "file", MutuallyExclusive = "file")]
        public string file { get; set; }

        [Option('m', "message", MutuallyExclusive = "file")]
        public string message { get; set; }

        [Option("reset-author")]
        public bool resetAuthor { get; set; }

        [Option("allow-empty")]
        public bool allowEmpty { get; set; }

        [Option("allow-empty-message")]
        public bool allowEmptyMessage { get; set; }

        [Option('n', "no-verify")]
        public bool noVerify { get; set; }

        [Option('e', "edit")]
        public bool edit { get; set; }

        [Option("author")]
        public string author { get; set; }

        [Option("date")]
        public string date { get; set; }

        [Option("cleanup")]
        public CleanUpMode cleanup { get; set; }

        [Option("status")]
        public bool status { get; set; }

        [Option("no-status")]
        public bool noStatus { get; set; }

        [Option('i', "include", MutuallyExclusive = "include")]
        public bool include { get; set; }

        [Option('o', "only", MutuallyExclusive = "include")]
        public bool only { get; set; }

        [Option('S', "gpg-sign")]
        public string gpgSign { get; set; }

        [Value(0)]
        public string[] files { get; set; }
    }
}
