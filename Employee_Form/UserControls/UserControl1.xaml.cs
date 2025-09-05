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
using System.Windows.Threading;
using Employee_Form.HelperClass;

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

        public static readonly DependencyProperty EnterKeyCommandProperty =
       DependencyProperty.Register(
           "EnterKeyCommand",
           typeof(ICommand),
           typeof(UserControl1),
           new PropertyMetadata(null));

        public ICommand EnterKeyCommand
        {
            get => (ICommand)GetValue(EnterKeyCommandProperty);
            set => SetValue(EnterKeyCommandProperty, value);
        }

        private void InputBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && EnterKeyCommand?.CanExecute(null) == true)
            {
                EnterKeyCommand.Execute(null);
                e.Handled = true;
            }
        }

        public bool IsFocused     
        {
            get => (bool)GetValue(IsFocusedProperty);
            set => SetValue(IsFocusedProperty, value);
        }

        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.Register(
                "IsFocused",
                typeof(bool),
                typeof(UserControl1),
                new PropertyMetadata(false, OnIsFocusedChanged));

        private static void OnIsFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UserControl1 control && (bool)e.NewValue)
            {
                control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    control.InnerTextBox.Focus();          // Ensure this TextBox is named in XAML
                    Keyboard.Focus(control.InnerTextBox);  // This makes the caret appear
                }), DispatcherPriority.Render);
            }
        }



        public bool Read
        {
            get { return (bool)GetValue(ReadProperty); }
            set { SetValue(ReadProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Read.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReadProperty =
            DependencyProperty.Register("Read", typeof(bool), typeof(UserControl1), new PropertyMetadata(false));



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
