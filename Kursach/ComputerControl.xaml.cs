using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Kursach;
public partial class ComputerControl : UserControl, INotifyPropertyChanged
{
    public ComputerControl()
    {
        InitializeComponent();
        DataContext = this;

        Timer.Interval = new(0, 0, 1);
        Timer.Tick += Timer_Tick;
        TimeTextBlock.Text = TimeSpan.Zero.ToString();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        Time = Time.Add(TimeSpan.FromSeconds(-1));

        TimeTextBlock.Text = Time.ToString();

        if (Time == TimeSpan.Zero)
        {
            Timer.Stop();
            Status = "Свободен";
            statusCanvas.Background = Brushes.Green;
        }
    }

    public DispatcherTimer Timer { get; } = new();
    public TimeSpan Time { get; set; }

    private int _number;
    public int Number
    {
        get => _number;
        set
        {
            _number = value;
            Signal();
        }
    }

    private string _status;
    public string Status
    {
        get => _status;
        set
        {
            _status = value;
            Signal();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void Signal([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    private void PayButton_Click(object sender, RoutedEventArgs e)
    {
        new Grabej(this).Show();
    }
}