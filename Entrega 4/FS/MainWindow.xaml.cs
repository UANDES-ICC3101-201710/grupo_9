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
using System.Windows.Interop;

namespace FS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Strtbtn.MouseEnter += new MouseEventHandler(Strtbtn_MouseEnter);
            Strtbtn.MouseLeave += new MouseEventHandler(Strtbtn_MouseLeave);
        }

       void Strtbtn_MouseLeave(object sender, EventArgs e)
        {
            var BphaseA = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.Bphase1.GetHbitmap(),
                                  IntPtr.Zero,
                                  Int32Rect.Empty,
                                  BitmapSizeOptions.FromEmptyOptions());
            this.Strtbtn.Background = new ImageBrush(BphaseA);
        }
        void Strtbtn_MouseEnter(object sender, EventArgs e)
        {
            var BphaseB = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.Bphase2.GetHbitmap(),
                                  IntPtr.Zero,
                                  Int32Rect.Empty,
                                  BitmapSizeOptions.FromEmptyOptions());
            this.Strtbtn.Background = new ImageBrush(BphaseB);
        }

        private void Starto(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HeroSelect());
        }

    }
}
