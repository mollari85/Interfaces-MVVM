using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceGood.model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Runtime.CompilerServices;

namespace InterfaceGood.VM
{
    class VM_Rocket:DependencyObject
    {
        private Rocket rocket=new Rocket();
        List<IRocketEngine> listRocketEngines = new List<IRocketEngine>();
        List<IRocketHead> listRocketHeads = new List<IRocketHead>();

        public VM_Rocket(Rocket rocket)
        {
            
            this.rocket = rocket;
            CreateListEngine();
            CreateListHeads();

            Engines = CollectionViewSource.GetDefaultView(GetListEngines());
            Heads = CollectionViewSource.GetDefaultView(GetListHeads());
            ImagePath = rocket.RocketEngine.PhotoPath;
            
        }

        public List<IRocketEngine> GetListEngines()
        {
            return (listRocketEngines);
        }
        public List<IRocketHead> GetListHeads()
        {
            return (listRocketHeads);
        }
        private void CreateListEngine()
        {
            listRocketEngines.Add(new PuckanEngine());
            listRocketEngines.Add(new RD100Engine());
        }
        private void CreateListHeads()
        {
            listRocketHeads.Add(new HeadSauz());
            listRocketHeads.Add(new HeadSauz(weight: 300, seats: 4, type: "Sauz2"));
        }





        public IRocketEngine SelectedEngine
        {
            get { return (IRocketEngine)GetValue(SelectedEngineProperty); }
            set { SetValue(SelectedEngineProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SelectedEngine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedEngineProperty =
            DependencyProperty.Register("SelectedEngine", typeof(IRocketEngine), typeof(VM_Rocket), new PropertyMetadata(null, SelectedEngineChanged));
        private static void SelectedEngineChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as VM_Rocket;
            if (current != null)
            {
                // select new engine
                current.rocket.SetNewEngine(current.SelectedEngine);
                current.ImagePath = current.rocket.RocketEngine.PhotoPath; 
                
            }
        }

        public string ImagePath
        {
            get {  return  (string)GetValue(ImagePathProperty); }
            set { OnPropertyChanged(); SetValue(ImagePathProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImagePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(VM_Rocket), new PropertyMetadata(null));

        public ICollectionView Engines
        {
            get { return (ICollectionView)GetValue(EnginesProperty); }
            set { SetValue(EnginesProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Engines.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnginesProperty =
            DependencyProperty.Register("Engines", typeof(ICollectionView), typeof(VM_Rocket), new PropertyMetadata(null));

        public ICollectionView Heads
        {
            get { return (ICollectionView)GetValue(HeadsProperty); }
            set { SetValue(HeadsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Heads.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeadsProperty =
            DependencyProperty.Register("Heads", typeof(ICollectionView), typeof(VM_Rocket), new PropertyMetadata(null));

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
