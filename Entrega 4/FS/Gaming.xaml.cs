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

namespace FS
{
    /// <summary>
    /// Interaction logic for Gaming.xaml
    /// </summary>
    public partial class Gaming : UserControl
    {
        int a;
        Image[] Amana;
        Image[] Bmana;
        public Gaming()
        {
            InitializeComponent();
            Amana = new Image[10] { Amana1, Amana2, Amana3, Amana4, Amana5, Amana6, Amana7, Amana8, Amana9, Amana0 };
            Bmana = new Image[10] { Bmana1, Bmana2, Bmana3, Bmana4, Bmana5, Bmana6, Bmana7, Bmana8, Bmana9, Bmana0 };
        }

        public void GenerateAMana(int turn)
        {
            if (turn < 10)
            {
                Amana[turn].Visibility = Visibility.Visible;    
            }
            
        }
        public void GenerateBMana(int turn)
        {
            if (turn < 10)
            {
                Bmana[turn].Visibility = Visibility.Visible;
            }
        }

    }
}
