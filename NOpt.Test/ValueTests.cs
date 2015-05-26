﻿using System;
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
                public readonly string opt1; // will be "file1"

                [Value(1)]
                public readonly string opt2; // will be "file2"

                [Value(2)]
                public readonly string opt3; // will be null

                [Value(3)]
                public readonly string opt4 = "default value"; // will be "default"
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
