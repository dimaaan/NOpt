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
        public readonly Command command = Command.LIST;

        [Option('f', "force")]
        public readonly bool force;

        [Option('m', "message")]
        public readonly string message;

        [Option('F', "file")]
        public readonly string file;

        [Option('C', "reuse-message")]
        public readonly string reuseMessage;

        [Option('c', "reedit-message")]
        public readonly string reeditMessage;

        [Option("ref")]
        public readonly string @ref;

        [Option("ignore-missing")]
        public readonly bool ignoreMissing;

        [Option("stdin")]
        public readonly bool stdin;

        [Option('n', "dry-run")]
        public readonly bool dryRun;

        [Option('s', "strategy")]
        public readonly Strategy strategy = Strategy.MANUAL;

        [Option("commit")]
        public readonly bool commit;

        [Option("abort")]
        public readonly bool abort;

        [Option('q', "quiet")]
        public readonly bool quiet;

        [Option('v', "verbose")]
        public readonly bool verbose;
    }
}
