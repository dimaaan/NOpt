using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public readonly string commit;

        [Option('e', "edit")]
        public readonly bool edit;

        [Option('m', "mainline")]
        public readonly int mainline;

        [Option("no-edit")]
        public readonly bool noEdit;

        [Option('n', "no-commit")]
        public readonly bool noCommit;

        [Option('S', "gpg-sign")]
        public readonly bool gpgSign;

        [Option('s', "signoff")]
        public readonly bool signoff;

        [Option("strategy")]
        public readonly string strategy;

        [Option('X', "strategy-option")]
        public readonly string strategyOption;

        [Option("continue")]
        public readonly bool @continue;

        [Option("quit")]
        public readonly bool quit;

        [Option("abort")]
        public readonly bool abort;
    }
}
