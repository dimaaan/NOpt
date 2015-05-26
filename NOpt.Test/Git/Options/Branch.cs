using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
    git branch  [--color[=<when>] | --no-color] [-r | -a]
                [--list] [-v [--abbrev=<length> | --no-abbrev]]
                [--column[=<options>] | --no-column]
                [(--merged | --no-merged | --contains) [<commit>]] [<pattern>…]
    git branch [--set-upstream | --track | --no-track] [-l] [-f] <branchname> [<start-point>]
    git branch (--set-upstream-to=<upstream> | -u <upstream>) [<branchname>]
    git branch --unset-upstream [<branchname>]
    git branch (-m | -M) [<oldbranch>] <newbranch>
    git branch (-d | -D) [-r] <branchname>…
    git branch --edit-description [<branchname>]
    */
    public class Branch
    {
        public enum ColorWhen { ALWAYS, NEVER, AUTO }

        [Option("color", MutuallyExclusive = "color")]
        public readonly ColorWhen color = ColorWhen.ALWAYS;

        [Option("no-color", MutuallyExclusive = "color")]
        public readonly bool noColor;

        [Option('r', "remotes")]
        public readonly bool remotes;

        [Option('a', "all")]
        public readonly bool all;

        [Option("list")]
        public readonly bool list;

        [Option('v', "verbose")]
        [Option("vv")]
        public readonly bool verbose;

        [Option("abbrev", MutuallyExclusive = "abbrev")]
        public readonly uint abbrev;

        [Option("no-abbrev", MutuallyExclusive = "abbrev")]
        public readonly uint noAbbrev;

        [Option("column", MutuallyExclusive = "column")]
        public readonly string[] column;

        [Option("no-column", MutuallyExclusive = "column")]
        public readonly uint noColumn;

        [Option("merged", MutuallyExclusive = "mnc")]
        public readonly string merged;

        [Option("no-merged", MutuallyExclusive = "mnc")]
        public readonly string noMerged;

        [Option("contains", MutuallyExclusive = "mnc")]
        public readonly string contains;

        [Option("set-upstream", MutuallyExclusive = "upstream")]
        public readonly string setUpstream;

        [Option("track", MutuallyExclusive = "upstream")]
        public readonly string track;

        [Option("no-track", MutuallyExclusive = "upstream")]
        public readonly string noTrack;

        [Option('l', "create-reflog")]
        public readonly string createReflog;

        [Option('f', "force")]
        public readonly bool force;

        [Option('u', "set-upstream-to")]
        public readonly string setUpstreamTo;

        [Option("unset-upstream")]
        public readonly string unsetUpstream;

        [Option('m', "move", MutuallyExclusive = "move")]
        public readonly bool move;

        [Option('M', MutuallyExclusive = "move")]
        public readonly bool moveOverwrite;

        [Option('d', "delete", MutuallyExclusive = "delete")]
        public readonly bool delete;

        [Option('D', MutuallyExclusive = "delete")]
        public readonly bool deleteOverwrite;

        [Option("edit-description")]
        public readonly bool editDescription;

        [Value(0)]
        public readonly string[] extra;
    }
}
