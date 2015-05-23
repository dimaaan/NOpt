using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
    git clone [--template=<template_directory>]
          [-l] [-s] [--no-hardlinks] [-q] [-n] [--bare] [--mirror]
          [-o <name>] [-b <name>] [-u <upload-pack>] [--reference <repository>]
          [--separate-git-dir <git dir>]
          [--depth <depth>] [--[no-]single-branch]
          [--recursive | --recurse-submodules] [--] <repository>
          [<directory>]
    */
    public class Clone
    {
        [Option("template")]
        public string template { get; set; }

        [Option('l', "local")]
        public bool local { get; set; }

        [Option('s', "shared")]
        public bool shared { get; set; }

        [Option("no-hardlinks")]
        public bool noHardlinks { get; set; }

        [Option('q', "quiet")]
        public bool quiet { get; set; }

        [Option('n', "no-checkout")]
        public bool noCheckout { get; set; }

        [Option("bare")]
        public bool bare { get; set; }

        [Option("mirror")]
        public bool mirror { get; set; }

        [Option('o', "origin")]
        public string origin { get; set; }

        [Option('b', "branch")]
        public string branch { get; set; }

        [Option('u', "upload-pack")]
        public string uploadPack { get; set; }

        [Option("reference")]
        public string reference { get; set; }

        [Option("separate-git-dir")]
        public string separateGitDir { get; set; }

        [Option("depth")]
        public uint depth { get; set; }

        [Option("single-branch", MutuallyExclusive = "single-branch")]
        public bool singleBranch { get; set; }

        [Option("no-single-branch", MutuallyExclusive = "single-branch")]
        public bool noSingleBranch { get; set; }

        [Option("recursive", MutuallyExclusive = "recursive")]
        public bool recursive { get; set; }

        [Option("recurse-submodules", MutuallyExclusive = "recursive")]
        public bool recursiveSubmodules { get; set; }

        [Value(0)]
        public string repository { get; set; }

        [Value(1)]
        public string directory { get; set; }
    }
}
