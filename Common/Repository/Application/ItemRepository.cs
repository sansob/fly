﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repository.Application
{
    public class ItemRepository : IItemRepository
    {
        MyContext myContext = new MyContext();
        bool status = false;

        public bool Delete(int id)
        {
            var pull = Get(id);
            pull.Delete();
            myContext.Entry(pull).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Item> Get()
        {
            var get = myContext.Items.Include("Supplier").Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Item Get(int id)
        {
            var get = myContext.Items.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(ItemVM itemVM)
        {
            var push = new Item(itemVM);
            var getSupplier = myContext.Suppliers.Find(itemVM.Supplier_Id);
            push.Supplier = getSupplier;
            myContext.Items.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Item> Search(string param)
        {
            var get = myContext.Items.Include("Supplier").Where(x => x.Id.ToString().Contains(param) || x.Name.Contains(param) || x.Price.ToString().Contains(param) || x.Stock.ToString().Contains(param) || x.Supplier.Name.Contains(param)).ToList() ;
            return get;
        }

        public bool Update(int id, ItemVM itemVM)
        {
            var pull = Get(id);
            var getSupplier = myContext.Suppliers.Find(itemVM.Supplier_Id);
            pull.Supplier = getSupplier;
            pull.Update(itemVM);
            myContext.Entry(pull).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
