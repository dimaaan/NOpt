using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    public class Diff
    {
        public enum DiffAlgorithm { PATIENCE, MINIMAL, HISTOGRAMM, MYERS }

        public enum Color { ALWAYS, NEVER, AUTO }

        public enum WordDiffMode { COLOR, PLAIN, PORCELAIN, NONE }

        public enum IgnoreSubmodules { NONE, UNTRACKED, DIRTY, ALL }

        [Option('u')]
        [Option('p', "patch")]
        public readonly bool patch;

        [Option('s', "no-patch")]
        public readonly bool noPatch;

        [Option('u', "unified")]
        public readonly bool unified;

        [Option("raw")]
        public readonly bool raw;

        [Option("patch-with-raw")]
        public readonly bool patchWithRaw;

        [Option("minimal")]
        public readonly bool minimal;

        [Option("patience")]
        public readonly bool patience;

        [Option("histogram")]
        public readonly bool histogram;

        [Option("diff-algorithm")]
        public readonly DiffAlgorithm diffAlgorithm=DiffAlgorithm.MYERS;

        [Option("stat")]
        public readonly string stat;

        [Option("numstat")]
        public readonly bool numstat;

        [Option("shortstat")]
        public readonly bool shortstat;

        [Option("dirstat")]
        public readonly string dirstat;

        [Option("summary")]
        public readonly bool summary;

        [Option("patch-with-stat")]
        public readonly bool patchWithStat;

        [Option('z')]
        public readonly bool z;

        [Option("name-only")]
        public readonly bool nameOnly;

        [Option("name-status")]
        public readonly bool nameStatus;

        [Option("submodule")]
        public readonly string submodule;

        [Option("color")]
        public readonly Color color;

        [Option("no-color")]
        public readonly bool noColor;

        [Option("word-diff")]
        public readonly WordDiffMode wordDiff=WordDiffMode.PLAIN;

        [Option("word-diff-regex")]
        public readonly string wordDiffRegex;

        [Option("color-words")]
        public readonly string colorWords;

        [Option("no-renames")]
        public readonly bool noRenames;

        [Option("check")]
        public readonly bool check;

        [Option("full-index")]
        public readonly bool fullIndex;

        [Option("binary")]
        public readonly bool binary;

        [Option("abbrev")]
        public readonly int abbrev;

        [Option('B', "break-rewrites")]
        public readonly  string[] breakRewrites;

        [Option('M', "find-renames")]
        public readonly int findRenames;

        [Option('C', "find-copies")]
        public readonly int findCopies;

        [Option("find-copies-harder")]
        public readonly bool findCopiesHarder;

        [Option('D', "irreversible-delete")]
        public readonly bool irreversibleDelete;

        [Option('l')]
        public readonly int l;

        [Option('S')]
        public readonly string S;

        [Option('G')]
        public readonly string G;

        [Option("pickaxe-all")]
        public readonly bool pickaxeAll;

        [Option("pickaxe-regex")]
        public readonly bool pickaxeRegex;

        [Option('O')]
        public readonly string O;

        [Option('R')]
        public readonly bool R;

        [Option("relative")]
        public readonly string relative;

        [Option('a', "text")]
        public readonly bool text;

        [Option("ignore-space-at-eol")]
        public readonly bool ignoreSpaceAtEol;

        [Option('b', "ignore-space-change")]
        public readonly bool ignoreSpaceChange;

        [Option('w', "ignore-all-space")]
        public readonly bool ignoreAllSpace;

        [Option("ignore-blank-lines")]
        public readonly bool ignoreBlankLines;

        [Option("inter-hunk-context")]
        public readonly string interHunkContext;

        [Option('W', "function-context")]
        public readonly bool functionContext;

        [Option("exit-code")]
        public readonly bool exitCode;

        [Option("quiet")]
        public readonly bool quiet;

        [Option("ext-diff")]
        public readonly bool extDiff;

        [Option("no-ext-diff")]
        public readonly bool noExtDiff;

        [Option("textconv")]
        public readonly bool textconv;

        [Option("no-textconv")]
        public readonly bool noTextconv;

        [Option("ignore-submodules")]
        public readonly IgnoreSubmodules ignoreSubmodules=IgnoreSubmodules.ALL;

        [Option("src-prefix")]
        public readonly string srcPrefix;

        [Option("dst-prefix")]
        public readonly string dstPrefix;

        [Option("no-prefix")]
        public readonly string noPrefix;

        [Value(0)]
        public readonly string[] extras;
    }
}
