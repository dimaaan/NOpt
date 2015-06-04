using System;

namespace NOpt.Test.Git.Options
{
    // git status [<options>…] [--] [<pathspec>…]
    public class Status
    {
        public enum UntrackedFileMode { NO, NORMAL, ALL }

        public enum IgnoreSubmodules { NONE, UNTRACKED, DIRTY, ALL }

        [Option('s', "short")]
        public readonly bool @short;

        [Option('b', "branch")]
        public readonly bool branch;

        [Option("porcelain")]
        public readonly bool porcelain;

        [Option("long")]
        public readonly bool @long;

        [Option('u', "untracked-files")]
        public readonly UntrackedFileMode untrackedFiles = UntrackedFileMode.ALL;

        [Option("ignore-submodules")]
        public readonly IgnoreSubmodules ignoreSubmodules = IgnoreSubmodules.ALL;

        [Option("ignored")]
        public readonly bool ignored;

        [Option('z')]
        public readonly bool z;

        [Option("column", MutuallyExclusive = "column")]
        public readonly bool column;

        [Option("no-column", MutuallyExclusive = "column")]
        public readonly bool noColumn;
    }
}
