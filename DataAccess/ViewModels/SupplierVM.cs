using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class SupplierVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SupplierVM(string name)
        {
            this.Name = name;
        }

        public SupplierVM() { }

        public virtual void Update(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
