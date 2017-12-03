using DotNetBrowser;
using DotNetBrowser.WPF;
using System.Windows;

namespace WPF.DotNetBrowser
{
    public partial class MainWindow : Window
    {
        BrowserView webView;

        public MainWindow()
        {
            InitializeComponent();

            webView = new WPFBrowserView();
            mainLayout.Children.Add((UIElement)webView.GetComponent());
            webView.Browser.LoadURL("http://localhost:58602");
        }
    }
}
