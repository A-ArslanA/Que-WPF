﻿using Que.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Que.MVVM.ViewModel
{

    // all for see needed radio-button window

    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand FeaturedViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public DiscoveryViewModel DiscoveryVM { get; set; }
        public FeaturedViewModel FeaturedVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                onPropertyChanged();
            }
        }

        // constructor
        public MainViewModel() 
        {
            HomeVM = new HomeViewModel(); // open need window
            DiscoveryVM = new DiscoveryViewModel();
            FeaturedVM = new FeaturedViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVM;
            });

            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryVM;
            });

            FeaturedViewCommand = new RelayCommand(o =>
            {
                CurrentView = FeaturedVM;
            });
        }
    }
}
