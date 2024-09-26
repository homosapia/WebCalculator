using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Models;
using Xunit;

namespace UnitTest.Tests
{
    public class IndexModelTest
    {
        [Fact]
        public void ValidationMethodCheck()
        {
            // Arrange
            IndexModel model = new IndexModel()
            {
                Expression = "-5+3-9*2"
            };
            // Assert
            Assert.True(model.IsValid());
        }
    }
}
