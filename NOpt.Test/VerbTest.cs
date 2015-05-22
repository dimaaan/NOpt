using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NOpt.Test
{
    public class VerbTest
    {
        public class GitPushTest
        {
            public class Options
            {
                public class PushOptions
                {
                    [Option('r', "repo")]
                    public string repo;
                }

                [Verb("push")]
                public PushOptions push;
            }

            Options opt;

            public GitPushTest()
            {
                opt = NOpt.Parse<Options>(new string[] { "push", "-r", "master" });
            }

            [Fact]
            public void Check()
            {
                Assert.NotNull(opt.push);
                Assert.Equal("master", opt.push.repo);
            }
        }
    }
}
