namespace NOpt.Test.Git.Options
{
    public class Bundle
    {
        public class Create
        {
            [Value(0)]
            public string file { get; set; }

            [Value(1)]
            public string[] gitRevListArgs { get; set; }
        }

        public class Verify
        {
            [Value(0)]
            public string file { get; set; }
        }

        public class ListHeads
        {
            [Value(0)]
            public string file { get; set; }

            [Value(1)]
            public string[] refname { get; set; }
        }

        public class Unbundle
        {
            [Value(0)]
            public string file { get; set; }

            [Value(1)]
            public string[] refname { get; set; }
        }

        [Verb("create")]
        public Create create { get; set; }

        [Verb("verify")]
        public Verify verify { get; set; }

        [Verb("list-heads")]
        public ListHeads listHeads { get; set; }

        [Verb("unbundle")]
        public Unbundle unbundle { get; set; }
    }
}
