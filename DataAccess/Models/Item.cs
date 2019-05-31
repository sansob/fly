using Core.Base;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    [Table("TB_M_Item")]
    public class Item : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public Supplier Supplier { get; set; }

        public Item(ItemVM itemVM)
        {
            this.Id = itemVM.Id;
            this.Name = itemVM.Name;
            this.Price = itemVM.Price;
            this.Stock = itemVM.Stock;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public Item() { }

        public virtual void Update(ItemVM itemVM)
        {
            this.Id = itemVM.Id;
            this.Name = itemVM.Name;
            this.Price = itemVM.Price;
            this.Stock = itemVM.Stock;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
