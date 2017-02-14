namespace NOpt.Test.Git.Options
{
    /*
    git grep    [-a | --text] [-I] [--textconv] [-i | --ignore-case] [-w | --word-regexp]
                [-v | --invert-match] [-h|-H] [--full-name]
                [-E | --extended-regexp] [-G | --basic-regexp]
                [-P | --perl-regexp]
                [-F | --fixed-strings] [-n | --line-number]
                [-l | --files-with-matches] [-L | --files-without-match]
                [(-O | --open-files-in-pager) [<pager>]]
                [-z | --null]
                [-c | --count] [--all-match] [-q | --quiet]
                [--max-depth <depth>]
                [--color[=<when>] | --no-color]
                [--break] [--heading] [-p | --show-function]
                [-A <post-context>] [-B <pre-context>] [-C <context>]
                [-W | --function-context]
                [-f <file>] [-e] <pattern>
                [--and|--or|--not|(|)|-e <pattern>…]
                [ [--[no-]exclude-standard] [--cached | --no-index | --untracked] | <tree>…]
                [--] [<pathspec>…]
    */
    public class Grep
    {
        public enum Color { ALWAYS, NEVER, AUTO };

        [Option('a', "text")]
        public bool text { get; set; }

        [Option('I')]
        public bool I { get; set; }

        [Option("textconv")]
        public bool textconv { get; set; }

        [Option('i', "ignore-case")]
        public bool ignoreCase { get; set; }

        [Option('w', "word-regexp")]
        public bool wordRegexp { get; set; }

        [Option('v', "invert-match")]
        public bool invertMatch { get; set; }

        [Option('h', MutuallyExclusive = "h")]
        public bool h { get; set; }

        [Option('H', MutuallyExclusive = "h")]
        public bool H { get; set; }

        [Option("full-name")]
        public bool fullName { get; set; }

        [Option('e', "extended-regexp")]
        public bool extendedRegexp { get; set; }

        [Option('G', "basic-regexp")]
        public bool basicRegexp { get; set; }

        [Option('P', "perl-regexp")]
        public bool perlRegexp { get; set; }

        [Option('F', "fixed-strings")]
        public bool fixedStrings { get; set; }

        [Option('n', "line-number")]
        public bool lineNumber { get; set; }

        [Option("name-only", MutuallyExclusive = "matches")]
        [Option('l', "files-with-matches", MutuallyExclusive = "matches")]
        public bool filesWithMatches { get; set; }

        [Option('L', "files-without-matches", MutuallyExclusive = "matches")]
        public bool filesWithoutMatches { get; set; }

        [Option('O', "open-files-in-pager")]
        public string openFilesInPager { get; set; }

        [Option('z', "null")]
        public bool @null { get; set; }

        [Option("all-match")]
        public bool allMatch { get; set; }

        [Option('q', "quiet")]
        public bool quiet { get; set; }

        [Option("max-depth")]
        public int maxDepth { get; set; }

        [Option("color", MutuallyExclusive = "color")]
        public Color color { get; set; } = Color.ALWAYS;

        [Option("no-color", MutuallyExclusive = "color")]
        public bool noColor { get; set; }

        [Option("break")]
        public bool @break { get; set; }

        [Option("heading")]
        public bool heading { get; set; }

        [Option('p', "show-function")]
        public bool showFunction { get; set; }

        [Option('A', "after-context")]
        public int afterContext { get; set; }

        [Option('B', "before-context")]
        public int beforeContext { get; set; }

        [Option('C', "context")]
        public int context { get; set; }

        [Option('W', "function-context")]
        public bool functionContext { get; set; }

        [Option('f')]
        public string file { get; set; }

        [Option('e')]
        public string pattern { get; set; }

        [Option("and")]
        public string and { get; set; }

        [Option("or")]
        public string or { get; set; }

        [Option("not")]
        public string not { get; set; }

        [Option("exclude-standard", MutuallyExclusive = "std")]
        public bool excludeStandard { get; set; }

        [Option("no-exclude-standard", MutuallyExclusive = "std")]
        public bool noExcludeStandard { get; set; }

        [Option("cached", MutuallyExclusive = "search")]
        public bool cached { get; set; }

        [Option("no-index", MutuallyExclusive = "search")]
        public bool noIndex { get; set; }

        [Option("untracked", MutuallyExclusive = "search")]
        public bool untracked { get; set; }

        [Value(0)]
        public string[] extra { get; set; }
    }
}
