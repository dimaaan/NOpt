using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NOpt.Test
{
    public class OptionsTest
    {
        // program.exe -abc
        public class ThreeShortOption
        {
            public class Options
            {
                [Option('a')]
                public readonly bool opt1; // will be "file1"

                [Option('b')]
                public readonly bool opt2; // will be "file2"

                [Option('c')]
                public readonly bool opt3; // will be null
            }

            private Options parse(params string[] args)
            {
                return NOpt.Parse<Options>(args);
            }

            [Fact]
            public void checkNull()
            {

            }

            [Fact]
            public void checkabc()
            {
                Options opt = parse("-abc");
                Assert.True(opt.opt1 && opt.opt2 && opt.opt3);
            }

            [Fact]
            public void checkDublicate()
            {
                Options opt = parse("-aa");
                Assert.True(opt.opt1 && !opt.opt2 && !opt.opt3);
            }

            [Fact]
            public void checkDublicateShortSyntax()
            {
                Options opt = parse(new string[] { "-a", "-a" });
                Assert.True(opt.opt1 && !opt.opt2 && !opt.opt3);
            }
        }


        public class LongOption
        {
            public class Options
            {
                [Option('f', LongName = "file")]
                public readonly string file;

                [Option("action")]
                public readonly bool action;
            }

            private Options parse(params string[] args)
            {
                return NOpt.Parse<Options>(args);
            }

            [Fact]
            public void check()
            {
                Options opt = parse("--file", "readme.txt", "--action");
                Assert.Equal("readme.txt", opt.file);
                Assert.True(opt.action);
            }

            [Fact]
            public void checkDublicate()
            {
                Options opt = parse("--file", "--file");
                Assert.Equal("--file", opt.file);
                Assert.False(opt.action);
            }
        }
    }
}
