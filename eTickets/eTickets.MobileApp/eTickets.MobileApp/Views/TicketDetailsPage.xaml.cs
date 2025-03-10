﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eTickets.MobileApp.Utility;
using eTickets.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eTickets.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketDetailsPage : ContentPage
    {
        private TicketDetailsViewModel _model = null;

        public string TicketId { get; set; }
        public bool IsBuying { get; set; }
        public TicketDetailsPage(int id)
        {
            InitializeComponent();
            BindingContext = _model = new TicketDetailsViewModel();
            _model.Id = id;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (StaticHelper.VrstaTicket.Equals("activeAll"))
            {
                ImageTicekt.IsVisible = false;

                LabelKupac.IsVisible = false;
                LabelValueKupac.IsVisible = false;

                LabelProdavac.IsVisible = false;
                LabelValueProdavac.IsVisible = false;
            }
            else
            {
                ButtonBuy.IsVisible = false;
            }

            if (StaticHelper.VrstaTicket.Equals("request") ||  StaticHelper.VrstaTicket.Equals("active"))
            {
                LabelKupac.IsVisible = false;
                LabelValueKupac.IsVisible = false;

                LabelProdavac.IsVisible = false;
                LabelValueProdavac.IsVisible = false;
            }
            else
            {
                ButtonCancel.IsVisible = false;
            }

            if (StaticHelper.VrstaTicket.Equals("buying"))
            {
                LabelKupac.IsVisible = false;
                LabelValueKupac.IsVisible = false;
            }
            if (StaticHelper.VrstaTicket.Equals("selling"))
            {
                LabelProdavac.IsVisible = false;
                LabelValueProdavac.IsVisible = false;
            }

            await _model.Init();
        }

        private async void ButtonBuy_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OnlinePaymentPage(_model.Id));
        }

        
    }
}