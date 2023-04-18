using HotChocolate.Subscriptions;
using Net7WebApiGraphqlExample.Entities;

namespace Net7WebApiGraphqlExample.Data.GraphQL
{
    public class Mutation
    {
        public async Task<Product> CreateProduct([Service] ProductRepository productRepository,
            [Service] ITopicEventSender eventSender, Product product)
        {
            var newProduct = await productRepository.CreateProduct(product);
            await eventSender.SendAsync("AddProduct", newProduct);
            return newProduct;
        }

        public async Task<Product> UpdateProduct([Service] ProductRepository productRepository, Product product)
        {
            var updateProduct = await productRepository.UpdateProduct(product);
            return updateProduct;
        }
    }
}
