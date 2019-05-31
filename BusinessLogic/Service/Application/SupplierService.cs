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
    public class SupplierService : ISupplierService
    {
        ISupplierRepository iSupplierRepository = new SupplierRepository();
        bool status = false;

        public bool Delete(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return status;
            }
            else
            {
                return iSupplierRepository.Delete(id);
            }
        }

        public List<Supplier> Get()
        {
            return iSupplierRepository.Get();
        }

        public Supplier Get(int id)
        {
            return iSupplierRepository.Get(id);
        }

        public bool Insert(SupplierVM supplierVM)
        {
            if (string.IsNullOrWhiteSpace(supplierVM.Name))
            {
                return status;
            }
            else
            {
                return iSupplierRepository.Insert(supplierVM);
            }
        }

        public List<Supplier> Search(string param)
        {
            return iSupplierRepository.Search(param);
        }

        public bool Update(int id, SupplierVM supplierVM)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return status;
            }
            else if (string.IsNullOrWhiteSpace(supplierVM.Name))
            {
                return status;
            }
            else
            {
                return iSupplierRepository.Update(id, supplierVM);
            }
        }
    }
}
