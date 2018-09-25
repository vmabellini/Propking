using System;
using System.Collections.Generic;
using System.Text;

namespace Propking.Domain.Models
{
    public class Position
    {
        public Position()
        {
            Changes = new List<PositionChange>();
        }

        public int Id { get; set; }
        public int FiiId { get; set; }
        public virtual Fii Fii { get; set; }
        public virtual ICollection<PositionChange> Changes { get; set; }

        public PositionSummary CalculateSummary()
        {
            var summary = new PositionSummary();

            var buyTotal = 0m;
            foreach (var change in Changes)
            {
                if (change.ChangeType == PositionChange.PositionChangeType.Buy)
                {
                    summary.Quantity += change.Quantity;
                    buyTotal += (change.UnitValue * change.Quantity);
                }
                else if (change.ChangeType == PositionChange.PositionChangeType.Sell)
                {
                    summary.Quantity -= change.Quantity;
                    buyTotal -= (change.UnitValue * change.Quantity);
                }
            }

            summary.MediumPrice = Math.Round(buyTotal / summary.Quantity, 2, MidpointRounding.AwayFromZero);

            return summary;
        }
    }
}
