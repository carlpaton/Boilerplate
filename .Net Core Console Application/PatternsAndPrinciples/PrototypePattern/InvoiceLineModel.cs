using System;

namespace PrototypePattern
{
    [Serializable]
    public class InvoiceLineModel
    {
        public int InvoiceLineId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }

        public InvoiceLineModel()
        {
            Description = string.Empty;
        }
    }
}