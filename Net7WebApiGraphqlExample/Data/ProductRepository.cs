using Net7WebApiGraphqlExample.Entities;

namespace Net7WebApiGraphqlExample.Data
{
    public class ProductRepository
    {
        private readonly StoreDbContext _storeDbContext;
        public ProductRepository(StoreDbContext dbContext)
        {
            _storeDbContext = dbContext;
        }

        public List<Product> GetAllProducts()
        {
            return _storeDbContext.Products.ToList();
        }

        public Product GetProductbyId(int id)
        {
            return _storeDbContext.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.ProductUpdateDate = DateTime.Now;
            await _storeDbContext.Products.AddAsync(product);
            await _storeDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var updateProduct = _storeDbContext.Products.Find(product.ProductId);
            if (updateProduct != null)
            {
                updateProduct.ProductName = product.ProductName ?? updateProduct.ProductName;
                updateProduct.ProductDescription = product.ProductDescription ?? updateProduct.ProductDescription;
                updateProduct.ProductSku = product.ProductSku ?? updateProduct.ProductSku;
                updateProduct.ProductPrice = product.ProductPrice ?? updateProduct.ProductPrice;
                updateProduct.ProductUpdateDate = DateTime.Now;
                updateProduct.ProductStatus = product.ProductStatus ?? updateProduct.ProductStatus;
                _storeDbContext.Products.Update(updateProduct);
                await _storeDbContext.SaveChangesAsync();
            }

            return updateProduct;
        }


    }
}
