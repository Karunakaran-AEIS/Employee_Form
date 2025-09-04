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

namespace Employee_Form.UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {



        public string lblContent
        {
            get { return (string)GetValue(lblContentProperty); }
            set { SetValue(lblContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for lblContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty lblContentProperty =
            DependencyProperty.Register("lblContent", typeof(string), typeof(UserControl1), new PropertyMetadata(""));




        public string txtContent
        {
            get { return (string)GetValue(txtContentProperty); }
            set { SetValue(txtContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for txtContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty txtContentProperty =
            DependencyProperty.Register("txtContent", typeof(string), typeof(UserControl1), new PropertyMetadata(""));



        public UserControl1()
        {
            InitializeComponent();
        }
    }
}
