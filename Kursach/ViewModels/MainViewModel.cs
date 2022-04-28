using Kursach.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Kursach.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
    
        public MainViewModel()
        {
            Timer.Tick += Timer_Tick;
            Timer.Interval = new(0, 1, 0);
        }

        public static MainViewModel Instance { get; } = new();

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Time.Add(TimeSpan.FromMinutes(-1));

            if (Time == TimeSpan.Zero)
                Timer.Stop();            
        }

        public DispatcherTimer Timer { get; } = new();
        private TimeSpan _time;
        public TimeSpan Time
        {
            get => _time;
            set
            {
                _time = value;
                Signal();
            }
        }
        public Command ExitCommand { get; } = new(o => Application.Current.Shutdown());
        public Command HideCommand { get; } = new(o => Application.Current.MainWindow.WindowState = WindowState.Minimized);

        public Command TelegaCommand { get; } = new(o =>
        {
            Process.Start(new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = "http://t.me/Night_bred"
            });
        });
    }
}

/*
 * t.me/Night_bred
 */