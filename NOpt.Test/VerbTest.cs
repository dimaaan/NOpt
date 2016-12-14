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
                    public string repo { get; set; }
                }

                [Verb("push")]
                public PushOptions push { get; set; }
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
