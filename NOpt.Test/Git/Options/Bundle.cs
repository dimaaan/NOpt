using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    public class Bundle
    {
        public class Create
        {
            [Value(0)]
            public readonly string file;

            [Value(1)]
            public readonly string[] gitRevListArgs;
        }

        public class Verify
        {
            [Value(0)]
            public readonly string file;
        }

        public class ListHeads
        {
            [Value(0)]
            public readonly string file;

            [Value(1)]
            public readonly string[] refname;
        }

        public class Unbundle
        {
            [Value(0)]
            public readonly string file;

            [Value(1)]
            public readonly string[] refname;
        }

        [Verb("create")]
        public readonly Create create;

        [Verb("verify")]
        public readonly Verify verify;

        [Verb("list-heads")]
        public readonly ListHeads listHeads;

        [Verb("unbundle")]
        public readonly Unbundle unbundle;
    }
}
