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

namespace KBS1
{
    /// <summary>
    /// Interaction logic for ObjectInfoContainer.xaml
    /// </summary>
    public partial class ObjectInfoContainer : UserControl
    {
        public ImageSource ImageSource
        {
            get => ImgIcon.Source;
            set { ImgIcon.Source = value; }
        }
        
        public string GameObjectName
        {
            get => TxbName.Text;
            set { TxbName.Text = value; }
        }
        
        public string GameObjectDescription
        {
            get => TxbDescription.Text;
            set { TxbDescription.Text = value; }
        }


        public ObjectInfoContainer()
        {
            InitializeComponent();
        }
    }
}
