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
                public bool opt1 { get; set; } // will be "file1"

                [Option('b')]
                public bool opt2 { get; set; } // will be "file2"

                [Option('c')]
                public bool opt3 { get; set; } // will be null
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
                public string file { get; set; }

                [Option("action")]
                public bool action { get; set; }
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
                public string file { get; set; }
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
                public string file { get; set; }
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
                public bool a { get; set; }

                [Option('b', "bb", MutuallyExclusive = "mut")]
                public bool b { get; set; }

                [Option('c', MutuallyExclusive = "mut2")]
                public bool c { get; set; }

                [Option('d')]
                public bool d { get; set; }
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

        public class Arrays
        {
            public class Options
            {
                [Option('s', "str")]
                public string[] strings { get; set; }

                [Option('b')]
                public bool b { get; set; }
            }

            [Fact]
            public void check()
            {
                Options opt;

                opt = NOpt.Parse<Options>(new string[] { "-s"});
                Assert.True(opt.strings == null && !opt.b);

                opt = NOpt.Parse<Options>(new string[] { "-s", "a", "b", "a" });
                Assert.True(opt.strings[0] == "a");
                Assert.True(opt.strings[1] == "b");
                Assert.True(opt.strings[2] == "a");
                Assert.False(opt.b);

                opt = NOpt.Parse<Options>(new string[] { "-s", "a", "b", "-b" });
                Assert.True(opt.strings[0] == "a");
                Assert.True(opt.strings[1] == "b");
                Assert.True(opt.b);

                opt = NOpt.Parse<Options>(new string[] { "--str", "a" });
                Assert.True(opt.strings[0] == "a");

                Assert.Throws<FormatException>(() => NOpt.Parse<Options>(new string[] { "--str", "a", "-err" }));

                Assert.Throws<FormatException>(() => NOpt.Parse<Options>(new string[] { "--str=a", "a", "-err" }));
            }
        }
    }
}
