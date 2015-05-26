using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public readonly bool all;

        [Option('a', "append")]
        public readonly bool append;

        [Option("depth")]
        public readonly bool depth;

        [Option("unshallow")]
        public readonly bool unshallow;

        [Option("update-shallow")]
        public readonly bool updateShallow;

        [Option("dry-run")]
        public readonly bool dryRun;

        [Option('f', "force")]
        public readonly bool force;

        [Option('k', "keep")]
        public readonly bool keep;

        [Option("multiple")]
        public readonly bool multiple;

        [Option('p', "prune")]
        public readonly bool prune;

        [Option('n', "no-tags")]
        public readonly bool noTags;

        [Option('t', "tags")]
        public readonly bool tags;

        [Option("recurse-submodules")]
        public readonly RecursiveSubmodulesMode recurseSubmodules=RecursiveSubmodulesMode.YES;

        [Option('u', "update-head-ok")]
        public readonly bool updateHeadOk;

        [Option("upload-pack")]
        public readonly string uploadPack;

        [Option('q', "quiet")]
        public readonly bool quiet;

        [Option('v', "verbose")]
        public readonly bool verbose;

        [Option("progress")]
        public readonly bool progress;

        [Value(0)]
        public readonly string[] extras;
    }
}
