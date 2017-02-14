namespace NOpt.Test.Git.Options
{
    /*
    git revert [--[no-]edit] [-n] [-m parent-number] [-s] [-S[<key-id>]] <commit>…
    git revert --continue
    git revert --quit
    git revert --abort
    */
    public class Revert
    {
        [Value(0)]
        public string commit { get; set; }

        [Option('e', "edit")]
        public bool edit { get; set; }

        [Option('m', "mainline")]
        public int mainline { get; set; }

        [Option("no-edit")]
        public bool noEdit { get; set; }

        [Option('n', "no-commit")]
        public bool noCommit { get; set; }

        [Option('S', "gpg-sign")]
        public bool gpgSign { get; set; }

        [Option('s', "signoff")]
        public bool signoff { get; set; }

        [Option("strategy")]
        public string strategy { get; set; }

        [Option('X', "strategy-option")]
        public string strategyOption { get; set; }

        [Option("continue")]
        public bool @continue { get; set; }

        [Option("quit")]
        public bool quit { get; set; }

        [Option("abort")]
        public bool abort { get; set; }
    }
}
