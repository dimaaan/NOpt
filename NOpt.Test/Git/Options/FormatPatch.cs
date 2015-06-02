using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
    git format-patch    [-k] [(-o|--output-directory) <dir> | --stdout]
                        [--no-thread | --thread[=<style>]]
                        [(--attach|--inline)[=<boundary>] | --no-attach]
                        [-s | --signoff]
                        [--signature=<signature> | --no-signature]
                        [-n | --numbered | -N | --no-numbered]
                        [--start-number <n>] [--numbered-files]
                        [--in-reply-to=Message-Id] [--suffix=.<sfx>]
                        [--ignore-if-in-upstream]
                        [--subject-prefix=Subject-Prefix] [(--reroll-count|-v) <n>]
                        [--to=<email>] [--cc=<email>]
                        [--[no-]cover-letter] [--quiet] [--notes[=<ref>]]
                        [<common diff options>]
                        [ <since> | <revision range> ]
    */
    public class FormatPatch
    {
        public enum ThreadStyle { SHALLOW, DEEP };

        [Option('k', "keep-subject")]
        public readonly bool keepSubject;

        [Option('o', "output-directory", MutuallyExclusive = "o")]
        public readonly string outputDirectory;

        [Option("stdout", MutuallyExclusive = "o")]
        public readonly bool stdOut;

        [Option("thread", MutuallyExclusive = "thread")]
        public readonly ThreadStyle style = ThreadStyle.SHALLOW;

        [Option("no-thread", MutuallyExclusive = "thread")]
        public readonly bool NoThread;

        [Option("attach", MutuallyExclusive = "attach")]
        public readonly string attach;

        [Option("inline", MutuallyExclusive = "attach")]
        public readonly string inline;

        [Option("no-attach", MutuallyExclusive = "attach")]
        public readonly bool noAttach;

        [Option('s', "signoff")]
        public readonly bool signoff;

        [Option("signature", MutuallyExclusive = "signature")]
        public readonly string signature;

        [Option("no-signature", MutuallyExclusive = "signature")]
        public readonly bool noSignature;

        [Option('n', "numbered", MutuallyExclusive = "numbered")]
        public readonly bool numbered;

        [Option('N', "no-numbered", MutuallyExclusive = "numbered")]
        public readonly bool noNumbered;

        [Option("start-number")]
        public readonly int startNumber = 1;

        [Option("numbered-files")]
        public readonly bool numberedFiles;

        [Option("in-reply-to")]
        public readonly string inReplyTo;

        [Option("suffix")]
        public readonly string suffix = ".patch";

        [Option("ignore-if-in-upstream")]
        public readonly bool ignoreIfInUpstream;

        [Option("subject-prefix")]
        public readonly string subjectPrefix;

        [Option('v', "reroll-count")]
        public readonly int rerollCount;

        [Option("to")]
        public readonly string to;

        [Option("cc")]
        public readonly string cc;

        [Option("cover-letter", MutuallyExclusive = "cover-letter")]
        public readonly bool coverLetter;

        [Option("no-cover-letter", MutuallyExclusive = "cover-letter")]
        public readonly bool noCoverLetter;

        [Option('q', "quiet")]
        public readonly bool quiet;

        [Option("notes")]
        public readonly string notes;
    }
}
