using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public readonly bool text;

        [Option('I')]
        public readonly bool I;

        [Option("textconv")]
        public readonly bool textconv;

        [Option('i', "ignore-case")]
        public readonly bool ignoreCase;

        [Option('w', "word-regexp")]
        public readonly bool wordRegexp;

        [Option('v', "invert-match")]
        public readonly bool invertMatch;

        [Option('h', MutuallyExclusive = "h")]
        public readonly bool h;

        [Option('H', MutuallyExclusive = "h")]
        public readonly bool H;

        [Option("full-name")]
        public readonly bool fullName;

        [Option('e', "extended-regexp")]
        public readonly bool extendedRegexp;

        [Option('G', "basic-regexp")]
        public readonly bool basicRegexp;

        [Option('P', "perl-regexp")]
        public readonly bool perlRegexp;

        [Option('F', "fixed-strings")]
        public readonly bool fixedStrings;

        [Option('n', "line-number")]
        public readonly bool lineNumber;

        [Option("name-only", MutuallyExclusive = "matches")]
        [Option('l', "files-with-matches", MutuallyExclusive = "matches")]
        public readonly bool filesWithMatches;

        [Option('L', "files-without-matches", MutuallyExclusive = "matches")]
        public readonly bool filesWithoutMatches;

        [Option('O', "open-files-in-pager")]
        public readonly string openFilesInPager;

        [Option('z', "null")]
        public readonly bool @null;

        [Option("all-match")]
        public readonly bool allMatch;

        [Option('q', "quiet")]
        public readonly bool quiet;

        [Option("max-depth")]
        public readonly int maxDepth;

        [Option("color", MutuallyExclusive = "color")]
        public readonly Color color = Color.ALWAYS;

        [Option("no-color", MutuallyExclusive = "color")]
        public readonly bool noColor;

        [Option("break")]
        public readonly bool @break;

        [Option("heading")]
        public readonly bool heading;

        [Option('p', "show-function")]
        public readonly bool showFunction;

        [Option('A', "after-context")]
        public readonly int afterContext;

        [Option('B', "before-context")]
        public readonly int beforeContext;

        [Option('C', "context")]
        public readonly int context;

        [Option('W', "function-context")]
        public readonly bool functionContext;

        [Option('f')]
        public readonly string file;

        [Option('e')]
        public readonly string pattern;

        [Option("and")]
        public readonly string and;

        [Option("or")]
        public readonly string or;

        [Option("not")]
        public readonly string not;

        [Option("exclude-standard", MutuallyExclusive = "std")]
        public readonly bool excludeStandard;

        [Option("no-exclude-standard", MutuallyExclusive = "std")]
        public readonly bool noExcludeStandard;

        [Option("cached", MutuallyExclusive = "search")]
        public readonly bool cached;

        [Option("no-index", MutuallyExclusive = "search")]
        public readonly bool noIndex;

        [Option("untracked", MutuallyExclusive = "search")]
        public readonly bool untracked;

        [Value(0)]
        public readonly string[] extra;
    }
}
