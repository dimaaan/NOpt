using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
    git notes [list [<object>]]
    git notes add [-f] [-F <file> | -m <msg> | (-c | -C) <object>] [<object>]
    git notes copy [-f] ( --stdin | <from-object> <to-object> )
    git notes append [-F <file> | -m <msg> | (-c | -C) <object>] [<object>]
    git notes edit [<object>]
    git notes show [<object>]
    git notes merge [-v | -q] [-s <strategy> ] <notes-ref>
    git notes merge --commit [-v | -q]
    git notes merge --abort [-v | -q]
    git notes remove [--ignore-missing] [--stdin] [<object>…]
    git notes prune [-n | -v]
    git notes get-ref
    */
    public class Notes
    {
        public enum Command { LIST, ADD, COPY, APPEND, EDIT, SHOW, MERGE, REMOVE, PRUNE, GET_REF };

        public enum Strategy { MANUAL, OURS, THEIRS, UNION, CAT_SORT_UNIQ };

        [Value(0)]
        public Command command { get; set; } = Command.LIST;

        [Option('f', "force")]
        public bool force { get; set; }

        [Option('m', "message")]
        public string message { get; set; }

        [Option('F', "file")]
        public string file { get; set; }

        [Option('C', "reuse-message")]
        public string reuseMessage { get; set; }

        [Option('c', "reedit-message")]
        public string reeditMessage { get; set; }

        [Option("ref")]
        public string @ref { get; set; }

        [Option("ignore-missing")]
        public bool ignoreMissing { get; set; }

        [Option("stdin")]
        public bool stdin { get; set; }

        [Option('n', "dry-run")]
        public bool dryRun { get; set; }

        [Option('s', "strategy")]
        public Strategy strategy { get; set; } = Strategy.MANUAL;

        [Option("commit")]
        public bool commit { get; set; }

        [Option("abort")]
        public bool abort { get; set; }

        [Option('q', "quiet")]
        public bool quiet { get; set; }

        [Option('v', "verbose")]
        public bool verbose { get; set; }
    }
}
