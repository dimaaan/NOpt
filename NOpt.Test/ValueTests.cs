using System;
using Xunit;

namespace NOpt.Test
{
    public class Values
    {
        public class FourOptions
        {
            public class Options4
            {
                [Value(0)]
                public string Opt1 { get; set; } // will be "file1"

                [Value(1)]
                public string Opt2 { get; set; } // will be "file2"

                [Value(2)]
                public string Opt3 { get; set; } // will be null

                [Value(3)]
                public string Opt4 { get; set; } = "default value"; // will be "default"
            }

            [Fact]
            public void Check()
            {
                Options4 opt = NOpt.Parse<Options4>(new string[] { "file1", "file2" });
                Assert.Equal("file1", opt.Opt1);
                Assert.Equal("file2", opt.Opt2);
                Assert.Equal(null, opt.Opt3);
                Assert.Equal("default value", opt.Opt4);
            }

            [Fact]
            public void CheckEmpty()
            {
                Options4 opt = NOpt.Parse<Options4>(new string[] { null });
                Assert.Equal(null, opt.Opt1);
                Assert.Equal(null, opt.Opt2);
                Assert.Equal(null, opt.Opt3);
                Assert.Equal("default value", opt.Opt4);
            }

            [Fact]
            public void CheckNull()
            {
                Assert.Throws<ArgumentNullException>(() => NOpt.Parse<Options4>(null));
            }
        }
    }
}
