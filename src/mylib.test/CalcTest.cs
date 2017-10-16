using System.ComponentModel;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace mylib.test
{
    public class CalcTest
    {
        [Fact]
        [Category("Functional Test")]
        public void Add_2_plus_2_expected_result_4()
        {
            ICalc calc = new Calc();

            Assert.True(calc.AddAsync(2, 2).Result == 4);
        }

        [Fact]
        [Category("Behavior Test(MOCK)")]
        public void Add_2_minus_2_expected_result_0()
        {
            Mock<ICalc> calcMock = new Mock<ICalc>();
            calcMock.Setup(x => x.AddAsync(2, -2)).Returns(Task.FromResult(0));

            Assert.True(calcMock.Object.AddAsync(2, -2).Result == 0);
        }
    }
}
