using System;
using System.Collections.Generic;

class Product
{
    public string id;
    public string name;
}

class ProductsImpl
{
    private List<Product> products;

    public ProductsImpl()
    {
        products = new List<Product>();
    }

    public bool addProduct(Product product)
    {
        // Проверяем, есть ли уже продукт с таким id
        bool exists = products.Exists(p => p.id == product.id);
        
        if (exists)
        {
            // Продукт с таким id уже существует
            return false;
        }

        // Добавляем продукт в список
        products.Add(product);
        return true;
    }

    public bool deleteProduct(Product product)
    {
        // Ищем продукт по id
        Product foundProduct = products.Find(p => p.id == product.id);
        
        if (foundProduct != null)
        {
            // Удаляем продукт
            products.Remove(foundProduct);
            return true;
        }

        // Продукт с таким id не найден
        return false;
    }

    public string getName(string id)
    {
        // Ищем продукт по id
        Product foundProduct = products.Find(p => p.id == id);

        if (foundProduct != null)
        {
            // Возвращаем имя продукта
            return foundProduct.name;
        }

        // Продукт с таким id не найден
        return "";
    }

    public List<string> findByName(string name)
    {
        List<string> result = new List<string>();

        // Ищем продукты с заданным именем
        foreach (Product product in products)
        {
            if (product.name == name)
            {
                // Добавляем id продукта в результат
                result.Add(product.id);
            }
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ProductsImpl products = new ProductsImpl();

        Product product1 = new Product();
        product1.id = "1";
        product1.name = "Apple";
        products.addProduct(product1);

        Product product2 = new Product();
        product2.id = "2";
        product2.name = "Banana";
        products.addProduct(product2);

        Product product3 = new Product();
        product3.id = "3";
        product3.name = "Apple";
        products.addProduct(product3);

        Console.WriteLine(products.getName("2")); // Output: Banana

        List<string> ids = products.findByName("Apple");
        foreach (string id in ids)
        {
            Console.WriteLine(id);
        }
        // Output:
        // 1
        // 3
    }
}
