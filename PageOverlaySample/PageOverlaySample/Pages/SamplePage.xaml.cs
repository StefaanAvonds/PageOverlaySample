using PageOverlaySample.Framework.Controls;
using PageOverlaySample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PageOverlaySample.Pages
{
    public class SamplePageBase : BaseContentPage<SamplePageViewModel> { }

    public partial class SamplePage : SamplePageBase
    {
        public SamplePage()
        {
            InitializeComponent();
        }

        public void btnStartActivityIndicator_Click(object sender, EventArgs e)
        {
            // TODO: should be done with "Command"
            ViewModel.StartActivityIndicator();
        }

        public void btnStopActivityIndicator_Click(object sender, EventArgs e)
        {
            // TODO: should be done with "Command"
            ViewModel.StopActivityIndicator();
        }
    }
}
