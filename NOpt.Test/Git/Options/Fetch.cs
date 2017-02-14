namespace NOpt.Test.Git.Options
{
    /*
    git fetch [<options>] [<repository> [<refspec>…]]
    git fetch [<options>] <group>
    git fetch --multiple [<options>] [(<repository> | <group>)…]
    git fetch --all [<options>]
    */
    public class Fetch
    {
        public enum RecursiveSubmodulesMode { YES, ON_DEMAIND, NO }

        [Option("all")]
        public bool all { get; set; }

        [Option('a', "append")]
        public bool append { get; set; }

        [Option("depth")]
        public bool depth { get; set; }

        [Option("unshallow")]
        public bool unshallow { get; set; }

        [Option("update-shallow")]
        public bool updateShallow { get; set; }

        [Option("dry-run")]
        public bool dryRun { get; set; }

        [Option('f', "force")]
        public bool force { get; set; }

        [Option('k', "keep")]
        public bool keep { get; set; }

        [Option("multiple")]
        public bool multiple { get; set; }

        [Option('p', "prune")]
        public bool prune { get; set; }

        [Option('n', "no-tags")]
        public bool noTags { get; set; }

        [Option('t', "tags")]
        public bool tags { get; set; }

        [Option("recurse-submodules")]
        public RecursiveSubmodulesMode recurseSubmodules { get; set; } = RecursiveSubmodulesMode.YES;

        [Option('u', "update-head-ok")]
        public bool updateHeadOk { get; set; }

        [Option("upload-pack")]
        public string uploadPack { get; set; }

        [Option('q', "quiet")]
        public bool quiet { get; set; }

        [Option('v', "verbose")]
        public bool verbose { get; set; }

        [Option("progress")]
        public bool progress { get; set; }

        [Value(0)]
        public string[] extras { get; set; }
    }
}
