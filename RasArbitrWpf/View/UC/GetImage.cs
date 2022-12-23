using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RasArbitrWPF.View.UC
{
    internal static class GetImage
    {
        internal static ImageSource doGetImageSourceFromResource(string psAssemblyName, string psResourceName)
        {
            Uri oUri = new Uri("pack://application:,,,/" + psAssemblyName + ";component/" + psResourceName, UriKind.RelativeOrAbsolute);
            return BitmapFrame.Create(oUri);
        }
    }
}
