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
                public enum Access
                {
                    READ = 1, WRITE = 2, READ_WRITE = 4
                }

                [Value(0)]
                public Access Acs { get; set; }
            }

            [Fact]
            public void Check()
            {
                Options opt;
                
                opt = NOpt.Parse<Options>(new string[] { "WRITE" });
                Assert.Equal(Options.Access.WRITE, opt.Acs);

                opt = NOpt.Parse<Options>(new string[] { "WrItE" });
                Assert.Equal(Options.Access.WRITE, opt.Acs);

                opt = NOpt.Parse<Options>(new string[] { "read_write" });
                Assert.Equal(Options.Access.READ_WRITE, opt.Acs);

                opt = NOpt.Parse<Options>(new string[] { "READ_WRITE" });
                Assert.Equal(Options.Access.READ_WRITE, opt.Acs);

                opt = NOpt.Parse<Options>(new string[] { "READ-WRITE" });
                Assert.Equal(Options.Access.READ_WRITE, opt.Acs);

                opt = NOpt.Parse<Options>(new string[] { "read-WRITE" });
                Assert.Equal(Options.Access.READ_WRITE, opt.Acs);

                opt = NOpt.Parse<Options>(new string[] { "read-write" });
                Assert.Equal(Options.Access.READ_WRITE, opt.Acs);

                opt = NOpt.Parse<Options>(new string[] { "read,write" });
                Assert.Equal(Options.Access.READ | Options.Access.WRITE, opt.Acs);

                opt = NOpt.Parse<Options>(new string[] { "read,write,read-write" });
                Assert.Equal(Options.Access.READ | Options.Access.WRITE | Options.Access.READ_WRITE, opt.Acs);

                Assert.Throws<FormatException>(() => NOpt.Parse<Options>(new string[] { "XXX" }));
            }
        }
    }
}
