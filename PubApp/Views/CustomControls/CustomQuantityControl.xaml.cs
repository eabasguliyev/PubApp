using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PubApp.ViewModels;

namespace PubApp.Views.CustomControls
{
    /// <summary>
    /// Interaction logic for CustomQuantityControl.xaml
    /// </summary>
    public partial class CustomQuantityControl : UserControl
    {
        public CustomQuantityControl()
        {
            this.DataContext = new CustomQuantityControlViewModel();
            InitializeComponent();
        }
    }
}
