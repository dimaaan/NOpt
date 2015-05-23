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
        public bool bare;

        [Option("git-dir")]
        public string gitDir;

        [Option("work-tree")]
        public string workTree;

        [Option("namespace")]
        public string @namespace;

        [Verb("add")]
        public Add add;

        [Verb("am")]
        public Am am;

        [Verb("archive")]
        public Archive archive;

        [Verb("bisect")]
        public Bisect bisect;

        [Verb("branch")]
        public Branch branch;

        [Verb("bundle")]
        public Bundle bundle;

        [Verb("checkout")]
        public Checkout checkout;

        [Verb("cherry-pick")]
        public CherryPick CherryPick;

        [Verb("citool")]
        public Citool citool;

        [Verb("clean")]
        public Clean clean;

        [Verb("clone")]
        public Clone Clone;

        [Verb("commit")]
        public Commit commit;

        [Verb("describe")]
        public Describe describe;

        [Verb("diff")]
        public Diff diff;

        [Verb("fetch")]
        public Fetch fetch;

        [Verb("format-patch")]
        public FormatPatch formatPatch;

        [Verb("gc")]
        public Gc gc;

        [Verb("grep")]
        public Grep grep;

        [Verb("gui")]
        public Gui gui;

        [Verb("init")]
        public Init init;

        [Verb("log")]
        public Log log;

        [Verb("merge")]
        public Merge merge;

        [Verb("mv")]
        public Mv mv;

        [Verb("notes")]
        public Mv notes;

        [Verb("pulll")]
        public Pull pull;

        [Verb("push")]
        public Push push;

        [Verb("rebase")]
        public Rebase rebase;

        [Verb("reset")]
        public Reset reset;

        [Verb("revert")]
        public Revert revert;

        [Verb("rm")]
        public Rm rm;

        [Verb("shortlog")]
        public ShortLog shortLog;

        [Verb("show")]
        public Show show;

        [Verb("stash")]
        public Stash stash;

        [Verb("status")]
        public Status status;

        [Verb("submodule")]
        public Submodule submodule;

        [Verb("tag")]
        public Tag tag;
    }
}
