﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Entities;
using DomainModels.Models;
using BAL.Abstraction;
using System.Data.Entity;

namespace BAL.Implementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }

        public OrderRepository(DbContext db)
        {
            this.db = db;
        }

        public int SaveCart(Cart model)
        {
            context.Carts.Add(model);
            context.SaveChanges();
            return model.CartId;
        }

        public void PlaceOrder(TransactionModel model)
        {
            Transaction tran = new Transaction();
            tran.Amount = model.Amount;
            tran.CartId = model.CartId;
            tran.Tran_Id = model.Tran_Id;
            tran.CreatedDate = DateTime.Now;
            tran.PaymentType = model.PaymentType;
            tran.Status = model.Status;
                        
            Cart cart = context.Carts.Where(c => c.CartId == model.CartId).FirstOrDefault();
            Order ord = new Order();

            ord.CartId = cart.CartId;
            ord.CreatedDate = DateTime.Now;
            ord.CustomerName = model.Name;
            ord.ShippingAddress = model.Address;
            ord.Total = cart.Total;
            ord.UserId = cart.UserId;

            foreach (var item in cart.Items)
            {
                OrderItem obj = new OrderItem();
                obj.ProductId = item.ProductId;
                obj.Quantity = item.Quantity;
                obj.Total = item.Total;
                obj.UnitPrice = item.UnitPrice;

                ord.OrderItems.Add(obj);
            }

            tran.UserId = cart.UserId;
            context.Transactions.Add(tran);
            context.Orders.Add(ord);
        }
    }
}