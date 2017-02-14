namespace NOpt.Test.Git.Options
{
    // git mv <options>… <args>…
    public class Mv
    {
        [Option('f', "force")]
        public bool force { get; set; }

        [Option('k')]
        public bool k { get; set; }

        [Option('n', "dry-run")]
        public bool dryRun { get; set; }

        [Option('v', "verbose")]
        public bool verbose { get; set; }

        [Value(0)]
        public string[] extras { get; set; }
    }
}
