using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private DatabaseContext _context;
    private IItemService _itemService;
    private IInventoryService _inventoryService;

    public OrderService(DatabaseContext DbContext, IItemService itemService, IInventoryService inventoryService)
    {
        _context = DbContext;
        _itemService = itemService;
        _inventoryService = inventoryService;
    }

    public async Task<Order> ReadOrder(int order_id)
    {
        var order = await _context.Orders.FindAsync(order_id);
        return order!;
    }

    public async Task<List<Order>> ReadOrders()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<List<Item>> ReadItemsInOrder(int order_id)
    {
        Order order = await ReadOrder(order_id);
        var tasks = order.Items.Select(item => _itemService.ReadItem(item.Item_Id));
        var items = await Task.WhenAll(tasks);
        return items.ToList(); 
    }

    public async Task<bool> CreateOrder(Order order)
    {
<<<<<<< HEAD
=======
        if (_context.Orders.Any(x => x.Id == order.Id))
        {
            return false;
        }
>>>>>>> Jimmy
        order.Created_At = DateTime.UtcNow;
        order.Updated_At = DateTime.UtcNow;
        _context.Orders.Add(order);
        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateOrder(Order order, int order_id)
    {
        var existingOrder = await _context.Orders.FindAsync(order_id);
        if (existingOrder == null)
        {
            return false;
        }

        existingOrder.Source_Id = order.Source_Id;
        existingOrder.Order_Date = order.Order_Date;
        existingOrder.Request_Date = order.Request_Date;
        existingOrder.Reference = order.Reference;
        existingOrder.Reference_Extra = order.Reference_Extra;
        existingOrder.Order_Status = order.Order_Status;
        existingOrder.Notes = order.Notes;
        existingOrder.Shipping_Notes = order.Shipping_Notes;
        existingOrder.Picking_Notes = order.Picking_Notes;
        existingOrder.Warehouse_Id = order.Warehouse_Id;
        existingOrder.Ship_To = order.Ship_To;
        existingOrder.Bill_To = order.Bill_To;
        existingOrder.Shipment_Id = order.Shipment_Id;
        existingOrder.Total_Amount = order.Total_Amount;
        existingOrder.Total_Discount = order.Total_Discount;
        existingOrder.Total_Tax = order.Total_Tax;
        existingOrder.Total_Surcharge = order.Total_Surcharge;
        existingOrder.Updated_At = DateTime.UtcNow;
        existingOrder.Items = order.Items;

        int n = await _context.SaveChangesAsync();
        return n > 0;
    }

    public async Task<bool> UpdateItemsInOrder(int order_id, List<PropertyItem> updated_items)
    {
        Order order = await ReadOrder(order_id);

        if (order == null)
        {
            return false;
        }

        foreach (PropertyItem currentItem in order.Items)
        {
            var found = updated_items.FirstOrDefault(item => item.Item_Id == currentItem.Item_Id);
            if (found == null)
            {
                List<Inventory> inventories = await _itemService.ReadInventoriesForItem(currentItem.Item_Id);
                Inventory minInventory = inventories.OrderByDescending(inventory => inventory.Total_Allocated).FirstOrDefault()!;
                if (minInventory != null)
                {
                    minInventory.Total_Allocated -= currentItem.Amount;
                    minInventory.Total_Expected = minInventory.Total_On_Hand + minInventory.Total_Ordered;
                    await _inventoryService.UpdateInventory(minInventory, minInventory.Id);
                }
            }
        }

        foreach (PropertyItem updatedItem in updated_items)
        {
            var currentItem = order.Items.FirstOrDefault(item => item.Item_Id == updatedItem.Item_Id);
            if (currentItem != null)
            {
                List<Inventory> inventories = await _itemService.ReadInventoriesForItem(updatedItem.Item_Id);
                var minInventory = inventories.OrderBy(inventory => inventory.Total_Allocated).FirstOrDefault();
                if (minInventory != null)
                {
                    minInventory.Total_Allocated += updatedItem.Amount - currentItem.Amount;
                    minInventory.Total_Expected = minInventory.Total_On_Hand + minInventory.Total_Ordered;
                    await _inventoryService.UpdateInventory(minInventory, minInventory.Id);
                }
            }
            else
            {
                List<Inventory> inventories = await _itemService.ReadInventoriesForItem(updatedItem.Item_Id);
                var minInventory = inventories.OrderBy(inventory => inventory.Total_Allocated).FirstOrDefault();
                if (minInventory != null)
                {
                    minInventory.Total_Allocated += updatedItem.Amount;
                    minInventory.Total_Expected = minInventory.Total_On_Hand + minInventory.Total_Ordered;
                    await _inventoryService.UpdateInventory(minInventory, minInventory.Id);
                }
            }
        }

        return true;
    }

    public async Task<bool> DeleteOrder(int order_id)
    {
        var order = await _context.Orders.FindAsync(order_id);
        if (order == null)
        {
            return false;
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface IOrderService
{
    public Task<Order> ReadOrder(int order_id);
    public Task<List<Order>> ReadOrders();
    public Task<List<Item>> ReadItemsInOrder(int order_id);
    public Task<bool> CreateOrder(Order order);
    public Task<bool> UpdateOrder(Order order, int order_id);
    public Task<bool> UpdateItemsInOrder(int order_id, List<PropertyItem> updated_items);
    public Task<bool> DeleteOrder(int order_id);
}
