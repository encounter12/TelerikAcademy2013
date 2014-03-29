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
using System.Windows.Threading;
using Animations.AnimationInterfaces;

namespace Animations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IAnimationEngine engine;

        public MainWindow()
        {
            InitializeComponent();
            engine = new AnimationEngine(this.BallsCanvas, (int)this.BallsCanvas.Width, (int)this.BallsCanvas.Height);
            //engine.Start();
        }

        public void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            this.engine.Start();
            this.ButtonStart.IsEnabled = false;
            this.ButtonStop.IsEnabled = true;
        }

        public void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            this.engine.Stop();
            this.ButtonStop.IsEnabled = false;
            this.ButtonStart.IsEnabled = true;
        }
    }
}