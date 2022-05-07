using Kursach.Objects;
using System;

namespace Kursach.ViewModels;

internal class GrabejViewModel : ViewModelBase
{
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

    protected double _price;
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
            if (value.Title == "Обычный")
                Hours = 1;
            if (value.Title == "3 Часа")
                Hours = 3;
            if (value.Title == "Дотерский")
                Hours = 5; 
            if (value.Title == "10 Часов")
                Hours = 10;
            if (value.Title == "Киберспортсмен")
                Hours = 12;
            if (value.Title == "Сутки напролёт")
                Hours = 24;

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
}

public class Tarif
{
    public string Title { get; set; }
    public double Price { get; set; }
    public int Time { get; set; }
}