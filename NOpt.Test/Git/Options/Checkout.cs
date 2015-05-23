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
        public bool quiet { get; set; }

        [Option('f', "force")]
        public bool force { get; set; }

        [Option('m', "merge")]
        public bool merge { get; set; }

        [Option("detach")]
        public bool detach { get; set; }

        [Option('b', MutuallyExclusive = "b")]
        public bool b { get; set; }

        [Option('B', MutuallyExclusive = "b")]
        public bool B { get; set; }

        [Option("orphan", MutuallyExclusive = "b")]
        public bool orphan { get; set; }

        [Option("ours", MutuallyExclusive = "whoms")]
        public bool ours { get; set; }

        [Option("theirs", MutuallyExclusive = "whoms")]
        public bool theirs { get; set; }

        [Option("conflict", MutuallyExclusive = "whoms")]
        public ConflictStyle conflict { get; set; } = ConflictStyle.MERGE;

        [Option('p', "patch")]
        public bool patch { get; set; }

        [Value(0)]
        public string extras { get; set; }
    }
}
