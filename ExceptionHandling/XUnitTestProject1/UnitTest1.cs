using ExceptionHandling;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void FourthLevelClassCanThrowDemoExcepiton2()
        {
            var c = new FirstLevelClass();

            var ex = Assert.Throws<InvalidCalculation>(() => c.LvlOneDo(3));

            //stop and inspect the exception
            Assert.True(false);
        }
    }
}