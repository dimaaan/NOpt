using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOpt.Test.Git.Options
{
    /*
    git init    [-q | --quiet] [--bare] [--template=<template_directory>]
                [--separate-git-dir <git dir>]
                [--shared[=<permissions>]] [directory]
    */
    public class Init
    {
        [Option('q', "quiet")]
        public readonly bool quiet;

        [Option("bare")]
        public readonly bool bare;

        [Option("template")]
        public readonly string template;

        [Option("separate-git-dir")]
        public readonly string separateGitDir;

        [Option("shared")]
        public readonly string shared;

        [Value(0)]
        public readonly string dir;
    }
}
