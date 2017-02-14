namespace NOpt.Test.Git.Options
{
    // git gc [--aggressive] [--auto] [--quiet] [--prune=<date> | --no-prune] [--force]
    public class Gc
    {
        [Option("aggressive")]
        public bool aggressive { get; set; }

        [Option("auto")]
        public bool auto { get; set; }

        [Option("quiet")]
        public bool quiet { get; set; }

        [Option("prune")]
        public string prune { get; set; } = "2 weeks";

        [Option("no-prune")]
        public bool noPrune { get; set; }

        [Option("force")]
        public bool force { get; set; }
    }
}
