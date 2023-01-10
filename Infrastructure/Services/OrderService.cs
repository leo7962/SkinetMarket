using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Core.Models.OrderAggregate;

namespace Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IBasketRepository _basketRepo;
    private readonly IGenericRepository<DeliveryMethod> _dmRepo;
    private readonly IGenericRepository<Order> _orderRepo;
    private readonly IGenericRepository<Product> _productRepo;

    public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<DeliveryMethod> dmRepo,
        IGenericRepository<Product> productRepo, IBasketRepository basketRepo)
    {
        _orderRepo = orderRepo;
        _dmRepo = dmRepo;
        _productRepo = productRepo;
        _basketRepo = basketRepo;
    }

    public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId,
        Address shippingAddress)
    {
        //Get Basket From the repo
        var basket = await _basketRepo.GetBasketAsync(basketId);

        //Get items from the product repo
        var items = new List<OrderItem>();
        foreach (var item in basket.Items)
        {
            var productItem = await _productRepo.GetByIdAsync(item.Id);
            var itemOrderded = new ProductItemOrder(productItem.Id, productItem.Name, productItem.PictureUrl);
            var orderItem = new OrderItem(itemOrderded, productItem.Price, item.Quantity);
            items.Add(orderItem);
        }

        //Get delivery method from repo
        var deliveryMethod = await _dmRepo.GetByIdAsync(deliveryMethodId);

        //Calculate subtotal
        var subtotal = items.Sum(item => item.Price * item.Quantity);

        //Create Order
        var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal);


        //Return Order
        return order;
    }

    public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
    {
        return null;
    }

    public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
    {
        return null;
    }

    public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
    {
        return null;
    }
}