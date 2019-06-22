using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Demo04_06.DataFlow
{
    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    #region INotifyPropertyChangedの実装
    //public class Person : INotifyPropertyChanged
    //{
    //    private string _name;
    //    public string Name
    //    {
    //        get
    //        {
    //            return _name;
    //        }
    //        set
    //        {
    //            _name = value;
    //            OnPropertyChanged("Name");
    //        }

    //    }

    //    private string _address;
    //    public string Address
    //    {
    //        get
    //        {
    //            return _address;
    //        }

    //        set
    //        {
    //            _address = value;
    //            OnPropertyChanged("Address");
    //        }
    //    }

        
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    protected void OnPropertyChanged(string propertyName)
    //    {
    //        if(PropertyChanged != null)
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //}
    #endregion

}
