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
        public string format;

        [Option('l', "list")]
        public bool list;

        [Option('v', "verbose")]
        public bool verbose;

        [Option("prefix")]
        public string prefix;

        [Option('o', "output")]
        public string output;

        [Option("worktree-attributes")]
        public bool worktreeAttributes;

        [Option("remote")]
        public string remote;

        [Option("exec")]
        public string exec;

        [Option("tree-ish")]
        public bool treeIsh;

        [Value(0)]
        public string path;

        [Value(1)]
        public string[] extra;
    }
}
