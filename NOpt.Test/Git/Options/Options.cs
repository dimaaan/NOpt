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

        [Verb("Am")]
        public Am am;
        // TODO command <args>
    }
}
