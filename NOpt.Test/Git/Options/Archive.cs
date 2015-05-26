using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
    git archive     [--format=<fmt>] [--list] [--prefix=<prefix>/] [<extra>]
                    [-o <file> | --output=<file>] [--worktree-attributes]
                    [--remote=<repo> [--exec=<git-upload-archive>]] <tree-ish>
                    [<path>…]
    */
    public class Archive
    {
        [Option("format")]
        public readonly string format;

        [Option('l', "list")]
        public readonly bool list;

        [Option('v', "verbose")]
        public readonly bool verbose;

        [Option("prefix")]
        public readonly string prefix;

        [Option('o', "output")]
        public readonly string output;

        [Option("worktree-attributes")]
        public readonly bool worktreeAttributes;

        [Option("remote")]
        public readonly string remote;

        [Option("exec")]
        public readonly string exec;

        [Option("tree-ish")]
        public readonly bool treeIsh;

        [Value(0)]
        public readonly string path;

        [Value(1)]
        public readonly string[] extra;
    }
}
