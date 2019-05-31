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
    [Table("TB_M_Supplier")]
    public class Supplier : BaseModel
    {
        public string Name { get; set; }

        public Supplier() { }

        public Supplier(SupplierVM supplierVM)
        {
            this.Name = supplierVM.Name;
            this.CreateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Update(SupplierVM supplierVM)
        {
            this.Id = supplierVM.Id;
            this.Name = supplierVM.Name;
            this.UpdateDate = DateTimeOffset.Now.LocalDateTime;
        }

        public virtual void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now.LocalDateTime;
        }
    }
}
