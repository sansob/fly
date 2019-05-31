using DataAccess.Models;
using DataAccess.ViewModels;
using System.Collections.Generic;

namespace BusinessLogic.Service {
    public interface ISupplierService {
        List<Supplier> Get();
        Supplier Get(int id);
        bool Insert(SupplierVM supplierVM);
        bool Update(int id, SupplierVM supplierVM);
        bool Delete(int id);
        List<Supplier> Search(string param);
    }
}