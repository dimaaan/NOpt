using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
    git tag [-a | -s | -u <key-id>] [-f] [-m <msg> | -F <file>] <tagname> [<commit> | <object>]
    git tag -d <tagname>…
    git tag [-n[<num>]] -l [--contains <commit>] [--points-at <object>]
            [--column[=<options>] | --no-column] [<pattern>…]
            [<pattern>…]
    git tag -v <tagname>…
    */
    public class Tag
    {
        public enum CleanUpMode { VERBATIM, WHITESPACE, STRIP };

        [Option('a', "annotate", MutuallyExclusive = "a")]
        public readonly bool annotate;

        [Option('s', "sign", MutuallyExclusive = "a")]
        public readonly bool sign;

        [Option('u', "local-user", MutuallyExclusive = "a")]
        public readonly string localUser;

        [Option('f', "force")]
        public readonly bool force;

        [Option('d', "delete")]
        public readonly bool delete;

        [Option('v', "verify")]
        public readonly bool verify;

        [Option('n')]
        public readonly int n;

        [Option('l', "list")]
        public readonly string list;

        [Option("sort")]
        public readonly string sort;

        [Option("column", MutuallyExclusive = "column")]
        public readonly string column;

        [Option("no-column", MutuallyExclusive = "column")]
        public readonly bool noColumn;

        [Option("contains")]
        public readonly string contains;

        [Option("points-at")]
        public readonly string pointsAt;

        [Option('m', "message")]
        public readonly string message;

        [Option('f', "file")]
        public readonly string file;

        [Option("cleanup")]
        public readonly CleanUpMode cleanup = CleanUpMode.STRIP;

        [Value(0)]
        public readonly string tagname;

        [Value(1)]
        public readonly string[] extras;
    }
}
