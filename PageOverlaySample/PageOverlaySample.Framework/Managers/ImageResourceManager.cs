using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PageOverlaySample.Framework.Managers
{
    /// <summary>
    /// Class that helps with Images from the resources inside the solution.
    /// </summary>
    public static class ImageResourceManager
    {
        private static string _resourcesFolder = "PageOverlaySample.Framework.Resources";

        /// <summary>
        /// Gets the location of an image in the resources-folder.
        /// </summary>
        /// <param name="imageFileName">The image filename with extension.</param>
        /// <returns>The location of the image in the resources-folder.</returns>
        public static String GetImageResource(string imageFileName)
        {
            return $"{_resourcesFolder}.{imageFileName}";
        }

        /// <summary>
        /// Gets the ImageSource of a specific image.
        /// </summary>
        /// <param name="imageFileName">The image filename with extension.</param>
        /// <returns>The ImageSource of the image in the resources-folder.</returns>
        public static ImageSource GetImageSourceFromResources(string imageFileName)
        {
            string fullPath = GetImageResource(imageFileName);

            return ImageSource.FromResource(fullPath);
        }
    }

    /// <summary>
    /// The different image file names that can be used in the solution.
    /// </summary>
    public static class ImageFileNames
    {
        /// <summary>
        /// The background-image.
        /// </summary>
        public static String BackgroundImage = "jupiter.png";
    }
}
