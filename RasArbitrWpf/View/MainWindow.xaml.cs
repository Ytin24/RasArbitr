using RasArbitrWPF.ViewModel;
using System.Windows;

namespace RasArbitrWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
            var vm = this.DataContext as MainWindowVM;
            vm.Close += () => this.Close();
            vm.Cases = Cases;
            vm.Sides = Sides;
        }

        private void Title_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) 
        {
            this.DragMove();
        }
    }
}
