using System;
using System.Collections.Generic;
using System.Text;

namespace Propking.Api.Models
{
    public partial class Position : IEntity
    {
        public Position()
        {
            Changes = new List<PositionChange>();
        }

        public int Id { get; set; }
        public int FiiId { get; set; }
        public virtual Fii Fii { get; set; }
        public virtual ICollection<PositionChange> Changes { get; set; }

        public Summary CalculateSummary()
        {
            var summary = new Summary();

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

            if (summary.Quantity < 0)
            {
                throw new InvalidOperationException("Position summary error: negative quantity");
            }

            summary.MediumPrice = Math.Round(buyTotal / summary.Quantity, 2, MidpointRounding.AwayFromZero);

            return summary;
        }

        public class Summary
        {
            public int Quantity { get; set; }
            public decimal MediumPrice { get; set; }
        }
    }
}
