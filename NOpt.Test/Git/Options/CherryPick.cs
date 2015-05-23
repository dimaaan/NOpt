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
        public bool edit { get; set; }

        [Option('n', "no-commit")]
        public bool noCommit { get; set; }

        [Option('m', "mainline")]
        public bool parentNumber { get; set; }

        [Option('s', "signoff")]
        public bool signoff { get; set; }

        [Option('x')]
        public bool x { get; set; }

        [Option("ff")]
        public bool ff { get; set; }

        [Option('S', "gpg-sign")]
        public string S { get; set; }

        [Option("continue")]
        public bool @continue { get; set; }

        [Option("quit")]
        public bool quit { get; set; }

        [Option("abort")]
        public bool abort { get; set; }
    }
}
