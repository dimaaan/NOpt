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
                public bool opt1; // will be "file1"

                [Option('b')]
                public bool opt2; // will be "file2"

                [Option('c')]
                public bool opt3; // will be null
            }

            Options opt;

            public ThreeShortOption()
            {
                opt = NOpt.Parse<Options>(new string[] { "-abc" });
            }

            [Fact]
            public void check()
            {
                Assert.True(opt.opt1 && opt.opt2 && opt.opt3);
            }
        }


        public class LongOption
        {
            public class Options
            {
                [Option('f', LongName = "file")]
                public string opt;

                [Option("action")]
                public bool opt2;
            }

            Options opt;

            public LongOption()
            {
                opt = NOpt.Parse<Options>(new string[] { "--file", "readme.txt", "--action" });
            }

            [Fact]
            public void check()
            {
                Assert.Equal("readme.txt", opt.opt);
                Assert.True(opt.opt2);
            }
        }
    }
}
