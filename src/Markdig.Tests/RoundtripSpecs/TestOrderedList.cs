using NUnit.Framework;
using static Markdig.Tests.TestRoundtrip;

namespace Markdig.Tests.RoundtripSpecs
{
    [TestFixture]
    public class TestOrderedList
    {
        [TestCase("1. i")]
        [TestCase("1.  i")]
        [TestCase("1. i ")]
        [TestCase("1.  i ")]
        [TestCase("1.  i  ")]

        [TestCase(" 1. i")]
        [TestCase(" 1.  i")]
        [TestCase(" 1. i ")]
        [TestCase(" 1.  i ")]
        [TestCase(" 1.  i  ")]

        [TestCase("  1. i")]
        [TestCase("  1.  i")]
        [TestCase("  1. i ")]
        [TestCase("  1.  i ")]
        [TestCase("  1.  i  ")]

        [TestCase("   1. i")]
        [TestCase("   1.  i")]
        [TestCase("   1. i ")]
        [TestCase("   1.  i ")]
        [TestCase("   1.  i  ")]

        [TestCase("1. i\n")]
        [TestCase("1.  i\n")]
        [TestCase("1. i \n")]
        [TestCase("1.  i \n")]
        [TestCase("1.  i  \n")]

        [TestCase(" 1. i\n")]
        [TestCase(" 1.  i\n")]
        [TestCase(" 1. i \n")]
        [TestCase(" 1.  i \n")]
        [TestCase(" 1.  i  \n")]

        [TestCase("  1. i\n")]
        [TestCase("  1.  i\n")]
        [TestCase("  1. i \n")]
        [TestCase("  1.  i \n")]
        [TestCase("  1.  i  \n")]

        [TestCase("   1. i\n")]
        [TestCase("   1.  i\n")]
        [TestCase("   1. i \n")]
        [TestCase("   1.  i \n")]
        [TestCase("   1.  i  \n")]

        [TestCase("1. i\n2. j")]
        [TestCase("1.  i\n2. j")]
        [TestCase("1. i \n2. j")]
        [TestCase("1.  i \n2. j")]
        [TestCase("1.  i  \n2. j")]

        [TestCase(" 1. i\n2. j")]
        [TestCase(" 1.  i\n2. j")]
        [TestCase(" 1. i \n2. j")]
        [TestCase(" 1.  i \n2. j")]
        [TestCase(" 1.  i  \n2. j")]

        [TestCase("  1. i\n2. j")]
        [TestCase("  1.  i\n2. j")]
        [TestCase("  1. i \n2. j")]
        [TestCase("  1.  i \n2. j")]
        [TestCase("  1.  i  \n2. j")]

        [TestCase("   1. i\n2. j")]
        [TestCase("   1.  i\n2. j")]
        [TestCase("   1. i \n2. j")]
        [TestCase("   1.  i \n2. j")]
        [TestCase("   1.  i  \n2. j")]

        [TestCase("1. i\n2. j\n")]
        [TestCase("1.  i\n2. j\n")]
        [TestCase("1. i \n2. j\n")]
        [TestCase("1.  i \n2. j\n")]
        [TestCase("1.  i  \n2. j\n")]

        [TestCase(" 1. i\n2. j\n")]
        [TestCase(" 1.  i\n2. j\n")]
        [TestCase(" 1. i \n2. j\n")]
        [TestCase(" 1.  i \n2. j\n")]
        [TestCase(" 1.  i  \n2. j\n")]

        [TestCase("  1. i\n2. j\n")]
        [TestCase("  1.  i\n2. j\n")]
        [TestCase("  1. i \n2. j\n")]
        [TestCase("  1.  i \n2. j\n")]
        [TestCase("  1.  i  \n2. j\n")]

        [TestCase("   1. i\n2. j\n")]
        [TestCase("   1.  i\n2. j\n")]
        [TestCase("   1. i \n2. j\n")]
        [TestCase("   1.  i \n2. j\n")]
        [TestCase("   1.  i  \n2. j\n")]

        [TestCase("1. i\n2. j\n3. k")]
        [TestCase("1. i\n2. j\n3. k\n")]

        public void Test(string value)
        {
            RoundTrip(value);
        }

        [TestCase("\n1. i")]
        [TestCase("\r1. i")]
        [TestCase("\r\n1. i")]

        [TestCase("\n1. i\n")]
        [TestCase("\r1. i\n")]
        [TestCase("\r\n1. i\n")]

        [TestCase("\n1. i\r")]
        [TestCase("\r1. i\r")]
        [TestCase("\r\n1. i\r")]

        [TestCase("\n1. i\r\n")]
        [TestCase("\r1. i\r\n")]
        [TestCase("\r\n1. i\r\n")]

        [TestCase("1. i\n2. i")]
        [TestCase("\n1. i\n2. i")]
        [TestCase("\r1. i\n2. i")]
        [TestCase("\r\n1. i\n2. i")]

        [TestCase("1. i\r2. i")]
        [TestCase("\n1. i\r2. i")]
        [TestCase("\r1. i\r2. i")]
        [TestCase("\r\n1. i\r2. i")]

        [TestCase("1. i\r\n2. i")]
        [TestCase("\n1. i\r\n2. i")]
        [TestCase("\r1. i\r\n2. i")]
        [TestCase("\r\n1. i\r\n2. i")]

        [TestCase("1. i\n2. i\n")]
        [TestCase("\n1. i\n2. i\n")]
        [TestCase("\r1. i\n2. i\n")]
        [TestCase("\r\n1. i\n2. i\n")]

        [TestCase("1. i\r2. i\r")]
        [TestCase("\n1. i\r2. i\r")]
        [TestCase("\r1. i\r2. i\r")]
        [TestCase("\r\n1. i\r2. i\r")]

        [TestCase("1. i\r\n2. i\r\n")]
        [TestCase("\n1. i\r\n2. i\r\n")]
        [TestCase("\r1. i\r\n2. i\r\n")]
        [TestCase("\r\n1. i\r\n2. i\r\n")]
        public void TestNewline(string value)
        {
            RoundTrip(value);
        }
    }
}
