using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBoxProblem.Viewmodel
{
    public class UserControlViewmodel:INotifyPropertyChanged
    {
        private string text;
        public string Text { 
            get { return text; } 
            set { text = value; 
                PropertyChanged(this, new PropertyChangedEventArgs("Text")); } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
