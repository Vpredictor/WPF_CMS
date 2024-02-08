using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_CMS.Models;

namespace WPF_CMS.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        //public List<Customer> Customers { get; set; } = new();
        public ObservableCollection<CustomerViewModel> Customers { get; set; } = new();
        public ObservableCollection<DateTime> Appointments { get; set; } = new();

        private CustomerViewModel? _selectedCustomer;

        private DateTime? _selectedDate;
        public DateTime? SelectedDate { 
            get
            {
                if (_selectedDate != null) return _selectedDate;
                else return null;
            }
            set
            {
                if(value != _selectedDate)
                {
                    _selectedDate = value;
                    RaisePropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CustomerViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (value != _selectedCustomer)
                {
                    _selectedCustomer = value;
                    RaisePropertyChanged(nameof(SelectedCustomer));
                    LoadAppointments(_selectedCustomer.Id);
                }
            }
        }

        public void LoadCustomers()
        {
            Customers.Clear();
            using (var db = new AppDbContext())
            {
                var customers = db.Customers.ToList();
                foreach (var c in customers)
                {
                    Customers.Add(new CustomerViewModel(c));
                }
            }
        }

        public void LoadAppointments(int customerId)
        {
            Appointments.Clear();
            using(var db = new AppDbContext())
            {
                var appointments = db.Appointmennts.Where(a => a.CustomerId == customerId).ToList();
                foreach(var a in appointments)
                {
                    Appointments.Add(a.Time);
                }
            }
        }

        public void ClearSelectedCustomer()
        {
            _selectedCustomer = null;
            RaisePropertyChanged(nameof(SelectedCustomer));
        }

        public void SaveCustomer(string name, string idNumber, string address)
        {
            try
            {
                if (SelectedCustomer != null)
                {
                    //更新客户数据
                    using (var db = new AppDbContext())
                    {
                        var customer = db.Customers.Where(c => c.Id == SelectedCustomer.Id).FirstOrDefault();
                        customer.Name = name;
                        customer.IdNumber = idNumber;
                        customer.Address = address;
                        db.SaveChanges();
                    }
                }
                else
                {
                    //新增客户数据
                    using (var db = new AppDbContext())
                    {
                        var customer = new Customer()
                        {
                            Name = name,
                            IdNumber = idNumber,
                            Address = address
                        };
                        db.Customers.Add(customer);
                        db.SaveChanges();
                    }
                    LoadCustomers();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            
        }

        public void AddAppointment()
        {
            try
            {
                if(SelectedCustomer == null)
                {
                    return;
                }
                using(var db = new AppDbContext())
                {
                    var appointment = new Appointmennt()
                    {
                        Time = (DateTime)SelectedDate,
                        CustomerId = SelectedCustomer.Id
                    };
                    db.Appointmennts.Add(appointment);
                    db.SaveChanges();
                }
                SelectedDate = null;
                LoadAppointments(SelectedCustomer.Id);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
