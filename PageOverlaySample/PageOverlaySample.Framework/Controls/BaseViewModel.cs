using PageOverlaySample.Framework.Interfaces;
using PageOverlaySample.Framework.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PageOverlaySample.Framework.Controls
{
    public class BaseViewModel : IBaseViewModel, INotifyPropertyChanged
    {
        private string _activityIndicatorInformation;
        private bool _isBusy;
        private ImageSource _backgroundImageSource;

        /// <summary>
        /// Information on what the system is doing while the ActivityIndicator is running.
        /// </summary>
        public String ActivityIndicatorInformation
        {
            get { return _activityIndicatorInformation; }
            set
            {
                _activityIndicatorInformation = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Value for the ActivityIndicator.
        /// </summary>
        public Boolean IsBusyActivityIndicator
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();

                if (!_isBusy) ActivityIndicatorInformation = String.Empty;
            }
        }

        /// <summary>
        /// The Background Image for the ContentPage.
        /// </summary>
        public ImageSource PageBackgroundImage
        {
            get { return _backgroundImageSource; }
            set
            {
                _backgroundImageSource = value;
                OnPropertyChanged();
            }
        }

        public BaseViewModel()
        {
            ActivityIndicatorInformation = String.Empty;

            PageBackgroundImage = ImageResourceManager.GetImageSourceFromResources(ImageFileNames.BackgroundImage);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
