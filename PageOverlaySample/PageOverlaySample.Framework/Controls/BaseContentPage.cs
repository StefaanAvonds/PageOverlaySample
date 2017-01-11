using PageOverlaySample.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PageOverlaySample.Framework.Controls
{
    public class BaseContentPage<TViewModel> : ContentPage
        where TViewModel : IBaseViewModel, new ()
    {
        private CustomViewOverlay _customViewOverlay;

        private readonly TViewModel _viewModel;

        /// <summary>
        /// The content of the Page.
        /// Use this property instead of "Content" to create the overlays automatically!
        /// </summary>
        public View MyContent
        {
            get { return Content; }
            set
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Content = _customViewOverlay.CreateOverlay(value);
                });
            }
        }

        /// <summary>
        /// The ViewModel of the current page. This will be specific per Page.
        /// </summary>
        public TViewModel ViewModel => _viewModel;

        public BaseContentPage()
        {
            _viewModel = new TViewModel();
            _customViewOverlay = new CustomViewOverlay();

            BindingContext = _viewModel;
            _customViewOverlay.BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            MyContent = Content;
            base.OnAppearing();
        }
    }
}
