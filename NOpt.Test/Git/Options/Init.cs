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
        public bool quiet { get; set; }

        [Option("bare")]
        public bool bare { get; set; }

        [Option("template")]
        public string template { get; set; }

        [Option("separate-git-dir")]
        public string separateGitDir { get; set; }

        [Option("shared")]
        public string shared { get; set; }

        [Value(0)]
        public string dir { get; set; }
    }
}
