using System;

namespace NOpt.Test.Git.Options
{
    /*
    git log --pretty=short | git shortlog [<options>]
    git shortlog [<options>] [<revision range>] [[--] <path>…]
    */
    public class ShortLog
    {
        [Option('n', "numbered")]
        public bool numbered { get; set; }

        [Option('s', "summary")]
        public bool summary { get; set; }

        [Option('e', "email")]
        public bool email { get; set; }

        [Option("format")]
        public string format { get; set; }

        [Option('w')]
        public string w { get; set; }

        [Value(0)]
        public string revisionRange { get; set; }

        [Value(1)]
        public string[] path { get; set; }
    }
}
