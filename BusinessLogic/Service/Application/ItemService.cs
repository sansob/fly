using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repository;
using Common.Repository.Application;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Service.Application
{
    public class ItemService : IItemService
    {
        IItemRepository iItemRepository = new ItemRepository();
        bool status = false;

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return status;
            }
            else
            {
                return iItemRepository.Delete(id);
            }
        }

        public List<Item> Get()
        {
            var get = iItemRepository.Get();
            return get;
        }

        public Item Get(int id)
        {
            var get = iItemRepository.Get(id);
            return get;
        }

        public bool Insert(ItemVM itemVM)
        {
            if (string.IsNullOrWhiteSpace(itemVM.Name))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(itemVM.Price.ToString()))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(itemVM.Stock.ToString()))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(itemVM.Supplier_Id.ToString()))
            {
                return status;
            }
            else
            {
                return iItemRepository.Insert(itemVM);
            }
        }

        public List<Item> Search(string param)
        {
            var get = iItemRepository.Search(param);
            return get;
        }

        public bool Update(int id, ItemVM itemVM)
        {
            if (string.IsNullOrWhiteSpace(itemVM.Id.ToString()))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(itemVM.Name))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(itemVM.Price.ToString()))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(itemVM.Stock.ToString()))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(itemVM.Supplier_Id.ToString()))
            {
                return status;
            }
            else
            {
                return iItemRepository.Update(id, itemVM);
            }
        }
    }
}
