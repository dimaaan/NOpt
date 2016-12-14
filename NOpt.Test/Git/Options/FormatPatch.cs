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
        public bool keepSubject { get; set; }

        [Option('o', "output-directory", MutuallyExclusive = "o")]
        public string outputDirectory { get; set; }

        [Option("stdout", MutuallyExclusive = "o")]
        public bool stdOut { get; set; }

        [Option("thread", MutuallyExclusive = "thread")]
        public ThreadStyle style { get; set; } = ThreadStyle.SHALLOW;

        [Option("no-thread", MutuallyExclusive = "thread")]
        public bool NoThread { get; set; }

        [Option("attach", MutuallyExclusive = "attach")]
        public string attach { get; set; }

        [Option("inline", MutuallyExclusive = "attach")]
        public string inline { get; set; }

        [Option("no-attach", MutuallyExclusive = "attach")]
        public bool noAttach { get; set; }

        [Option('s', "signoff")]
        public bool signoff { get; set; }

        [Option("signature", MutuallyExclusive = "signature")]
        public string signature { get; set; }

        [Option("no-signature", MutuallyExclusive = "signature")]
        public bool noSignature { get; set; }

        [Option('n', "numbered", MutuallyExclusive = "numbered")]
        public bool numbered { get; set; }

        [Option('N', "no-numbered", MutuallyExclusive = "numbered")]
        public bool noNumbered { get; set; }

        [Option("start-number")]
        public int startNumber { get; set; } = 1;

        [Option("numbered-files")]
        public bool numberedFiles { get; set; }

        [Option("in-reply-to")]
        public string inReplyTo { get; set; }

        [Option("suffix")]
        public string suffix { get; set; } = ".patch";

        [Option("ignore-if-in-upstream")]
        public bool ignoreIfInUpstream { get; set; }

        [Option("subject-prefix")]
        public string subjectPrefix { get; set; }

        [Option('v', "reroll-count")]
        public int rerollCount { get; set; }

        [Option("to")]
        public string to { get; set; }

        [Option("cc")]
        public string cc { get; set; }

        [Option("cover-letter", MutuallyExclusive = "cover-letter")]
        public bool coverLetter { get; set; }

        [Option("no-cover-letter", MutuallyExclusive = "cover-letter")]
        public bool noCoverLetter { get; set; }

        [Option('q', "quiet")]
        public bool quiet { get; set; }

        [Option("notes")]
        public string notes { get; set; }
    }
}
