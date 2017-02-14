namespace NOpt.Test.Git.Options
{
    /*
    git merge   [-n] [--stat] [--no-commit] [--squash] [--[no-]edit]
                [-s <strategy>] [-X <strategy-option>] [-S[<key-id>]]
                [--[no-]rerere-autoupdate] [-m <msg>] [<commit>…]
    git merge <msg> HEAD <commit>…
    git merge --abort
    */
    public class Merge
    {
        [Option("stat", MutuallyExclusive = "stat")]
        public bool stat { get; set; }

        [Option('n', "no-stat", MutuallyExclusive = "stat")]
        public bool noStat { get; set; }

        [Option("commit", MutuallyExclusive = "commit")]
        public bool commit { get; set; }

        [Option("no-commit", MutuallyExclusive = "commit")]
        public bool noCommit { get; set; }

        [Option("squash", MutuallyExclusive = "squash")]
        public bool squash { get; set; }

        [Option("no-squash", MutuallyExclusive = "squash")]
        public bool noSquash { get; set; }

        [Option('e', "edit", MutuallyExclusive = "edit")]
        public bool edit { get; set; }

        [Option("no-edit", MutuallyExclusive = "edit")]
        public bool noEdit { get; set; }

        [Option('s', "strategy")]
        public string strategy { get; set; }

        [Option('X', "strategy-option")]
        public string strategyOption { get; set; }

        [Option('S', "gpg-sign")]
        public string gpgSign { get; set; }

        [Option("rerere-autoupdate", MutuallyExclusive = "rerere")]
        public bool rerereAutoupdate { get; set; }

        [Option("no-rerere-autoupdate", MutuallyExclusive = "rerere")]
        public bool noRerereAutoupdate { get; set; }

        [Option('m')]
        public string m { get; set; }

        [Option("abort")]
        public bool abort { get; set; }

        [Value(0)]
        public string[] extras { get; set; }
    }
}
