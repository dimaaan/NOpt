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
                public string opt1; // will be "file1"

                [Value(1)]
                public string opt2; // will be "file2"

                [Value(2)]
                public string opt3; // will be null

                [Value(3, DefaultValue = "default")]
                public string opt4; // will be "default"
            }

            public Options4 opt;

            public FourOptions()
            {
                opt = NOpt.Parse<Options4>(new string[] { "file1", "file2" });
            }
            

            [Fact]
            public void opt1()
            {
                Assert.Equal("file1", opt.opt1);
            }

            [Fact]
            public void opt2()
            {
                Assert.Equal("file2", opt.opt2);
            }

            [Fact]
            public void opt3()
            {
                Assert.Equal(null, opt.opt3);
            }

            [Fact]
            public void opt4()
            {
                Assert.Equal("default", opt.opt4);
            }
        }
    }
}
