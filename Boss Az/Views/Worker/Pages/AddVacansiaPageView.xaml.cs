﻿using Boss_Az.ViewModels;
using System.Windows.Controls;
namespace Boss_Az.Views.Worker.Pages;

public partial class AddVacansiaPageView : Page
{
    public AddVacansiaPageView()
    {
        InitializeComponent();
        DataContext=new AddVacansiaModel();
    }
}
