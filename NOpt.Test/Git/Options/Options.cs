using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
      git   [--version] [--help] [-C <path>] [-c name=value]
            [--exec-path[=<path>]] [--html-path] [--man-path] [--info-path]
            [-p|--paginate|--no-pager] [--no-replace-objects] [--bare]
            [--git-dir=<path>] [--work-tree=<path>] [--namespace=<name>]
            <command> [<args>]
    */
    public class Options
    {
        [Option("version")]
        public bool version { get; set; }

        [Option("help")]
        public bool help { get; set; }

        [Option('C')]
        public string C { get; set; }

        [Option('c')]
        public string c { get; set; }

        [Option("exec-path")]
        public string execPath { get; set; }

        [Option("html-path")]
        public bool htmlPath { get; set; }

        [Option("man-path")]
        public bool manPath { get; set; }

        [Option("info-path")]
        public bool infoPath { get; set; }

        [Option('p', "paginate")]
        public bool p { get; set; }

        [Option("no-pager")]
        public bool noPager { get; set; }

        [Option("no-replace-objects")]
        public bool noReplaceObjects { get; set; }

        [Option("bare")]
        public bool bare { get; set; }

        [Option("git-dir")]
        public string gitDir { get; set; }

        [Option("work-tree")]
        public string workTree { get; set; }

        [Option("namespace")]
        public string @namespace { get; set; }

        [Verb("add")]
        public Add add { get; set; }

        [Verb("am")]
        public Am am { get; set; }

        [Verb("archive")]
        public Archive archive { get; set; }

        [Verb("bisect")]
        public Bisect bisect { get; set; }

        [Verb("branch")]
        public Branch branch { get; set; }

        [Verb("bundle")]
        public Bundle bundle { get; set; }

        [Verb("checkout")]
        public Checkout checkout { get; set; }

        [Verb("cherry-pick")]
        public CherryPick CherryPick { get; set; }

        [Verb("citool")]
        public Citool citool { get; set; }

        [Verb("clean")]
        public Clean clean { get; set; }

        [Verb("clone")]
        public Clone Clone { get; set; }

        [Verb("commit")]
        public Commit commit { get; set; }

        [Verb("describe")]
        public Describe describe { get; set; }

        [Verb("diff")]
        public Diff diff { get; set; }

        [Verb("fetch")]
        public Fetch fetch { get; set; }

        [Verb("format-patch")]
        public FormatPatch formatPatch { get; set; }

        [Verb("gc")]
        public Gc gc { get; set; }

        [Verb("grep")]
        public Grep grep { get; set; }

        [Verb("gui")]
        public Gui gui { get; set; }

        [Verb("init")]
        public Init init { get; set; }

        [Verb("log")]
        public Log log { get; set; }

        [Verb("merge")]
        public Merge merge { get; set; }

        [Verb("mv")]
        public Mv mv { get; set; }

        [Verb("notes")]
        public Mv notes { get; set; }

        [Verb("pulll")]
        public Pull pull { get; set; }

        [Verb("push")]
        public Push push { get; set; }

        [Verb("rebase")]
        public Rebase rebase { get; set; }

        [Verb("reset")]
        public Reset reset { get; set; }

        [Verb("revert")]
        public Revert revert { get; set; }

        [Verb("rm")]
        public Rm rm { get; set; }

        [Verb("shortlog")]
        public ShortLog shortLog { get; set; }

        [Verb("show")]
        public Show show { get; set; }

        [Verb("stash")]
        public Stash stash { get; set; }

        [Verb("status")]
        public Status status { get; set; }

        [Verb("submodule")]
        public Submodule submodule { get; set; }

        [Verb("tag")]
        public Tag tag { get; set; }
    }
}
