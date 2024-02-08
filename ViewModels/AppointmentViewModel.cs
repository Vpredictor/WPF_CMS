using WPF_CMS.Models;

namespace WPF_CMS.ViewModels
{
    public class AppointmentViewModel
    {
        private Appointmennt _appointment;

        public AppointmentViewModel(Appointmennt appointment) 
        {
            _appointment = appointment;
        }
        public int Id { get => _appointment.Id; }

        public DateTime Time { get => _appointment.Time;
            set
            {
                if(value != _appointment.Time)
                {
                    _appointment.Time = value;
                }
            }
        }
    }
}