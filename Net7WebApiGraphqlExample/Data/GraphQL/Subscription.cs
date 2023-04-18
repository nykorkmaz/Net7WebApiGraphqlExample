using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using Net7WebApiGraphqlExample.Entities;

namespace Net7WebApiGraphqlExample.Data.GraphQL
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Product>> OnProductGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Product>("ReturnedProduct", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Product>> OnProductAdd([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Product>("AddProduct", cancellationToken);
        }
    }
}
