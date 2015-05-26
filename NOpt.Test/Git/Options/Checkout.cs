using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    public class Checkout
    {
        public enum ConflictStyle { MERGE, DIFF3 };

        [Option('q', "quiet")]
        public readonly bool quiet;

        [Option('f', "force")]
        public readonly bool force;

        [Option('m', "merge")]
        public readonly bool merge;

        [Option("detach")]
        public readonly bool detach;

        [Option('b', MutuallyExclusive = "b")]
        public readonly bool b;

        [Option('B', MutuallyExclusive = "b")]
        public readonly bool B;

        [Option("orphan", MutuallyExclusive = "b")]
        public readonly bool orphan;

        [Option("ours", MutuallyExclusive = "whoms")]
        public readonly bool ours;

        [Option("theirs", MutuallyExclusive = "whoms")]
        public readonly bool theirs;

        [Option("conflict", MutuallyExclusive = "whoms")]
        public readonly ConflictStyle conflict=ConflictStyle.MERGE;

        [Option('p', "patch")]
        public readonly bool patch;

        [Value(0)]
        public readonly string extras;
    }
}
