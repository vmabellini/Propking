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
            public TestDataGenerator()
            {
                //Start theories

                AddTheory(
                    position: new Position()
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
                    quantity: 10,
                    mediumPrice: 9.99m
                    );

                AddTheory(
                    position: new Position()
                    {
                        Changes = new List<PositionChange>() {
                                    new PositionChange()
                                    {
                                        ChangeType = PositionChange.PositionChangeType.Buy,
                                        Quantity = 10,
                                        UnitValue = 9.99m,
                                        FiiId = 1
                                    },
                                    new PositionChange()
                                    {
                                        ChangeType = PositionChange.PositionChangeType.Buy,
                                        Quantity = 27,
                                        UnitValue = 8.46m,
                                        FiiId = 1
                                    }
                                }
                    },
                    quantity: 37,
                    mediumPrice: 8.87m
                    );
                AddTheory(
                    position: new Position()
                    {
                        Changes = new List<PositionChange>() {
                                    new PositionChange()
                                    {
                                        ChangeType = PositionChange.PositionChangeType.Buy,
                                        Quantity = 10,
                                        UnitValue = 9.99m,
                                        FiiId = 1
                                    },
                                    new PositionChange()
                                    {
                                        ChangeType = PositionChange.PositionChangeType.Buy,
                                        Quantity = 27,
                                        UnitValue = 8.46m,
                                        FiiId = 1
                                    },
                                    new PositionChange()
                                    {
                                        ChangeType = PositionChange.PositionChangeType.Sell,
                                        Quantity = 15,
                                        UnitValue = 9.4m,
                                        FiiId = 1
                                    }
                                }
                    },
                    quantity: 22,
                    mediumPrice: 8.51m
                    );
            }

            #region UtilityCode

            public void AddTheory(Position position, decimal mediumPrice, int quantity)
            {
                _data.Add(new object[] { position, mediumPrice, quantity });
            }

            public List<object[]> _data = new List<object[]>();

            IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            #endregion
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
