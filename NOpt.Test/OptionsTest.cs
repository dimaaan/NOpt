using System;
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
                public bool Opt1 { get; set; }

                [Option('b')]
                public bool Opt2 { get; set; }

                [Option('c')]
                public bool Opt3 { get; set; }
            }

            private Options Parse(params string[] args)
            {
                return NOpt.Parse<Options>(args);
            }

            [Fact]
            public void ShouldThrowOnNull()
            {
                Assert.Throws<ArgumentNullException>(() => Parse(null));
            }

            [Theory]
            [InlineData(new object[] { new string[] { } })]
            [InlineData(new object[] { new string[] { null } })]
            [InlineData(new object[] { new string[] { null, null } })]
            [InlineData(new object[] { new string[] { null, null, null } })]
            [InlineData(new object[] { new string[] { null, null, null, null } })]
            public void ShouldLeaveDefaultValuesOnArrayWithNulls(string[] args)
            {
                Options opt = Parse(args);
                Assert.False(opt.Opt1 && opt.Opt2 && opt.Opt3);
            }

            [Theory]
            [InlineData("")]
            [InlineData("-")]
            [InlineData("--")]
            public void ShouldThrowOnBadStrings(string input)
            {
                Assert.Throws<FormatException>(() => Parse(input));
            }

            [Theory]
            [InlineData(true, false, false, "-a")]
            [InlineData(false, true, false, "-b")]
            [InlineData(false, false, true, "-c")]
            [InlineData(true, true, true, "-abc")]
            [InlineData(false, true, true, "-bc")]
            [InlineData(true, false, false, "-aa")] // TODO fail??
            [InlineData(true, true, true, "-a", "-b", "-c")]
            [InlineData(false, true, true, "-b", "-c")]
            [InlineData(true, false, false, "-a", "-a")] // TODO fail??
            public void ShouldParse(bool expectedOpt1, bool expectedOpt2, bool expectedOpt3, params string[] input)
            {
                Options opt = Parse(input);

                Assert.True(opt.Opt1 == expectedOpt1);
                Assert.True(opt.Opt2 == expectedOpt2);
                Assert.True(opt.Opt3 == expectedOpt3);
            }
        }


        public class LongOption
        {
            public class Options
            {
                [Option('f', LongName = "file")]
                public string File { get; set; }

                [Option("action")]
                public bool Action { get; set; }
            }

            private Options Parse(params string[] args)
            {
                return NOpt.Parse<Options>(args);
            }

            [Fact]
            public void Check()
            {
                Options opt = Parse("--file", "readme.txt", "--action");
                Assert.Equal("readme.txt", opt.File);
                Assert.True(opt.Action);
            }

            [Fact]
            public void CheckDublicate()
            {
                Options opt = Parse("--file", "--file");
                Assert.Equal("--file", opt.File);
                Assert.False(opt.Action);
            }
        }

        public class DublicateShortLongNames
        {
            public class Options
            {
                [Option('f', LongName = "f")]
                public string File { get; set; }
            }

            [Fact]
            public void CheckDublicate()
            {
                Assert.Throws<ArgumentException>(() => NOpt.Parse<Options>(new string[] { "--file", "--file" }));
            }
        }

        public class AttachedValue
        {
            public class Options
            {
                [Option("file")]
                public string File { get; set; }
            }

            [Fact]
            public void Check()
            {
                Options opt;

                opt = NOpt.Parse<Options>(new string[] { "--file=file.txt" });
                Assert.Equal("file.txt", opt.File);

                opt = NOpt.Parse<Options>(new string[] { "--file==file.txt" });
                Assert.Equal("=file.txt", opt.File);

                Assert.Throws<FormatException>(() => NOpt.Parse<Options>(new string[] { "--file=" }));
            }
        }

        public class MutuallyExclusive
        {
            public class Options
            {
                [Option('a', MutuallyExclusive = "mut")]
                public bool A { get; set; }

                [Option('b', "bb", MutuallyExclusive = "mut")]
                public bool B { get; set; }

                [Option('c', MutuallyExclusive = "mut2")]
                public bool C { get; set; }

                [Option('d')]
                public bool D { get; set; }
            }

            private Options Parse(params string[] args)
            {
                return NOpt.Parse<Options>(args);
            }

            [Fact]
            public void Check()
            {
                Options opt;

                Assert.Throws<FormatException>(() => Parse("-abcd"));
                Assert.Throws<FormatException>(() => Parse("-a", "--bb"));
                Assert.Throws<FormatException>(() => Parse("-a", "-b"));
                Assert.Throws<FormatException>(() => Parse("-bb"));
                Assert.Throws<FormatException>(() => Parse("--b", "--bb"));

                opt = Parse("-a", "-c", "-d");
                Assert.True(opt.A && !opt.B && opt.C && opt.D);

                opt = Parse("-c");
                Assert.True(!opt.A && !opt.B && opt.C && !opt.D);
            }
        }

        public class Arrays
        {
            public class Options
            {
                [Option('s', "str")]
                public string[] Strings { get; set; }

                [Option('b')]
                public bool B { get; set; }
            }

            [Fact]
            public void Check()
            {
                Options opt;

                opt = NOpt.Parse<Options>(new string[] { "-s"});
                Assert.True(opt.Strings == null && !opt.B);

                opt = NOpt.Parse<Options>(new string[] { "-s", "a", "b", "a" });
                Assert.True(opt.Strings[0] == "a");
                Assert.True(opt.Strings[1] == "b");
                Assert.True(opt.Strings[2] == "a");
                Assert.False(opt.B);

                opt = NOpt.Parse<Options>(new string[] { "-s", "a", "b", "-b" });
                Assert.True(opt.Strings[0] == "a");
                Assert.True(opt.Strings[1] == "b");
                Assert.True(opt.B);

                opt = NOpt.Parse<Options>(new string[] { "--str", "a" });
                Assert.True(opt.Strings[0] == "a");

                Assert.Throws<FormatException>(() => NOpt.Parse<Options>(new string[] { "--str", "a", "-err" }));

                Assert.Throws<FormatException>(() => NOpt.Parse<Options>(new string[] { "--str=a", "a", "-err" }));
            }
        }
    }
}
