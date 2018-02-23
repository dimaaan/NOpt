using Xunit;
using NOpt.Test.Git.Options;

namespace NOpt.Test
{
    public class GitTest
    {
        [Fact]
        public void Add()
        {
            var opt = NOpt.Parse<Options>(new string[] { "add", "-nvf" });

            Assert.True(opt.add.dryRun);
            Assert.True(opt.add.verbose);
            Assert.True(opt.add.force);
        }
    }
}
