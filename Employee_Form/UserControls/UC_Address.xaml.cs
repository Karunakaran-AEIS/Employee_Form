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

namespace Employee_Form.UserControls
{
    /// <summary>
    /// Interaction logic for UC_Address.xaml
    /// </summary>
    public partial class UC_Address : UserControl
    {
        public UC_Address()
        {
            InitializeComponent();
        }




        public string txt_content
        {
            get { return (string)GetValue(txt_contentProperty); }
            set { SetValue(txt_contentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for txt_content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty txt_contentProperty =
            DependencyProperty.Register("txt_content", typeof(string), typeof(UC_Address), new PropertyMetadata(""));



        public string lblContent
        {
            get { return (string)GetValue(lblContentProperty); }
            set { SetValue(lblContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for lblContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty lblContentProperty =
            DependencyProperty.Register("lblContent", typeof(string), typeof(UC_Address), new PropertyMetadata(""));



        public static readonly DependencyProperty EnterTxtProperty =
       DependencyProperty.Register(
           "EnterTxt",
           typeof(ICommand),
           typeof(UC_Address),
           new PropertyMetadata(null));

        public ICommand EnterTxt
        {
            get => (ICommand)GetValue(EnterTxtProperty);
            set => SetValue(EnterTxtProperty, value);
        }

        private void InputBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && EnterTxt?.CanExecute(null) == true)
            {
                EnterTxt.Execute(null);
                e.Handled = true;
            }
        }


        public bool Readonly
        {
            get { return (bool)GetValue(ReadonlyProperty); }
            set { SetValue(ReadonlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Readonly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReadonlyProperty =
            DependencyProperty.Register("Readonly", typeof(bool), typeof(UC_Address), new PropertyMetadata(false));



        public string TextValue
        {
            get { return (string)GetValue(TextValueProperty); }
            set { SetValue(TextValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextValueProperty =
            DependencyProperty.Register("TextValue", typeof(string), typeof(UC_Address), new PropertyMetadata(""));



        public bool IsFocusedpr
        {
            get => (bool)GetValue(IsFocusedProperty);
            set => SetValue(IsFocusedProperty, value);
        }

        public static readonly DependencyProperty IsFocusedprProperty =
            DependencyProperty.Register(
                "IsFocusedpr",
                typeof(bool),
                typeof(UC_Address),
                new PropertyMetadata(false, OnIsFocusedprChanged));

        private static void OnIsFocusedprChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UC_Address control && (bool)e.NewValue)
            {
                control.Dispatcher.BeginInvoke(new Action(() =>
                {
                    control.InnerTextBox1.Focus();          // Ensure this TextBox is named in XAML
                    Keyboard.Focus(control.InnerTextBox1);  // This makes the caret appear
                }), DispatcherPriority.Render);
            }
        }
    }
}
