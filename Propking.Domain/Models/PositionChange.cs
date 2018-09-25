namespace Propking.Domain.Models
{
    public class PositionChange : IEntity
    {
        public int Id { get; set; }
        public int FiiId { get; set; }
        public Fii Fii { get; set; }
        public PositionChangeType ChangeType { get; set; }
        public decimal UnitValue { get; set; }
        public int Quantity { get; set; }

        public enum PositionChangeType
        {
            Buy,
            Sell
        }
    }
}
