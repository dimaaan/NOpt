using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    public class Bisect
    {
        public class Start
        {
            [Option("no-checkout")]
            public readonly bool noCheckout;

            [Value(0)]
            public readonly string[] extra;
        }

        public class Bad
        {
            [Value(0)]
            public readonly string rev;
        }

        public class Good
        {
            [Value(0)]
            public readonly string[] rev;
        }

        public class Skip
        {
            [Value(0)]
            public readonly string[] revOrRange;
        }

        public class Reset
        {
            [Value(0)]
            public readonly string[] commit;
        }

        public class Replay
        {
            [Value(0)]
            public readonly string logfile;
        }

        public class Run
        {
            [Value(0)]
            public readonly string[] cmd;
        }

        public enum Command { HELP, VISUALIZE, LOG }

        [Value(0)]
        public readonly Command cmd;

        [Verb("start")]
        public readonly Start start;

        [Verb("bad")]
        public readonly Start bad;

        [Verb("good")]
        public readonly Start good;

        [Verb("skip")]
        public readonly Start skip;

        [Verb("reset")]
        public readonly Start reset;

        [Verb("replay")]
        public readonly Start replay;

        [Verb("run")]
        public readonly Start run;
    }
}
