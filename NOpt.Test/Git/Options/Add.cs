using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public readonly bool dryRun;

        [Option('v', "verbose")]
        public readonly bool verbose;

        [Option('f', "force")]
        public readonly bool force;

        [Option('i', "interactive")]
        public readonly bool interactive;

        [Option('p', "patch")]
        public readonly bool patch;

        [Option('e', "edit")]
        public readonly bool edit;

        [Option('u', "update")]
        public readonly bool update;

        [Option('A', "all")]
        [Option("no-ignore-removal")]
        public readonly bool updateAll;

        [Option("no-all")]
        [Option("ignore-removal")]
        public readonly bool updateNoAll;

        [Option('N', "intent-to-add")]
        public readonly bool intentToAdd;

        [Option("refresh")]
        public readonly bool refresh;

        [Option("ignore-errors")]
        public readonly bool ignoreErrors;

        [Option("ignore-missing")]
        public readonly bool ignoreMissing;

        [Value(0)]
        public readonly bool pathspec;
    }
}
