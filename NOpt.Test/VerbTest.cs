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
                    public string Repo { get; set; }
                }

                [Verb("push")]
                public PushOptions Push { get; set; }
            }

            Options opt;

            public GitPushTest()
            {
                opt = NOpt.Parse<Options>(new string[] { "push", "-r", "master" });
            }

            [Fact]
            public void Check()
            {
                Assert.NotNull(opt.Push);
                Assert.Equal("master", opt.Push.Repo);
            }
        }
    }
}
