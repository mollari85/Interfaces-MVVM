using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InterfaceGood.model
{
    class Test:DependencyObject
    {
        public Test(int x)
        {
            this.x = x;
        }
        private int x;
        public void show()
        {
            MessageBox.Show(x.ToString());
        }
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Test), new PropertyMetadata("Hello"));


    }
}
