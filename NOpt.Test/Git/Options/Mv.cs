using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    // git mv <options>… <args>…
    public class Mv
    {
        [Option('f', "force")]
        public readonly bool force;

        [Option('k')]
        public readonly bool k;

        [Option('n', "dry-run")]
        public readonly bool dryRun;

        [Option('v', "verbose")]
        public readonly bool verbose;

        [Value(0)]
        public string[] extras;
    }
}
