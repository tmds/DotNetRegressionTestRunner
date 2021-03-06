using System;
using Xunit;

namespace RedHat.DotNet.DotNetRegressionTestRunner.Tests
{
    public class VersionRangeTests
    {
        [Fact]
        public void FailsToParseSingleExactVersion()
        {
            Assert.Throws(typeof(Exception), () => VersionRange.Parse("2.0"));
        }

        [Fact]
        public void ParsesSimpleVersionRangeCorrectly()
        {
            var range = VersionRange.Parse("[1.0,2.0)");
            Assert.Equal(new Version("1.0"), range.MinVersion);
            Assert.Equal(true, range.MinVersionInclusive);
            Assert.Equal(new Version("2.0"), range.MaxVersion);
            Assert.Equal(false, range.MaxVersionInclusive);
        }

        [Fact]
        public void ParsesUnlimitedVersionRangeCorrectly()
        {
            var range = VersionRange.Parse("(,)");
            Assert.Equal(new Version(0, 0), range.MinVersion);
            Assert.Equal(new Version(int.MaxValue, int.MaxValue), range.MaxVersion);
        }
    }
}
