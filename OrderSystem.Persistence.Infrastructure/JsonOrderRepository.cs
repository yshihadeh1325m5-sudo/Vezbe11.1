

using OrderSystem.Orders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace OrderSystem.Persistence.Infrastructure
{
    public class JsonOrderRepository : IOrderRepository
    {
        private readonly string _filePath = "orders.json";
        public JsonOrderRepository(string filePath)
        {
            _filePath = filePath;
        }

        public JsonOrderRepository()
            : this("orders.json")
        {
        }

        public List<Order> GetAll()
        {
            if (!File.Exists(_filePath))
                return new List<Order>();

            var json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Order>();

            return JsonSerializer.Deserialize<List<Order>>(json)
                ?? new List<Order>();
        }

        public Order? GetById(Guid id)
        {
            return GetAll().FirstOrDefault(o => o.Id == id);
        }

        public void Add(Order order)
        {
            var orders = GetAll();
            orders.Add(order);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string json = JsonSerializer.Serialize(orders, options);
            File.WriteAllText(_filePath, json);
        }

        /// <summary>
        /// Deprecated. Do not use.
        /// </summary>
        /// <param name="order"></param>
        public void Save(Order order)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(order, options);

              
                File.WriteAllText(_filePath, jsonString);

                Console.WriteLine($"Order uspjesno sacuvan u {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Greska pri cuvanju narudzbe: {ex.Message}");
            }
        }
        

        
    }
}
