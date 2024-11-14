using Avalonia.Controls;
using GeometryApp.ViewModels;

namespace GeometryApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainViewModel(); // Устанавливаем DataContext для привязки
        }

        private void OnSwitchShapeClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var viewModel = (ViewModels.MainViewModel)DataContext;
            viewModel.SwitchShape(); // Вызываем метод SwitchShape
        }
    }
}