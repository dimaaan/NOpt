using System;

namespace NOpt.Test.Git.Options
{
    // git rm [-f | --force] [-n] [-r] [--cached] [--ignore-unmatch] [--quiet] [--] <file>…
    public class Rm
    {
        [Option('f', "force")]
        public readonly string force;

        [Option('n', "dry-run")]
        public readonly bool dryRun;

        [Option('r')]
        public readonly bool r;

        [Option("cached")]
        public readonly bool cached;

        [Option("ignore-unmatch")]
        public readonly bool ignoreUnmatch;

        [Option('q', "quiet")]
        public readonly bool quiet;

        [Value(0)]
        public readonly string[] files;
    }
}
