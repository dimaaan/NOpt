using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    // git log [<options>] [<revision range>] [[--] <path>…]
    public class Log
    {
        public enum Decoration { SHORT, FULL, NO };

        [Option("follow")]
        public readonly bool follow;

        [Option("decorate", MutuallyExclusive = "decorate")]
        public readonly Decoration decorate;

        [Option("no-decorate", MutuallyExclusive = "decorate")]
        public readonly bool noDecorate;

        [Option("source")]
        public readonly bool source;

        [Option("use-mailmap")]
        public readonly bool useMailmap;

        [Option("full-diff")]
        public readonly bool fullDiff;

        [Option("log-size")]
        public readonly int logSize;

        [Option('L')]
        public readonly string L;

        [Value(0)]
        public readonly string[] extras;

    }
}
