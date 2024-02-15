namespace Desktop.DTOs.Dtos;

public class TransactionDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string MadeIn { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public int AvailableCount { get; set; }
    public int ReceiptId { get; set; }
}
