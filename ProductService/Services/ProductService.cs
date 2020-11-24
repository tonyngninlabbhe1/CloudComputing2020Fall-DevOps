using System;
using System.Collections.Generic;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRespository;

    public ProductService(IProductRepository productRepository)
    {
        _productRespository = productRepository;
    }

    public List<ProductViewModel> GetAllProducts()
    {
        var productViewModels = new List<ProductViewModel>();

        foreach(var product in _productRespository.GetAllProducts())
        {
            productViewModels.Add(new ProductViewModel {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                OnSale = BusinessRules.isOnSale(product),
                LowInventory = BusinessRules.isLowInventory(product)
            });
            if (BusinessRules.isLowInventory(product))
            {
                Console.WriteLine("Found low inventory product: " + product.ProductId);
            }
        }

        return productViewModels;
    }

    public Product GetProductById(long productId)
    {
        return _productRespository.GetProductById(productId);
    }

    public void AddProduct(Product product)
    {
        _productRespository.AddProduct(product);
    }

    public void UpdateProduct(Product product)
    {
        _productRespository.UpdateProduct(product);
    }

    public void DeleteProduct(long productId)
    {
        _productRespository.DeleteProduct(productId);
    }
}