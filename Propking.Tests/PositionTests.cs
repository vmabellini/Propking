using Propking.Domain.Models;
using Shouldly;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Propking.Tests
{
    public class PositionTests
    {
        public class TestDataGenerator : IEnumerable<object[]>
        {
            public readonly List<object[]> _data = new List<object[]>()
            {
                new object[] {
                    new Position()
                    {
                        Changes = new List<PositionChange>() {
                            new PositionChange()
                            {
                                ChangeType = PositionChange.PositionChangeType.Buy,
                                Quantity = 10,
                                UnitValue = 9.99m,
                                FiiId = 1
                            }
                        }
                    },
                    9.99m,
                    10
                }
            };

            IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _data.GetEnumerator();
            }
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void Deve_calcular_posicao(Position position, decimal mediumPrice, int quantity)
        {
            var summary = position.CalculateSummary();

            summary.MediumPrice.ShouldBe(mediumPrice);
            summary.Quantity.ShouldBe(quantity);
        }
    }
}
