using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input; // Добавляем пространство имен для ICommand

namespace GeometryApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private double _rectangleWidth;
        private double _rectangleHeight;
        private double _circleWidth; // Ширина эллипса
        private double _circleHeight; // Высота эллипса
        private double _rectangleRotation;
        private bool _isRectangleVisible;
        private bool _isCircleVisible;
        private Color _rectangleColor = Colors.Blue;
        private Color _circleColor = Colors.Red;

        public ObservableCollection<Shape> Shapes { get; } = new ObservableCollection<Shape>();

        // Добавляем свойства для управления эллипсом
        public double CircleWidth
        {
            get => _circleWidth;
            set
            {
                if (_circleWidth != value)
                {
                    _circleWidth = value;
                    OnPropertyChanged();
                    UpdateShapes();
                }
            }
        }

        public double CircleHeight
        {
            get => _circleHeight;
            set
            {
                if (_circleHeight != value)
                {
                    _circleHeight = value;
                    OnPropertyChanged();
                    UpdateShapes();
                }
            }
        }

        public double RectangleWidth
        {
            get => _rectangleWidth;
            set
            {
                if (_rectangleWidth != value)
                {
                    _rectangleWidth = value;
                    OnPropertyChanged();
                    UpdateShapes();
                }
            }
        }

        public double RectangleHeight
        {
            get => _rectangleHeight;
            set
            {
                if (_rectangleHeight != value)
                {
                    _rectangleHeight = value;
                    OnPropertyChanged();
                    UpdateShapes();
                }
            }
        }

        public double RectangleRotation
        {
            get => _rectangleRotation;
            set
            {
                if (_rectangleRotation != value)
                {
                    _rectangleRotation = value;
                    OnPropertyChanged();
                    UpdateShapes();
                }
            }
        }

        public bool IsRectangleVisible
        {
            get => _isRectangleVisible;
            set
            {
                if (_isRectangleVisible != value)
                {
                    _isRectangleVisible = value;
                    OnPropertyChanged();
                    UpdateShapes();
                }
            }
        }

        public bool IsCircleVisible
        {
            get => _isCircleVisible;
            set
            {
                if (_isCircleVisible != value)
                {
                    _isCircleVisible = value;
                    OnPropertyChanged();
                    UpdateShapes();
                }
            }
        }

        public Color RectangleColor
        {
            get => _rectangleColor;
            set
            {
                if (_rectangleColor != value)
                {
                    _rectangleColor = value;
                    OnPropertyChanged();
                    UpdateShapes();
                }
            }
        }

        public Color CircleColor
        {
            get => _circleColor;
            set
            {
                if (_circleColor != value)
                {
                    _circleColor = value;
                    OnPropertyChanged();
                    UpdateShapes();
                }
            }
        }

        // Конструктор, в котором создаём команду
        public MainViewModel()
        {
            SwitchShapeCommand = new RelayCommand(SwitchShape);
        }

        public ICommand SwitchShapeCommand { get; }

        public void SwitchShape()
        {
            if (IsRectangleVisible)
            {
                IsRectangleVisible = false;
                IsCircleVisible = true;
            }
            else
            {
                IsRectangleVisible = true;
                IsCircleVisible = false;
            }

            UpdateShapes();
        }

        private void UpdateShapes()
        {
            Shapes.Clear();

            if (IsRectangleVisible)
            {
                var rectangle = new Rectangle
                {
                    Width = RectangleWidth,
                    Height = RectangleHeight,
                    Fill = new SolidColorBrush(RectangleColor),
                    RenderTransform = new RotateTransform(RectangleRotation)
                };
                Shapes.Add(rectangle);
            }

            if (IsCircleVisible)
            {
                var ellipse = new Ellipse
                {
                    Width = CircleWidth, // Используем CircleWidth для ширины
                    Height = CircleHeight, // Используем CircleHeight для высоты
                    Fill = new SolidColorBrush(CircleColor)
                };
                Shapes.Add(ellipse);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;

        public RelayCommand(Action execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
