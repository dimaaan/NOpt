using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                public enum Actions
                {
                    READ, WRITE
                }

                [Value(0)]
                public Actions actions;
            }

            Options opt;

            public ValueEnumTest()
            {
                opt = NOpt.Parse<Options>(new string[] { "WRITE" });
            }

            [Fact]
            public void check()
            {
                Assert.Equal(Options.Actions.WRITE, opt.actions);
            }
        }
    }
}
