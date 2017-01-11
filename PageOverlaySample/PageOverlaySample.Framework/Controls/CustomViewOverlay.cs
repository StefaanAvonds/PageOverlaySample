using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PageOverlaySample.Framework.Controls
{
    /// <summary>
    /// Class that will create the needed overlays (i.e. ActivityIndicator and BackgroundImage).
    /// </summary>
    public class CustomViewOverlay : BindableObject
    {
        private ActivityIndicator _activityIndicator;
        private Label _lblInformation;
        private Image _backgroundImage;

        /// <summary>
        /// Indicator if the ActivityIndicator is running or not.
        /// </summary>
        public Boolean IsBusyActivityIndicator
        {
            get { return (bool)GetValue(IsBusyActivityIndicatorProperty); }
            set { SetValue(IsBusyActivityIndicatorProperty, value); }
        }

        /// <summary>
        /// The text of the information for the ActivityIndicator.
        /// </summary>
        public String ActivityIndicatorInformation
        {
            get { return (string)GetValue(ActivityIndicatorInformationProperty); }
            set { SetValue(ActivityIndicatorInformationProperty, value); }
        }

        /// <summary>
        /// The BackgroundImage of the current page.
        /// </summary>
        public ImageSource PageBackgroundImage
        {
            get { return (ImageSource)GetValue(PageBackgroundImageProperty); }
            set { SetValue(PageBackgroundImageProperty, value); }
        }

        /// <summary>
        /// Identifies the IsBusyActivityIndicator bindable property.
        /// </summary>
        public static readonly BindableProperty IsBusyActivityIndicatorProperty =
            BindableProperty.Create(nameof(IsBusyActivityIndicator), typeof(bool), typeof(CustomViewOverlay), false, BindingMode.TwoWay);

        /// <summary>
        /// Identifies the ActivityIndicatorInformation bindable property.
        /// </summary>
        public static readonly BindableProperty ActivityIndicatorInformationProperty =
            BindableProperty.Create(nameof(ActivityIndicatorInformation), typeof(String), typeof(CustomViewOverlay), String.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Identifies the PageBackgroundImage bindable property.
        /// </summary>
        public static readonly BindableProperty PageBackgroundImageProperty =
            BindableProperty.Create(nameof(PageBackgroundImage), typeof(ImageSource), typeof(CustomViewOverlay), null, BindingMode.TwoWay);

        /// <summary>
        /// Class that will create the needed overlays (i.e. ActivityIndicator and BackgroundImage).
        /// </summary>
        public CustomViewOverlay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize the basic components for the custom view-overlay.
        /// </summary>
        private void InitializeComponent()
        {
            InitializeActivityIndicator();
            InitializeActivityIndicatorInformation();
            InitializePageBackgroundImage();
        }

        /// <summary>
        /// Initialize the ActivityIndicator for the overlay.
        /// </summary>
        private void InitializeActivityIndicator()
        {
            _activityIndicator = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Scale = 2,
                Color = Color.Pink
            };
            _activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, (CustomViewOverlay cvo) => cvo.IsBusyActivityIndicator, BindingMode.TwoWay);
            _activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, (CustomViewOverlay cvo) => cvo.IsBusyActivityIndicator, BindingMode.TwoWay);
        }

        /// <summary>
        /// Initialize the ActivityIndicator information-label for the overlay.
        /// </summary>
        private void InitializeActivityIndicatorInformation()
        {
            _lblInformation = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Pink
            };
            _lblInformation.SetBinding(Label.TextProperty, (CustomViewOverlay cvo) => cvo.ActivityIndicatorInformation, BindingMode.TwoWay);
            _lblInformation.SetBinding(Label.IsVisibleProperty, (CustomViewOverlay cvo) => cvo.IsBusyActivityIndicator, BindingMode.TwoWay);
        }

        /// <summary>
        /// Initialize the Image of the Page Background for the overlay.
        /// </summary>
        private void InitializePageBackgroundImage()
        {
            _backgroundImage = new Image
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Aspect = Aspect.AspectFill
            };
            _backgroundImage.SetBinding(Image.SourceProperty, (CustomViewOverlay cvo) => cvo.PageBackgroundImage, BindingMode.TwoWay);
        }

        /// <summary>
        /// Create the different overlays on page.
        /// </summary>
        /// <param name="currentPageContent">The current contents of the page. These will be added as an individual overlay.</param>
        /// <returns>A new View with every overlay that can be shown on screen.</returns>
        public View CreateOverlay(View currentPageContent)
        {
            // This RelativeLayout will contain every element
            var relativeLayout = new RelativeLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // First we need the background-image
            // Even if no image is set, we still need to add an Image-control to the page
            // Once (by binding) the image is set, it will just appear (in theory)
            relativeLayout.Children.Add(_backgroundImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => parent.Width),
                Constraint.RelativeToParent((parent) => parent.Height)
            );

            // Once that's done, attach the current content of the page
            // This is the content from the XAML-page
            relativeLayout.Children.Add(currentPageContent,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => parent.Width),
                Constraint.RelativeToParent((parent) => parent.Height)
            );

            // Now all that's left is the ActivityIndicator and the information-label
            if (Device.OS == TargetPlatform.Windows)
            {
                _activityIndicator.VerticalOptions = LayoutOptions.FillAndExpand;
                _activityIndicator.HorizontalOptions = LayoutOptions.FillAndExpand;

                relativeLayout.Children.Add(new Frame
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Content = _activityIndicator
                    },
                    Constraint.Constant(0),
                    Constraint.Constant(0),
                    Constraint.RelativeToParent((parent) => parent.Width),
                    Constraint.RelativeToParent((parent) => parent.Height)
                );
            }
            else
            {
                relativeLayout.Children.Add(_activityIndicator,
                    Constraint.RelativeToParent((parent) =>
                    {
                        return (parent.Width / 2) - (_activityIndicator.Width / 2);
                    }),
                    Constraint.RelativeToParent((parent) =>
                    {
                        return (parent.Height / 2) - (_activityIndicator.Height / 2);
                    })
                );
            }
            
            relativeLayout.Children.Add(_lblInformation,
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) =>
                {
                    return (parent.Height / 2) + (_activityIndicator.Height / 2) + _lblInformation.Height;
                })
            );

            return relativeLayout;
        }
    }
}
