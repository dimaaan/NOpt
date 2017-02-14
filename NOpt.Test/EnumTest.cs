using System;
using Xunit;

namespace NOpt.Test
{
    // TODO test with flags and integers
    public class EnumTest
    {
        public class ValueEnumTest
        {
            public class Options
            {
                [Flags]
                public enum Actions
                {
                    READ = 1, WRITE = 2, READ_WRITE = 4
                }

                [Value(0)]
                public Actions actions { get; set; }
            }

            [Fact]
            public void check()
            {
                Options opt;
                
                opt = NOpt.Parse<Options>(new string[] { "WRITE" });
                Assert.Equal(Options.Actions.WRITE, opt.actions);

                opt = NOpt.Parse<Options>(new string[] { "WrItE" });
                Assert.Equal(Options.Actions.WRITE, opt.actions);

                opt = NOpt.Parse<Options>(new string[] { "read_write" });
                Assert.Equal(Options.Actions.READ_WRITE, opt.actions);

                opt = NOpt.Parse<Options>(new string[] { "READ_WRITE" });
                Assert.Equal(Options.Actions.READ_WRITE, opt.actions);

                opt = NOpt.Parse<Options>(new string[] { "READ-WRITE" });
                Assert.Equal(Options.Actions.READ_WRITE, opt.actions);

                opt = NOpt.Parse<Options>(new string[] { "read-WRITE" });
                Assert.Equal(Options.Actions.READ_WRITE, opt.actions);

                opt = NOpt.Parse<Options>(new string[] { "read-write" });
                Assert.Equal(Options.Actions.READ_WRITE, opt.actions);

                opt = NOpt.Parse<Options>(new string[] { "read,write" });
                Assert.Equal(Options.Actions.READ | Options.Actions.WRITE, opt.actions);

                opt = NOpt.Parse<Options>(new string[] { "read,write,read-write" });
                Assert.Equal(Options.Actions.READ | Options.Actions.WRITE | Options.Actions.READ_WRITE, opt.actions);

                Assert.Throws<FormatException>(() => NOpt.Parse<Options>(new string[] { "XXX" }));
            }
        }
    }
}
