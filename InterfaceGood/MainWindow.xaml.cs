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
using InterfaceGood.model;
using InterfaceGood.VM;

namespace InterfaceGood
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rocket MyRocket;
        VM_Rocket Vm_Rocket;
        public MainWindow()
        {
            InitializeComponent();
            MyRocket = new Rocket();
            Vm_Rocket = new VM_Rocket(MyRocket);
            this.Loaded += MainWindow_Loaded;           
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                 Test test = new Test(4);
                 

                 tbInfoTest.DataContext = test;


                //MyRocket.RocketEngine = new PuckanEngine();
                tbInfo.DataContext = MyRocket;
                tbTextbox.DataContext = MyRocket;
                ImName.DataContext = Vm_Rocket;
                MyRocket.TestEngineSystem();
                lvHeads.DataContext = Vm_Rocket;
                lv_View.DataContext = Vm_Rocket;
            }
            catch (Exception d) { MessageBox.Show(d.Message); }
        }

        private void BtnSHow_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("ddd" + MyRocket.Message);
            // MyRocket.TestEngineSystem();
            Rocket.worker.RunWorkerAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyRocket.TestStart();

        }
    }
}
