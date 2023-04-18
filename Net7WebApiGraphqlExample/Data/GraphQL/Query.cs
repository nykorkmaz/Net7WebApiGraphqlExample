﻿using HotChocolate.Subscriptions;
using Net7WebApiGraphqlExample.Entities;

namespace Net7WebApiGraphqlExample.Data.GraphQL
{
    public class Query
    {
        public List<Product> GetAllProducts([Service] ProductRepository productRepository)
        {
            return productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductbyId([Service] ProductRepository productRepository,
            [Service] ITopicEventSender eventSender, int id)
        {
            Product product = productRepository.GetProductbyId(id);
            await eventSender.SendAsync("ReturnedProduct", product);
            return product;
        }
        public List<OrderDetail> GetAllOrderDetails([Service] OrderDetailRepository orderDeatilRepository)
        {
            return orderDeatilRepository.GetAllOrderDetails();
        }

        public List<Order> GetAllOrderwithDetails([Service] OrderRepository orderRepository)
        {
            return orderRepository.GetAllOrderwithDetails();
        }
    }
}
