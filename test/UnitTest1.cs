using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using Mathematics;

namespace test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var expected = new List<long>(){1,2,3,6,383,766,1149,2298};
            Assert.Equal(expected, Arithmetic.Divisor(2298));
        }

        [Theory,
            InlineData(false, 0),
            InlineData(false, 1),
            InlineData(false, 18),
            InlineData(true, 97),
            InlineData(true, 1000000007)
        ]
        public void Test2(bool expected, long n)
        {
            Assert.Equal(expected,Arithmetic.IsPrimeNumber(n));
        }

        [Fact]
        public void Test3()
        {
            var eratosthenes = Arithmetic.SieveOfEratosthenes(100);
            var actual = Enumerable.Range(0,101).Select(i => eratosthenes[i] ? i : -1).Where(v => v != -1).ToList();
            var expected = new List<int>(){2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97};
            Assert.Equal(expected, actual);
        }

        [Theory,
            InlineData(6, 12, 18),
            InlineData(10000000, 50000000, 30000000)
        ]
        public void Test4(long expected, long a, long b)
        {
            Assert.Equal(expected, Arithmetic.GCD(a, b));
        }

        [Theory,
            InlineData(6, 2, 3),
            InlineData(150000000, 50000000, 30000000)
        ]
        public void Test5(long expected, long a, long b)
        {
            Assert.Equal(expected, Arithmetic.LCM(a, b));
        }

        [Theory,
            InlineData(32, 2, 5, 1000000007),
            InlineData(390625, 5, 8, 1000000007)
        ]
        public void Test6(long expected, long x, long n, long mod)
        {
            Assert.Equal(expected, Arithmetic.PowMod(x, n, mod));
        }

        [Fact]
        public void Test7()
        {
            Assert.Equal(1, Arithmetic.Factorial(1));
            Assert.Equal(120, Arithmetic.Factorial(5));
            Assert.Equal(3628800, Arithmetic.Factorial(10));
        }

        [Fact]
        public void Test8()
        {
            Assert.Equal(55, Arithmetic.SumOfProgression(1, 10, 10));
            Assert.Equal(5050, Arithmetic.SumOfProgression(1, 100, 100));
        }
    }
}
