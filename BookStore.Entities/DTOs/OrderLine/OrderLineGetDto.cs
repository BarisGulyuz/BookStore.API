﻿using BookStore.Core.Entities.Abstract;
using BookStore.Entities.DTOs.Order;
using System;

namespace BookStore.Entities.DTOs.OrderLine
{
    public class OrderLineGetDto : IDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderGetDto Order { get; set; }
        public bool Status { get; set; }
    }
}
