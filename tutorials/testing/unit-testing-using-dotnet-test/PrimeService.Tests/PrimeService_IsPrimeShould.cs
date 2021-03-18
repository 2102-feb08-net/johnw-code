﻿using Xunit;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var _primeService = new PrimeService();
            var result = _primeService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }
    }
}
