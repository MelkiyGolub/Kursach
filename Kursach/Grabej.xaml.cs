using Kursach.Objects;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Kursach;

public partial class Grabej : Window, INotifyPropertyChanged
{
    public Grabej(ComputerControl control)
    {
        InitializeComponent();
        DataContext = this;

        PayCommand = new(o =>
        {
            control.Time = TimeSpan.FromHours(SelectedTarif.Time);
            control.Timer.Start();
            control.Status = "Занят";
            control.statusCanvas.Background = Brushes.Red;
            Hide();
        });
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Hide();
    }

    private double _hours;
    public double Hours
    {
        get => _hours;
        set
        {
            _hours = value;
            Signal();

            if (SelectedTarif is not null)
                Price = SelectedTarif.Price;
        }
    }

    private double _price;
    public double Price
    {
        get => _price;
        set
        {
            _price = value;
            Signal();
        }
    }

    private Tarif _selectedTarif;
    public Tarif SelectedTarif
    {
        get => _selectedTarif;
        set
        {
            _selectedTarif = value;
            Hours = value.Time;
            Signal();

        }
    }

    public Tarif[] Tarify { get; set; } = new Tarif[]
    {
        new()
        {
           Title = "Обычный",
           Price = 60,
           Time = 1
        },
        new()
        {
            Title = "3 Часа",
            Price = 150,
            Time = 3
        },
         new()
         {
            Title = "Дотерский",
           Price = 250,
           Time = 5
         },

        new()
        {
         Title = "10 Часов",
         Price = 550,
         Time = 10
        },

        new()
        {
         Title = "Киберспортсмен",
         Price = 650,
         Time = 12
        },

        new()
        {
            Title = "Сутки напролёт",
           Price = 1200,
           Time = 24
        }
    };

    public Command PayCommand { get; init; }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void Signal([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

public class Tarif
{
    public string Title { get; set; }
    public double Price { get; set; }
    public int Time { get; set; }
}