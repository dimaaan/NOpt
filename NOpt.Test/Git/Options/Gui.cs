namespace NOpt.Test.Git.Options
{
    // git gui [<command>] [arguments]
    public class Gui
    {
        public enum Command { BLAME, BROWSER, CITOOL, VERSION };

        [Value(0)]
        public Command command { get; set; }

        [Value(1)]
        public string[] args { get; set; }
    }
}
