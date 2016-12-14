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
        public bool annotate { get; set; }

        [Option('s', "sign", MutuallyExclusive = "a")]
        public bool sign { get; set; }

        [Option('u', "local-user", MutuallyExclusive = "a")]
        public string localUser { get; set; }

        [Option('f', "force")]
        public bool force { get; set; }

        [Option('d', "delete")]
        public bool delete { get; set; }

        [Option('v', "verify")]
        public bool verify { get; set; }

        [Option('n')]
        public int n { get; set; }

        [Option('l', "list")]
        public string list { get; set; }

        [Option("sort")]
        public string sort { get; set; }

        [Option("column", MutuallyExclusive = "column")]
        public string column { get; set; }

        [Option("no-column", MutuallyExclusive = "column")]
        public bool noColumn { get; set; }

        [Option("contains")]
        public string contains { get; set; }

        [Option("points-at")]
        public string pointsAt { get; set; }

        [Option('m', "message")]
        public string message { get; set; }

        [Option('f', "file")]
        public string file { get; set; }

        [Option("cleanup")]
        public CleanUpMode cleanup { get; set; } = CleanUpMode.STRIP;

        [Value(0)]
        public string tagname { get; set; }

        [Value(1)]
        public string[] extras { get; set; }
    }
}
