namespace MarketService.API.Dtos
{
    public record CreateMarketDto(string ItemId, string InventoryId, decimal Price, string PlayerId);
}
