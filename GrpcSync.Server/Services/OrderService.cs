﻿namespace GrpcSync.Server.Services
{
    public class OrderService : GrpcSync.Shared.OrderService.OrdersServiceBase
    {
        private static readonly string[] Countries = new[]
        {
        "Berlin", "Tokyo", "Denmark", "Tokyo", "Olso"
    };
        private static readonly string[] Names = new[]
        {
        "VINET", "RIO", "RAJ", "MAH", "RAM"
    };
        private static readonly string[] Cities = new[]
        {
            "New York", "London", "Hue"
    };
        public override Task<OrdersResponse> GetOrders(Empty request, ServerCallContext context)
        {
            var response = new OrdersResponse();

            response.Orders.AddRange(GetOrders());

            return Task.FromResult<OrdersResponse>(response);
        }
        public IEnumerable<Orders> GetOrders()
        {
            var rng = new Random();
            return Enumerable.Range(1, 365).Select(index => new Orders
            {
                OrderID = index,
                OrderDate = DateTime.Now.AddDays(index),
                ShipCountry = Countries[rng.Next(Countries.Length)],
                CustomerName = Names[rng.Next(Names.Length)],
                ShipCity = Cities[rng.Next(Cities.Length)]
            });
        }
    }
}
