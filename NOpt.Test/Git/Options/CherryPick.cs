using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
    git cherry-pick [--edit] [-n] [-m parent-number] [-s] [-x] [--ff] [-S[<key-id>]] <commit>…
    git cherry-pick --continue
    git cherry-pick --quit
    git cherry-pick --abort
    */
    public class CherryPick
    {
        [Option('e', "edit")]
        public readonly bool edit;

        [Option('n', "no-commit")]
        public readonly bool noCommit;

        [Option('m', "mainline")]
        public readonly bool parentNumber;

        [Option('s', "signoff")]
        public readonly bool signoff;

        [Option('x')]
        public readonly bool x;

        [Option("ff")]
        public readonly bool ff;

        [Option('S', "gpg-sign")]
        public readonly string S;

        [Option("continue")]
        public readonly bool @continue;

        [Option("quit")]
        public readonly bool quit;

        [Option("abort")]
        public readonly bool abort;
    }
}
