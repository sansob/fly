using BusinessLogic.Service;
using BusinessLogic.Service.Application;
using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TryPhase3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ISupplierService iSupplierService = new SupplierService();
        IItemService iItemService = new ItemService();

        SupplierVM supplierVM = new SupplierVM();
        ItemVM itemVM = new ItemVM();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGrid();
            LoadCombo();
        }

        #region Load Section

        private void LoadGrid()
        {
            SupplierGrid.ItemsSource = iSupplierService.Get();
            ItemGrid.ItemsSource = iItemService.Get();
        }

        private void LoadCombo()
        {
            cmb_Supplier.ItemsSource = iSupplierService.Get();
        }

        #endregion Load Section

        #region Button Action Supplier

        private void Btn_SaveOrEdit_Click(object sender, RoutedEventArgs e)
        {
            var result = false;
            if (string.IsNullOrWhiteSpace(txt_Id.Text))
            {
                supplierVM.Name = txt_Name.Text;
                var push = new Supplier(supplierVM);
                result = iSupplierService.Insert(supplierVM);
            }
            else
            {
                supplierVM.Id = Convert.ToInt32(txt_Id.Text);
                supplierVM.Name = txt_Name.Text;
                var push = new Supplier(supplierVM);
                result = iSupplierService.Update(supplierVM.Id, supplierVM);
            }
            if (result)
            {
                MessageBox.Show("Save Successfully");
            }
            else
            {
                MessageBox.Show("Save Fail");
            }
            LoadGrid();
            LoadCombo();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Id.Text))
            {
                var dialogResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo).ToString();
                if (dialogResult == "Yes")
                {
                    var result = iSupplierService.Delete(Convert.ToInt32(txt_Id.Text));
                    if (result)
                    {
                        MessageBox.Show("Delete Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Delete Fail");
                    }
                }
            }
            LoadGrid();
            LoadCombo();
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            SupplierGrid.ItemsSource = iSupplierService.Search(txt_Search.Text);
        }

        #endregion Button Action Supplier

        #region Button Action Item

        private void Btn_SaveOrEditItem_Click(object sender, RoutedEventArgs e)
        {
            var result = false;
            if (string.IsNullOrWhiteSpace(txt_IdItem.Text))
            {
                var itemParam = new ItemVM(txt_NameItem.Text, Convert.ToInt32(txt_PriceItem.Text), Convert.ToInt32(txt_StockItem.Text), Convert.ToInt32(cmb_Supplier.SelectedValue));
                result = iItemService.Insert(itemParam);
            }
            else
            {
                itemVM.Update(Convert.ToInt32(txt_IdItem.Text),txt_NameItem.Text, Convert.ToInt32(txt_PriceItem.Text), Convert.ToInt32(txt_StockItem.Text), Convert.ToInt32(cmb_Supplier.SelectedValue));
                result = iItemService.Update(itemVM.Id, itemVM);
            }
            if (result)
            {
                MessageBox.Show("Save Successfully");
            }
            else
            {
                MessageBox.Show("Save Fail");
            }
            LoadGrid();
            LoadCombo();
        }

        private void Btn_DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_IdItem.Text))
            {
                var dialogResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo).ToString();
                if (dialogResult == "Yes")
                {
                    var result = iItemService.Delete(Convert.ToInt32(txt_IdItem.Text));
                    if (result)
                    {
                        MessageBox.Show("Delete Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Delete Fail");
                    }
                }
            }
            LoadGrid();
            LoadCombo();
        }

        private void Btn_SearchItem_Click(object sender, RoutedEventArgs e)
        {
            ItemGrid.ItemsSource = iItemService.Search(txt_SearchItem.Text);
        }

        #endregion Button Action Item

        #region Grid

        private void SupplierGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                object item = SupplierGrid.SelectedItem;
                txt_Id.Text = (SupplierGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_Name.Text = (SupplierGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch
            {
                txt_Id.Text = "";
                txt_Name.Text = "";
            }
        }

        private void ItemGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                object item = ItemGrid.SelectedItem;
                txt_IdItem.Text = (ItemGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                txt_NameItem.Text = (ItemGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                txt_PriceItem.Text = (ItemGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                txt_StockItem.Text = (ItemGrid.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                cmb_Supplier.Text = (ItemGrid.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch
            {
                txt_Id.Text = "";
                txt_Name.Text = "";
                txt_PriceItem.Text = "";
                txt_StockItem.Text = "";
                cmb_Supplier.SelectedValue = 0;
            }
        }

        #endregion Grid

        private void ItemGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_reset_supplier_Click(object sender, RoutedEventArgs e)
        {
            txt_Id.Text = "";
            txt_Name.Text = "";
        }

        private void btn_riset_item_Click(object sender, RoutedEventArgs e)
        {
            txt_IdItem.Text = "";
            txt_NameItem.Text = "";
            txt_PriceItem.Text = "";
            txt_StockItem.Text = "";
            cmb_Supplier.SelectedValue = 0;
        }
    }
}
