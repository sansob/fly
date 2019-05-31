using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public interface IItemService
    {
        List<Item> Get();
        Item Get(int id);
        bool Insert(ItemVM itemVM);
        bool Update(int id, ItemVM itemVM);
        bool Delete(int id);
        List<Item> Search(string param);
    }
}
