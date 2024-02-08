using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_CMS.Models;
using WPF_CMS.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WPF_CMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection _sqlConnection;
        private MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            _viewModel.LoadCustomers();

            DataContext = _viewModel;
            //string conenctionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
            //_sqlConnection = new SqlConnection(conenctionString);
            //ShowCustomers();
        }

        private void ClearSelectedCustomer_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ClearSelectedCustomer();
        }

        private void SaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text.Trim();
                string idNumber = IdNumberTextBox.Text.Trim();
                string address = AddressTextBox.Text.Trim();
                _viewModel.SaveCustomer(name, idNumber, address);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.AddAppointment();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }



        //private void ShowCustomers()
        //{
        //    //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Customers", _sqlConnection);
        //    //using (sqlDataAdapter)
        //    //{
        //    //    try
        //    //    {
        //    //        DataTable customerTable = new DataTable();
        //    //        sqlDataAdapter.Fill(customerTable);

        //    //        customerList.DisplayMemberPath = "Name";
        //    //        customerList.SelectedValuePath = "Id";
        //    //        customerList.ItemsSource = customerTable.DefaultView;
        //    //    }
        //    //    catch (Exception e)
        //    //    {
        //    //        MessageBox.Show(e.ToString());
        //    //    }

        //    //}

        //    try
        //    {
        //        using (var db = new AppDbContext())
        //        {
        //            var customers = db.Customers.ToList();
        //            customerList.DisplayMemberPath = "Name";
        //            customerList.SelectedValuePath = "Id";
        //            customerList.ItemsSource = customers;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //    }
        //}

        //private void customerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        //string query = "select * from Appointmennts join Customers on Appointmennts.CustomerId = Customers.Id where CustomerId =@CustomerId;";
        //        //var customerId = customerList.SelectedValue;
        //        //if (customerId == null)
        //        //{
        //        //    appointmentList.ItemsSource = null;
        //        //    return;
        //        //}
        //        //DataRowView selectedItem = customerList.SelectedItem as DataRowView;
        //        //NameTextBox.Text = selectedItem["Name"] as string;
        //        //IdTextBox.Text = selectedItem["IdNumber"] as string;
        //        //AddressTextBox.Text = selectedItem["Address"] as string;

        //        //SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection);
        //        //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        //sqlCommand.Parameters.AddWithValue("@CustomerId", customerId);

        //        //using (sqlDataAdapter)
        //        //{
        //        //    DataTable customerTable = new DataTable();
        //        //    sqlDataAdapter.Fill(customerTable);

        //        //    appointmentList.DisplayMemberPath = "Time";
        //        //    appointmentList.SelectedValuePath = "Id";
        //        //    appointmentList.ItemsSource = customerTable.DefaultView;
        //        //}

        //        Customer? selectedItem = customerList.SelectedItem as Customer;
        //        if (selectedItem == null)
        //        {
        //            appointmentList.ItemsSource = null;
        //            return;
        //        }
        //        NameTextBox.Text = selectedItem.Name;
        //        IdTextBox.Text = selectedItem.IdNumber;
        //        AddressTextBox.Text = selectedItem.Address;
        //        using (var db = new AppDbContext())
        //        {
        //            var customerId = customerList.SelectedValue;
        //            if (customerId == null)
        //            {
        //                appointmentList.ItemsSource = null;
        //                return;
        //            }
        //            var appointment = db.Appointmennts.Where(a => a.CustomerId == (int)customerId).ToList();
        //            appointmentList.DisplayMemberPath = "Time";
        //            appointmentList.SelectedValuePath = "Id";
        //            appointmentList.ItemsSource = appointment;
        //        }

        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.ToString());
        //    }
        //}

        //private void DeleteAppointment_Click(object sender, RoutedEventArgs e)
        //{
        //    //try
        //    //{
        //    //    //var sql = "delete from Appointmennts where Id=@AppointmentId";
        //    //    //var appointmentId = appointmentList.SelectedValue;
        //    //    //SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
        //    //    //sqlCommand.Parameters.AddWithValue("@AppointmentId", appointmentId);
        //    //    //_sqlConnection.Open();
        //    //    //sqlCommand.ExecuteScalar();
        //    //}
        //    //catch (Exception error)
        //    //{
        //    //    MessageBox.Show(error.ToString());
        //    //}
        //    //finally
        //    //{
        //    //    _sqlConnection.Close();
        //    //    customerList_SelectionChanged(null, null);

        //    //}
        //    try
        //    {
        //        var appointmentId = appointmentList.SelectedValue;
        //        using (var db = new AppDbContext())
        //        {
        //            var appointmentToRemove = db.Appointmennts.Where(a => a.Id == (int)appointmentId).FirstOrDefault();
        //            db.Appointmennts.Remove(appointmentToRemove);
        //            db.SaveChanges();

        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.ToString());
        //    }
        //    finally
        //    {
        //        customerList_SelectionChanged(null, null);
        //    }

        //}

        //private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        //{
        //    //try
        //    //{
        //    //    var sqlDeleteAppointment = "delete from Appointmennts where CustomerId=@CustomerId";
        //    //    var sqlDeleteCustomer = "delete from Customers where Id=@CustomerId";
        //    //    var customerId = customerList.SelectedValue;
        //    //    SqlCommand sqlCommand1 = new SqlCommand(sqlDeleteAppointment, _sqlConnection);
        //    //    SqlCommand sqlCommand2 = new SqlCommand(sqlDeleteCustomer, _sqlConnection);
        //    //    sqlCommand1.Parameters.AddWithValue("@CustomerId", customerId);
        //    //    sqlCommand2.Parameters.AddWithValue("@CustomerId", customerId);
        //    //    _sqlConnection.Open();
        //    //    sqlCommand1.ExecuteScalar();
        //    //    sqlCommand2.ExecuteScalar();

        //    //}
        //    //catch (Exception error)
        //    //{
        //    //    MessageBox.Show(error.ToString());
        //    //}
        //    //finally
        //    //{
        //    //    _sqlConnection.Close();
        //    //    ShowCustomers();
        //    //    customerList_SelectionChanged(null, null);
        //    //}

        //    try
        //    {
        //        var customerId = customerList.SelectedValue;
        //        using(var db = new AppDbContext())
        //        {
        //            var CustomerToRemove = db.Customers.Include(c => c.Appointmennts).Where(a => a.Id == (int)customerId).FirstOrDefault();
        //            db.Customers.Remove(CustomerToRemove);
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.ToString());
        //    }
        //    finally
        //    {
        //        ShowCustomers();
        //        customerList_SelectionChanged(null, null);
        //    }
        //}

        //private void AddCustomer_Click(object sender, RoutedEventArgs e)
        //{
        //    //try
        //    //{
        //    //    var sql = "insert into Customers values (@name, @idnumber, @address)";
        //    //    var sqlCommand = new SqlCommand(sql, _sqlConnection);
        //    //    sqlCommand.Parameters.AddWithValue("@name", NameTextBox.Text);
        //    //    sqlCommand.Parameters.AddWithValue("@idnumber", IdTextBox.Text);
        //    //    sqlCommand.Parameters.AddWithValue("@address", AddressTextBox.Text);
        //    //    _sqlConnection.Open();
        //    //    sqlCommand.ExecuteScalar();

        //    //}
        //    //catch (Exception error)
        //    //{
        //    //    MessageBox.Show(error.ToString());
        //    //}
        //    //finally
        //    //{
        //    //    _sqlConnection.Close();
        //    //    ShowCustomers();
        //    //    customerList_SelectionChanged(null, null);
        //    //}

        //    try
        //    {
        //        using(var db = new AppDbContext())
        //        {
        //            var customer = new Customer()
        //            {
        //                Name = NameTextBox.Text,
        //                IdNumber = IdTextBox.Text,
        //                Address = AddressTextBox.Text
        //            };
        //            db.Customers.Add(customer);
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.ToString());
        //    }
        //    finally
        //    {
        //        ShowCustomers();
        //        customerList_SelectionChanged(null, null);
        //    }
        //}

        //private void AddAppointment_Click(object sender, RoutedEventArgs e)
        //{
        //    //try
        //    //{
        //    //    var sql = "insert into Appointmennts values (@time, @customerid)";
        //    //    var sqlCommand = new SqlCommand(sql, _sqlConnection);
        //    //    var time = datePicker.Text;
        //    //    var customerId = customerList.SelectedValue;
        //    //    sqlCommand.Parameters.AddWithValue("@time", time);
        //    //    sqlCommand.Parameters.AddWithValue("@customerid", customerId);
        //    //    _sqlConnection.Open();
        //    //    sqlCommand.ExecuteScalar();
        //    //}
        //    //catch (Exception error)
        //    //{
        //    //    MessageBox.Show(error.ToString());
        //    //}
        //    //finally
        //    //{
        //    //    _sqlConnection.Close();
        //    //    customerList_SelectionChanged(null, null);
        //    //}

        //    try
        //    {
        //        using(var db=new AppDbContext())
        //        {
        //            var appointment = new Appointmennt()
        //            {
        //                Time = DateTime.Parse(datePicker.Text),
        //                CustomerId = (int)customerList.SelectedValue
        //            };
        //            db.Appointmennts.Add(appointment);
        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.ToString());
        //    }
        //    finally
        //    {
        //        customerList_SelectionChanged(null, null);
        //    }
        //}

        //private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        //{
        //    //try
        //    //{
        //    //    var sql = "update Customers set Name=@name, IdNumber=@idNumber, Address=@address where Id=@customerId";
        //    //    var sqlCommand = new SqlCommand(sql, _sqlConnection);
        //    //    sqlCommand.Parameters.AddWithValue("@name", NameTextBox.Text.Trim());
        //    //    sqlCommand.Parameters.AddWithValue("@idNumber", IdTextBox.Text.Trim());
        //    //    sqlCommand.Parameters.AddWithValue("@address", AddressTextBox.Text.Trim());
        //    //    sqlCommand.Parameters.AddWithValue("@customerId", customerList.SelectedValue);

        //    //    _sqlConnection.Open();
        //    //    sqlCommand.ExecuteScalar();
        //    //}
        //    //catch (Exception error)
        //    //{
        //    //    MessageBox.Show(error.ToString());
        //    //}
        //    //finally
        //    //{
        //    //    _sqlConnection.Close();
        //    //    ShowCustomers();
        //    //}

        //    try 
        //    { 
        //        using(var db = new AppDbContext())
        //        {
        //            var customer = db.Customers.Where(c => c.Id == (int)customerList.SelectedValue).FirstOrDefault();
        //            customer.Name = NameTextBox.Text.Trim();
        //            customer.IdNumber = IdTextBox.Text.Trim();
        //            customer.Address = AddressTextBox.Text.Trim();

        //            db.SaveChanges();
        //        }
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.ToString());
        //    }
        //    finally
        //    {
        //        ShowCustomers();
        //    }
        //}
    }

}