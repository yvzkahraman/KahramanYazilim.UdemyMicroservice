namespace InventoryService.API.Dtos
{
    public record InventoryCreateDto(string PlayerId, string Name);
    public record ItemInventoryCreateDto(string InventoryId, string ItemId, int Count);

    public record ItemInventoryUpdateDto(string Id, int Count);
}
