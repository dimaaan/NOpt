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
        public readonly bool numbered;

        [Option('s', "summary")]
        public readonly bool summary;

        [Option('e', "email")]
        public readonly bool email;

        [Option("format")]
        public readonly string format;

        [Option('w')]
        public readonly string w;

        [Value(0)]
        public readonly string revisionRange;

        [Value(1)]
        public readonly string[] path;
    }
}
