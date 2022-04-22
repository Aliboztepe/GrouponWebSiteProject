﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groupon.Models.Entity
{
    public class Cart
    {
        //sepetin tamamı:
        private List<CartLine> _cardLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get
            {
                return _cardLines;
            }
        }
        public void AddProduct(Product product, int quantity)
        {
            var line = _cardLines.FirstOrDefault(i => i.Product.ProductID == product.ProductID);
            if (line == null)
            {
                //eklenmek istenen eleman card line içerisinde yoksa : 
                _cardLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product)
        {
            _cardLines.RemoveAll(i => i.Product.ProductID == product.ProductID);
        }
        public double Total()
        {
            return _cardLines.Sum(i => i.Product.Price * i.Quantity);
        }
        public void Clear()
        {
            _cardLines.Clear();
        }

    }
    public class CartLine
    {
        //sepetin bir satırını: 
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}