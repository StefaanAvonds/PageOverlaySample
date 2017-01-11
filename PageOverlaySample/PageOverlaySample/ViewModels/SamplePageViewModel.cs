using PageOverlaySample.Framework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageOverlaySample.ViewModels
{
    public class SamplePageViewModel : BaseViewModel
    {
        private string _information;

        /// <summary>
        /// Entry Text.
        /// </summary>
        public String Information
        {
            get { return _information; }
            set
            {
                _information = value;
                OnPropertyChanged();
            }
        }

        public SamplePageViewModel()
        {

        }

        /// <summary>
        /// Start the ActivityIndicator.
        /// </summary>
        public void StartActivityIndicator()
        {
            IsBusyActivityIndicator = true;
            ActivityIndicatorInformation = Information;
        }

        /// <summary>
        /// Stop the ActivityIndicator.
        /// </summary>
        public void StopActivityIndicator()
        {
            IsBusyActivityIndicator = false;
        }
    }
}
