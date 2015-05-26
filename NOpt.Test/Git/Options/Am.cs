using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public readonly bool mbox;

        [Option('s', "signoff")]
        public readonly bool signoff;

        [Option('k', "keep")]
        public readonly bool keep;

        [Option("keep-non-patch")]
        public readonly bool keepNonPatch;

        [Option("keep-cr")]
        public readonly bool keepCr;

        [Option("no-keep-cr")]
        public readonly bool noKeepCr;

        [Option('c', "scissors")]
        public readonly bool scissors;

        [Option("no-scissors")]
        public readonly bool noScissors;

        [Option('q', "quiet")]
        public readonly bool quiet;

        [Option('u', "utf8")]
        public readonly bool utf8;

        [Option("no-utf8")]
        public readonly bool noUtf8;

        [Option('3', "3way")]
        public readonly bool threeWay;

        [Option("ignore-date")]
        public readonly bool ignoreDate;

        [Option("ignore-space-change")]
        public readonly bool ignoreSpaceChange;

        [Option("ignore-whitespace")]
        public readonly bool ignoreWhitespace;

        [Option("whitespace")]
        public readonly string whitespace;

        [Option('C')]
        public readonly string C;

        [Option('p')]
        public readonly string p;

        [Option("directory")]
        public readonly string directory;

        [Option("exclude")]
        public readonly string exclude;

        [Option("include")]
        public readonly string include;

        [Option("reject")]
        public readonly bool reject;

        [Option("patch-format")]
        public readonly bool patchFormat;

        [Option('i', "interactive")]
        public readonly bool interactive;

        [Option("committer-date-is-author-date")]
        public readonly bool committerDateIsAuthorDate;

        [Option("skip")]
        public readonly bool skip;

        [Option('S')]
        public readonly string S;

        [Option("gpg-sign")]
        public readonly string gpgSign;

        [Option("continue")]
        public readonly bool @continue;

        [Option('r', "resolved")]
        public readonly bool resolved;

        [Option("resolvemsg")]
        public readonly string resolvemsg;

        [Option("abort")]
        public readonly bool abort;
    }
}
