namespace DataAccess.ViewModels {
    public class ItemVM {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int Supplier_Id { get; set; }

        public ItemVM(string name, int price, int stock, int supplier_id) {
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Supplier_Id = supplier_id;
        }

        public ItemVM() {
        }

        public virtual void Update(int id, string name, int price, int stock, int supplier_id) {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Supplier_Id = supplier_id;
        }
    }
}