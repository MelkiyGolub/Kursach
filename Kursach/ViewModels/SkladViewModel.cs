using Kursach.Objects;
using Kursach.Objects.Models;
using System.Collections.Generic;

namespace Kursach.ViewModels;

public class SkladViewModel : ViewModelBase
{
    public SkladViewModel()
    {
        OrderDetailCommand = new(o =>
        {
            Details[SelectedDetail!.Type!].Amount += Amount;

        }, b => Amount > 0 && SelectedDetail is not null);

        ShowOrdersCommand = new(o => {
            var window = new OrderDetailWindow();
            window.DataContext = this;
            window.ShowDialog();
        });
    }
    public Dictionary<string, Detail> Details { get; set; } = new()
    {
        ["Мышка"] = new()
        {
            Type = "Мышка",
            Model = HYPER_X,
            Amount = 1,
            Price = 2000
        },
        ["Клавиатура"] = new()
        {
            Type = "Клавиатура",
            Model = HYPER_X,
            Amount = 1,
             Price = 3000
        },
        ["Монитор"] = new()
        {
            Type = "Монитор",
            Model = HYPER_X,
            Amount = 1,
            Price = 20000
        },
        ["Системный блок"] = new()
        {
            Type = "Системный блок",
            Model = "AliExpress PC",
            Amount = 1,
            Price = 1500
        },
        ["Видеокарта"] = new()
        {
            Type = "Видеокарта",
            Model = "RTX 2080ti",
            Amount = 1,
            Price = 56546
        },
        ["Мат. Плата"] = new()
        {
            Type = "Мат. Плата",
            Model = "Asus",
            Amount = 1,
            Price = 20000
        },
        ["Процессор"] = new()
        {
            Type = "Процессор",
            Model = "Intel core i7",
            Amount = 1,
            Price = 25000
        },
        ["Оперативная память"] = new()
        {
            Type = "Оперативная память",
            Model = HYPER_X,
            Amount = 1,
            Price = 8000
        },
        ["Блок питания"] = new()
        {
            Type = "Блок питания",
            Model = "Palit",
            Amount = 1,
            Price = 15000
        },
        ["SSD"] = new()
        {
            Type = "SSD",
            Model = "Kindgston",
            Amount = 1,
            Price = 17000
        },
        ["Кулер"] = new()
        {
            Type = "Кулер",
            Model = "AliExpress PC",
            Amount = 1,
            Price = 500
        },
        ["Наушники"] = new()
        {
            Type = "Наушники",
            Model = HYPER_X,
            Amount = 1,
            Price = 3000
        }
    };

    private const string HYPER_X = "HyperX";
    public Command ShowOrdersCommand { get; } 
    public Command OrderDetailCommand { get; }

    public int _amount = 1;
    public int Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            TotalPrice = SelectedDetail!.Price * value;
        }
    }
    private Detail? _seletedDetail;
    public Detail? SelectedDetail
    {
        get => _seletedDetail;
        set
        {
            _seletedDetail = value;
            TotalPrice = value!.Price * Amount;
        }
    }
    public decimal TotalPrice { get; set; }
}