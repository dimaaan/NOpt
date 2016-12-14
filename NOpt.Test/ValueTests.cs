using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                public string opt1 { get; set; } // will be "file1"

                [Value(1)]
                public string opt2 { get; set; } // will be "file2"

                [Value(2)]
                public string opt3 { get; set; } // will be null

                [Value(3)]
                public string opt4 { get; set; } = "default value"; // will be "default"
            }

            [Fact]
            public void check()
            {
                Options4 opt = NOpt.Parse<Options4>(new string[] { "file1", "file2" });
                Assert.Equal("file1", opt.opt1);
                Assert.Equal("file2", opt.opt2);
                Assert.Equal(null, opt.opt3);
                Assert.Equal("default value", opt.opt4);
            }

            [Fact]
            public void checkEmpty()
            {
                Options4 opt = NOpt.Parse<Options4>(new string[] { null });
                Assert.Equal(null, opt.opt1);
                Assert.Equal(null, opt.opt2);
                Assert.Equal(null, opt.opt3);
                Assert.Equal("default value", opt.opt4);
            }

            [Fact]
            public void checkNull()
            {
                Assert.Throws<ArgumentNullException>(() => NOpt.Parse<Options4>(null));
            }
        }
    }
}
