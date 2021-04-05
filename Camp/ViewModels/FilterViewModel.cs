using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.ViewModels
{
    public class FilterViewModel
    {
        public string SelectedLastName { get; set; }
        public string SelectedPhoneNumber { get; set; }
        public bool SelectedProcessed { get; set; }                                                                                                             

        public FilterViewModel(string lastName, string phoneNumber, bool processed)
        {
            SelectedProcessed = processed;
            SelectedLastName = lastName;
            SelectedPhoneNumber = phoneNumber;
        }
    }
}
