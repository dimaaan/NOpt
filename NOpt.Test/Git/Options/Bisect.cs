namespace NOpt.Test.Git.Options
{
    public class Bisect
    {
        public class Start
        {
            [Option("no-checkout")]
            public bool noCheckout { get; set; }

            [Value(0)]
            public string[] extra { get; set; }
        }

        public class Bad
        {
            [Value(0)]
            public string rev { get; set; }
        }

        public class Good
        {
            [Value(0)]
            public string[] rev { get; set; }
        }

        public class Skip
        {
            [Value(0)]
            public string[] revOrRange { get; set; }
        }

        public class Reset
        {
            [Value(0)]
            public string[] commit { get; set; }
        }

        public class Replay
        {
            [Value(0)]
            public string logfile { get; set; }
        }

        public class Run
        {
            [Value(0)]
            public string[] cmd { get; set; }
        }

        public enum Command { HELP, VISUALIZE, LOG }

        [Value(0)]
        public Command cmd { get; set; }

        [Verb("start")]
        public Start start { get; set; }

        [Verb("bad")]
        public Start bad { get; set; }

        [Verb("good")]
        public Start good { get; set; }

        [Verb("skip")]
        public Start skip { get; set; }

        [Verb("reset")]
        public Start reset { get; set; }

        [Verb("replay")]
        public Start replay { get; set; }

        [Verb("run")]
        public Start run { get; set; }
    }
}
