using System;

namespace NOpt.Test.Git.Options
{
    // git show [options] <object>…
    public class Show
    {
        [Value(0)]
        public readonly string @object;

        [Option("pretty")]
        [Option("format")]
        public readonly string format;

        [Option("abbrev-commit", MutuallyExclusive = "abbrev")]
        public readonly bool abbrevCommit;

        [Option("no-abbrev-commit", MutuallyExclusive = "abbrev")]
        public readonly bool noAbbrevCommit;

        [Option("oneline")]
        public readonly bool oneline;

        [Option("encoding")]
        public readonly string encoding;

        [Option("notes", MutuallyExclusive = "notes")]
        public readonly string notes;

        [Option("no-notes", MutuallyExclusive = "notes")]
        public readonly bool noNotes;

        [Option("show-notes", MutuallyExclusive = "std-notes")]
        public readonly string showNotes;

        [Option("standard-notes", MutuallyExclusive = "std-notes")]
        public readonly bool standardNotes;

        [Option("no-standard-notes", MutuallyExclusive = "std-notes")]
        public readonly bool noStandardNotes;

        [Option("show-signature", MutuallyExclusive = "std-notes")]
        public readonly bool showSignature;
    }
}
