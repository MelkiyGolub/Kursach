using System.Windows;

namespace Kursach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Grabej().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
