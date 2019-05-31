using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class SupplierVM
    {
        public SupplierVM(string name) //---------> Parsing
        {
            this.Name = name;
        }

        public SupplierVM() { }

        public void Update(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
