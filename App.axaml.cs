using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using GeometryApp.ViewModels; // Убедитесь, что это пространство имен указано

namespace GeometryApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Создаем экземпляр MainWindow и устанавливаем его DataContext
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainViewModel() // Убедитесь, что здесь используется правильный класс
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}