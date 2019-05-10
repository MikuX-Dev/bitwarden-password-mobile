﻿using Xamarin.Forms;

namespace Bit.App.Pages
{
    public partial class SharePage : BaseContentPage
    {
        private SharePageViewModel _vm;

        public SharePage(string cipherId = null)
        {
            InitializeComponent();
            _vm = BindingContext as SharePageViewModel;
            _vm.Page = this;
            _vm.CipherId = cipherId;
            SetActivityIndicator();
            _organizationPicker.ItemDisplayBinding = new Binding("Key");
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadOnAppearedAsync(_scrollView, true, () => _vm.LoadAsync());
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        private async void Save_Clicked(object sender, System.EventArgs e)
        {
            if(DoOnce())
            {
                await _vm.SubmitAsync();
            }
        }
    }
}
