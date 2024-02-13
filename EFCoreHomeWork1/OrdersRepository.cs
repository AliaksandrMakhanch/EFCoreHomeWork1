using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class OrdersRepository
{
    private readonly AppDbContext _context;

    public OrdersRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreateOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public Order ReadOrder(int id)
    {
        return _context.Orders.Include(o => o.Product).SingleOrDefault(o => o.ID == id);
    }

    public void UpdateOrder(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteOrder(int id)
    {
        var order = _context.Orders.Find(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Order> FetchAllOrders()
    {
        return _context.Orders.Include(o => o.Product).ToList();
    }

    public void BulkDeleteOrders(IEnumerable<int> orderIds)
    {
        var orders = _context.Orders.Where(o => orderIds.Contains(o.ID));
        _context.Orders.RemoveRange(orders);
        _context.SaveChanges();
    }
}