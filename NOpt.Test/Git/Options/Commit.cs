using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
    git commit  [-a | --interactive | --patch] [-s] [-v] [-u<mode>] [--amend]
                [--dry-run] [(-c | -C | --fixup | --squash) <commit>]
                [-F <file> | -m <msg>] [--reset-author] [--allow-empty]
                [--allow-empty-message] [--no-verify] [-e] [--author=<author>]
                [--date=<date>] [--cleanup=<mode>] [--[no-]status]
                [-i | -o] [-S[<key-id>]] [--] [<file>…]
    */
    public class Commit
    {
        public enum UntrackedFilesMode { NO, NORMAL, ALL };

        public enum CleanUpMode { STRIP, WHITESPACE, VERBATIM, SCISSORS, DEFAULT };

        [Option('a', "all", MutuallyExclusive = "a")]
        public readonly bool all;

        [Option("interactive", MutuallyExclusive = "a")]
        public readonly bool interactive;

        [Option('p', "patch", MutuallyExclusive = "a")]
        public readonly bool patch;

        [Option('s', "signoff")]
        public readonly bool signoff;

        [Option('v', "verbose")]
        public readonly bool verbose;

        [Option('u', "untracked-files")]
        public readonly UntrackedFilesMode untrackedFiles=UntrackedFilesMode.ALL;

        [Option("amend")]
        public readonly bool amend;

        [Option("dry-run")]
        public readonly bool dryRun;

        [Option('c', "reedit-message", MutuallyExclusive = "commit")]
        public readonly string reeditMessage;

        [Option('C', "reuse-message", MutuallyExclusive = "commit")]
        public readonly string reuseMessage;

        [Option("fixup", MutuallyExclusive = "commit")]
        public readonly string fixup;

        [Option("squash", MutuallyExclusive = "commit")]
        public readonly string squash;

        [Option('F', "file", MutuallyExclusive = "file")]
        public readonly string file;

        [Option('m', "message", MutuallyExclusive = "file")]
        public readonly string message;

        [Option("reset-author")]
        public readonly bool resetAuthor;

        [Option("allow-empty")]
        public readonly bool allowEmpty;

        [Option("allow-empty-message")]
        public readonly bool allowEmptyMessage;

        [Option('n', "no-verify")]
        public readonly bool noVerify;

        [Option('e', "edit")]
        public readonly bool edit;

        [Option("author")]
        public readonly string author;

        [Option("date")]
        public readonly string date;

        [Option("cleanup")]
        public readonly CleanUpMode cleanup;

        [Option("status")]
        public readonly bool status;

        [Option("no-status")]
        public readonly bool noStatus;

        [Option('i', "include", MutuallyExclusive = "include")]
        public readonly bool include;

        [Option('o', "only", MutuallyExclusive = "include")]
        public readonly bool only;

        [Option('S', "gpg-sign")]
        public readonly string gpgSign;

        [Value(0)]
        public readonly string[] files;
    }
}
