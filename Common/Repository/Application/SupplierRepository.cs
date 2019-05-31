using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess.Context;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repository.Application {
    public class SupplierRepository : ISupplierRepository {
        private MyContext myContext = new MyContext();
        private bool _status = false;

        public bool Delete(int id) {
            var get = Get(id);
            if (get != null) {
                get.Delete();
                myContext.Entry(get).State = EntityState.Modified;
                myContext.SaveChanges();
                return true;
            }
            else {
                return false;
            }
        }

        public List<Supplier> Get() {
            var get = myContext.Suppliers.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Supplier Get(int id) {
            var get = myContext.Suppliers.SingleOrDefault(x => x.IsDelete == false && x.Id == id);
            return get;
        }

        public bool Insert(SupplierVM supplierVM) {
            var push = new Supplier(supplierVM);
            myContext.Suppliers.Add(push);
            var result = myContext.SaveChanges();
            if (result > 0) {
                _status = true;
            }
            else {
                return _status;
            }

            return _status;
        }

        public List<Supplier> Search(string param) {
            var get = myContext.Suppliers
                .Where(x => x.IsDelete == false && (x.Id.ToString().Contains(param) || x.Name.Contains(param)))
                .ToList();
            return get;
        }

        public bool Update(int id, SupplierVM supplierVM) {
            var pull = Get(id);
            pull.Update(supplierVM);
            myContext.Entry(pull).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0) {
                _status = true;
            }
            else {
                return _status;
            }

            return _status;
        }
    }
}