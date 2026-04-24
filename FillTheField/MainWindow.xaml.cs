using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FillTheField
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private byte levelCount = 1;
        private GameManeger manager;
        public MainWindow()
        {
            InitializeComponent();
            MyWindow.Loaded += MyWindow_Loaded;
            manager = new GameManeger(this);
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GameObject.SetObjectSize(MyGrid.ColumnDefinitions[0].ActualWidth, MyGrid.RowDefinitions[0].ActualHeight);
            LevelCounter.Text = levelCount.ToString();
            manager.LoadLevels();
            manager.ConstructLevel();
        }

        public void Defeat()
        {
            EndText.Text = "Поражение";
            EndText.Visibility = Visibility.Visible;
        }
        public void Win()
        {
            RestartButton.IsEnabled = false;
            EndText.Text = "Победа";
            EndText.Visibility = Visibility.Visible;
            ActionButton.Content = "Next";
            ActionButton.Visibility = Visibility.Visible;
            ActionButton.IsEnabled = true;
        }
        private void MyWindow_KeyDown(object sender, KeyEventArgs e)
        {
            manager.Move(e.Key);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionButton.Visibility = Visibility.Hidden;
            ActionButton.IsEnabled = false;
            RestartButton.IsEnabled = true;
            EndText.Visibility= Visibility.Hidden;
            levelCount++;
            LevelCounter.Text = levelCount.ToString();
            manager.ConstructLevel();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            EndText.Visibility = Visibility.Hidden;
            manager.RestartLevel();
        }
    }
}