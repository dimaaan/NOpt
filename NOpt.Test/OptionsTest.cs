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
            public void check()
            {
                Assert.Throws<ArgumentNullException>(() => parse(null));

                Options opt;

                opt = parse(new string[] { });
                Assert.False(opt.opt1 && opt.opt2 && opt.opt3);

                opt = parse(new string[] { null });
                Assert.False(opt.opt1 && opt.opt2 && opt.opt3);

                opt = parse(new string[] { null, null });
                Assert.False(opt.opt1 && opt.opt2 && opt.opt3);

                Assert.Throws<FormatException>(() => parse(""));

                Assert.Throws<FormatException>(() => parse("--"));

                Assert.Throws<FormatException>(() => opt = parse("-"));

                opt = parse("-a");
                Assert.True(opt.opt1 && !opt.opt2 && !opt.opt3);

                opt = parse("-b");
                Assert.True(!opt.opt1 && opt.opt2 && !opt.opt3);

                opt = parse("-c");
                Assert.True(!opt.opt1 && !opt.opt2 && opt.opt3);

                opt = parse("-abc");
                Assert.True(opt.opt1 && opt.opt2 && opt.opt3);

                opt = parse("-bc");
                Assert.True(!opt.opt1 && opt.opt2 && opt.opt3);

                opt = parse("-aa");
                Assert.True(opt.opt1 && !opt.opt2 && !opt.opt3);

                opt = parse("-a", "-b", "-c");
                Assert.True(opt.opt1 && opt.opt2 && opt.opt3);

                opt = parse("-b", "-c");
                Assert.True(!opt.opt1 && opt.opt2 && opt.opt3);

                opt = parse("-a", "-a" );
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

        public class DublicateShortLongNames
        {
            public class Options
            {
                [Option('f', LongName = "f")]
                public readonly string file;
            }

            [Fact]
            public void checkDublicate()
            {
                Assert.Throws<ArgumentException>(() => NOpt.Parse<Options>(new string[] { "--file", "--file" }));
            }
        }

        public class AttachedValue
        {
            public class Options
            {
                [Option("file")]
                public readonly string file;
            }

            [Fact]
            public void check()
            {
                Options opt;

                opt = NOpt.Parse<Options>(new string[] { "--file=file.txt" });
                Assert.Equal("file.txt", opt.file);

                opt = NOpt.Parse<Options>(new string[] { "--file==file.txt" });
                Assert.Equal("=file.txt", opt.file);

                Assert.Throws<FormatException>(() => NOpt.Parse<Options>(new string[] { "--file=" }));
            }
        }

        public class MutuallyExclusive
        {
            public class Options
            {
                [Option('a', MutuallyExclusive = "mut")]
                public readonly bool a;

                [Option('b', "bb", MutuallyExclusive = "mut")]
                public readonly bool b;

                [Option('c', MutuallyExclusive = "mut2")]
                public readonly bool c;

                [Option('d')]
                public readonly bool d;
            }

            private Options parse(params string[] args)
            {
                return NOpt.Parse<Options>(args);
            }

            [Fact]
            public void check()
            {
                Options opt;

                Assert.Throws<FormatException>(() => parse("-abcd"));
                Assert.Throws<FormatException>(() => parse("-a", "--bb"));
                Assert.Throws<FormatException>(() => parse("-a", "-b"));
                Assert.Throws<FormatException>(() => parse("-bb"));
                Assert.Throws<FormatException>(() => parse("--b", "--bb"));

                opt = parse("-a", "-c", "-d");
                Assert.True(opt.a && !opt.b && opt.c && opt.d);

                opt = parse("-c");
                Assert.True(!opt.a && !opt.b && opt.c && !opt.d);
            }
        }
    }
}
