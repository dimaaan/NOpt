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
        public bool patch { get; set; }

        [Option('s', "no-patch")]
        public bool noPatch { get; set; }

        [Option('u', "unified")]
        public bool unified { get; set; }

        [Option("raw")]
        public bool raw { get; set; }

        [Option("patch-with-raw")]
        public bool patchWithRaw { get; set; }

        [Option("minimal")]
        public bool minimal { get; set; }

        [Option("patience")]
        public bool patience { get; set; }

        [Option("histogram")]
        public bool histogram { get; set; }

        [Option("diff-algorithm")]
        public DiffAlgorithm diffAlgorithm { get; set; } = DiffAlgorithm.MYERS;

        [Option("stat")]
        public string stat { get; set; }

        [Option("numstat")]
        public bool numstat { get; set; }

        [Option("shortstat")]
        public bool shortstat { get; set; }

        [Option("dirstat")]
        public string dirstat { get; set; }

        [Option("summary")]
        public bool summary { get; set; }

        [Option("patch-with-stat")]
        public bool patchWithStat { get; set; }

        [Option('z')]
        public bool z { get; set; }

        [Option("name-only")]
        public bool nameOnly { get; set; }

        [Option("name-status")]
        public bool nameStatus { get; set; }

        [Option("submodule")]
        public string submodule { get; set; }

        [Option("color")]
        public Color color { get; set; }

        [Option("no-color")]
        public bool noColor { get; set; }

        [Option("word-diff")]
        public WordDiffMode wordDiff { get; set; } = WordDiffMode.PLAIN;

        [Option("word-diff-regex")]
        public string wordDiffRegex { get; set; }

        [Option("color-words")]
        public string colorWords { get; set; }

        [Option("no-renames")]
        public bool noRenames { get; set; }

        [Option("check")]
        public bool check { get; set; }

        [Option("full-index")]
        public bool fullIndex { get; set; }

        [Option("binary")]
        public bool binary { get; set; }

        [Option("abbrev")]
        public int abbrev { get; set; }

        [Option('B', "break-rewrites")]
        public string[] breakRewrites { get; set; }

        [Option('M', "find-renames")]
        public int findRenames { get; set; }

        [Option('C', "find-copies")]
        public int findCopies { get; set; }

        [Option("find-copies-harder")]
        public bool findCopiesHarder { get; set; }

        [Option('D', "irreversible-delete")]
        public bool irreversibleDelete { get; set; }

        [Option('l')]
        public int l { get; set; }

        [Option('S')]
        public string S { get; set; }

        [Option('G')]
        public string G { get; set; }

        [Option("pickaxe-all")]
        public bool pickaxeAll { get; set; }

        [Option("pickaxe-regex")]
        public bool pickaxeRegex { get; set; }

        [Option('O')]
        public string O { get; set; }

        [Option('R')]
        public bool R { get; set; }

        [Option("relative")]
        public string relative { get; set; }

        [Option('a', "text")]
        public bool text { get; set; }

        [Option("ignore-space-at-eol")]
        public bool ignoreSpaceAtEol { get; set; }

        [Option('b', "ignore-space-change")]
        public bool ignoreSpaceChange { get; set; }

        [Option('w', "ignore-all-space")]
        public bool ignoreAllSpace { get; set; }

        [Option("ignore-blank-lines")]
        public bool ignoreBlankLines { get; set; }

        [Option("inter-hunk-context")]
        public string interHunkContext { get; set; }

        [Option('W', "function-context")]
        public bool functionContext { get; set; }

        [Option("exit-code")]
        public bool exitCode { get; set; }

        [Option("quiet")]
        public bool quiet { get; set; }

        [Option("ext-diff")]
        public bool extDiff { get; set; }

        [Option("no-ext-diff")]
        public bool noExtDiff { get; set; }

        [Option("textconv")]
        public bool textconv { get; set; }

        [Option("no-textconv")]
        public bool noTextconv { get; set; }

        [Option("ignore-submodules")]
        public IgnoreSubmodules ignoreSubmodules { get; set; } = IgnoreSubmodules.ALL;

        [Option("src-prefix")]
        public string srcPrefix { get; set; }

        [Option("dst-prefix")]
        public string dstPrefix { get; set; }

        [Option("no-prefix")]
        public string noPrefix { get; set; }

        [Value(0)]
        public string[] extras;
    }
}
