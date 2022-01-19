using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: ExportFont("Poppins-Bold.ttf", Alias = "Poppins-Bold")]
[assembly: ExportFont("Poppins-Medium.ttf", Alias = "Poppins-Medium")]
[assembly: ExportFont("Poppins-Regular.ttf", Alias = "Poppins-Regular")]
[assembly: ExportFont("Poppins-SemiBold.ttf", Alias = "Poppins-SemiBold")]
namespace DatingApp.UI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
    }
}
