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
        public readonly string template;

        [Option('l', "local")]
        public readonly bool local;

        [Option('s', "shared")]
        public readonly bool shared;

        [Option("no-hardlinks")]
        public readonly bool noHardlinks;

        [Option('q', "quiet")]
        public readonly bool quiet;

        [Option('n', "no-checkout")]
        public readonly bool noCheckout;

        [Option("bare")]
        public readonly bool bare;

        [Option("mirror")]
        public readonly bool mirror;

        [Option('o', "origin")]
        public readonly string origin;

        [Option('b', "branch")]
        public readonly string branch;

        [Option('u', "upload-pack")]
        public readonly string uploadPack;

        [Option("reference")]
        public readonly string reference;

        [Option("separate-git-dir")]
        public readonly string separateGitDir;

        [Option("depth")]
        public readonly uint depth;

        [Option("single-branch", MutuallyExclusive = "single-branch")]
        public readonly bool singleBranch;

        [Option("no-single-branch", MutuallyExclusive = "single-branch")]
        public readonly bool noSingleBranch;

        [Option("recursive", MutuallyExclusive = "recursive")]
        public readonly bool recursive;

        [Option("recurse-submodules", MutuallyExclusive = "recursive")]
        public readonly bool recursiveSubmodules;

        [Value(0)]
        public readonly string repository;

        [Value(1)]
        public readonly string directory;
    }
}
