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
        public bool follow { get; set; }

        [Option("decorate", MutuallyExclusive = "decorate")]
        public Decoration decorate { get; set; }

        [Option("no-decorate", MutuallyExclusive = "decorate")]
        public bool noDecorate { get; set; }

        [Option("source")]
        public bool source { get; set; }

        [Option("use-mailmap")]
        public bool useMailmap { get; set; }

        [Option("full-diff")]
        public bool fullDiff { get; set; }

        [Option("log-size")]
        public int logSize { get; set; }

        [Option('L')]
        public string L { get; set; }

        [Value(0)]
        public string[] extras { get; set; }

    }
}
