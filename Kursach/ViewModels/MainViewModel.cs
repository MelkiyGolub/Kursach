using Kursach.Objects;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace Kursach.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {

        }

        public Command ExitCommand { get; } = new(o => Application.Current.Shutdown());
        public Command HideCommand { get; } = new(o => Application.Current.MainWindow.WindowState = WindowState.Minimized);

        public Command ShowSkladCommand { get; } = new(o => new sklad().ShowDialog());

        public Command ShowPacketsCommand { get; } = new(o => new Packets().ShowDialog());

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