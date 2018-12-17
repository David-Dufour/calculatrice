using System;
using Xunit;

namespace Tests.Domain
{
    public class CalculatorTests
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
    }
}

// Racine carrée d'un nombre mettre au carrée.
