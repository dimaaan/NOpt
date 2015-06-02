using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public readonly bool stat;

        [Option('n', "no-stat", MutuallyExclusive = "stat")]
        public readonly bool noStat;

        [Option("commit", MutuallyExclusive = "commit")]
        public readonly bool commit;

        [Option("no-commit", MutuallyExclusive = "commit")]
        public readonly bool noCommit;

        [Option("squash", MutuallyExclusive = "squash")]
        public readonly bool squash;

        [Option("no-squash", MutuallyExclusive = "squash")]
        public readonly bool noSquash;

        [Option('e', "edit", MutuallyExclusive = "edit")]
        public readonly bool edit;

        [Option("no-edit", MutuallyExclusive = "edit")]
        public readonly bool noEdit;

        [Option('s', "strategy")]
        public readonly string strategy;

        [Option('X', "strategy-option")]
        public readonly string strategyOption;

        [Option('S', "gpg-sign")]
        public readonly string gpgSign;

        [Option("rerere-autoupdate", MutuallyExclusive = "rerere")]
        public readonly bool rerereAutoupdate;

        [Option("no-rerere-autoupdate", MutuallyExclusive = "rerere")]
        public readonly bool noRerereAutoupdate;

        [Option('m')]
        public readonly string m;

        [Option("abort")]
        public readonly bool abort;

        [Value(0)]
        public string[] extras;
    }
}
