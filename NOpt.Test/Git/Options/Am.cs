namespace NOpt.Test.Git.Options
{
    /*

    git am  [--signoff] [--keep] [--[no-]keep-cr] [--[no-]utf8]
             [--3way] [--interactive] [--committer-date-is-author-date]
             [--ignore-date] [--ignore-space-change | --ignore-whitespace]
             [--whitespace=<option>] [-C<n>] [-p<n>] [--directory=<dir>]
             [--exclude=<path>] [--include=<path>] [--reject] [-q | --quiet]
             [--[no-]scissors] [-S[<keyid>]] [--patch-format=<format>]
             [(<mbox> | <Maildir>)…]
    git am   (--continue | --skip | --abort)
    */
    public class Am
    {
        [Value(0)]
        public bool mbox { get; set; }

        [Option('s', "signoff")]
        public bool signoff { get; set; }

        [Option('k', "keep")]
        public bool keep { get; set; }

        [Option("keep-non-patch")]
        public bool keepNonPatch { get; set; }

        [Option("keep-cr")]
        public bool keepCr { get; set; }

        [Option("no-keep-cr")]
        public bool noKeepCr { get; set; }

        [Option('c', "scissors")]
        public bool scissors { get; set; }

        [Option("no-scissors")]
        public bool noScissors { get; set; }

        [Option('q', "quiet")]
        public bool quiet { get; set; }

        [Option('u', "utf8")]
        public bool utf8 { get; set; }

        [Option("no-utf8")]
        public bool noUtf8 { get; set; }

        [Option('3', "3way")]
        public bool threeWay { get; set; }

        [Option("ignore-date")]
        public bool ignoreDate { get; set; }

        [Option("ignore-space-change")]
        public bool ignoreSpaceChange { get; set; }

        [Option("ignore-whitespace")]
        public bool ignoreWhitespace { get; set; }

        [Option("whitespace")]
        public string whitespace { get; set; }

        [Option('C')]
        public string C { get; set; }

        [Option('p')]
        public string p { get; set; }

        [Option("directory")]
        public string directory { get; set; }

        [Option("exclude")]
        public string exclude { get; set; }

        [Option("include")]
        public string include { get; set; }

        [Option("reject")]
        public bool reject { get; set; }

        [Option("patch-format")]
        public bool patchFormat { get; set; }

        [Option('i', "interactive")]
        public bool interactive { get; set; }

        [Option("committer-date-is-author-date")]
        public bool committerDateIsAuthorDate { get; set; }

        [Option("skip")]
        public bool skip { get; set; }

        [Option('S')]
        public string S { get; set; }

        [Option("gpg-sign")]
        public string gpgSign { get; set; }

        [Option("continue")]
        public bool @continue { get; set; }

        [Option('r', "resolved")]
        public bool resolved { get; set; }

        [Option("resolvemsg")]
        public string resolvemsg { get; set; }

        [Option("abort")]
        public bool abort { get; set; }
    }
}
