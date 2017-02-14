namespace NOpt.Test.Git.Options
{
    // git show [options] <object>…
    public class Show
    {
        [Value(0)]
        public string @object { get; set; }

        [Option("pretty")]
        [Option("format")]
        public string format { get; set; }

        [Option("abbrev-commit", MutuallyExclusive = "abbrev")]
        public bool abbrevCommit { get; set; }

        [Option("no-abbrev-commit", MutuallyExclusive = "abbrev")]
        public bool noAbbrevCommit { get; set; }

        [Option("oneline")]
        public bool oneline { get; set; }

        [Option("encoding")]
        public string encoding { get; set; }

        [Option("notes", MutuallyExclusive = "notes")]
        public string notes { get; set; }

        [Option("no-notes", MutuallyExclusive = "notes")]
        public bool noNotes { get; set; }

        [Option("show-notes", MutuallyExclusive = "std-notes")]
        public string showNotes { get; set; }

        [Option("standard-notes", MutuallyExclusive = "std-notes")]
        public bool standardNotes { get; set; }

        [Option("no-standard-notes", MutuallyExclusive = "std-notes")]
        public bool noStandardNotes { get; set; }

        [Option("show-signature", MutuallyExclusive = "std-notes")]
        public bool showSignature { get; set; }
    }
}
