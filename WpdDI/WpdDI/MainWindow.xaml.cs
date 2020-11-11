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

namespace WpdDI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDateTimeService _dateTimeService;
        public MainWindow(IDateTimeService dateTimeService)
        {
            InitializeComponent();
            _dateTimeService = dateTimeService;
            DataContext = this;
        }

        public string DateTime
        {
            get { return _dateTimeService.GetDateTimeString(); }
            set { }
        }
    }
}
