using System.Windows.Media;

namespace KBS1
{
    /// <summary>
    /// Interaction logic for ObjectInfoContainer.xaml
    /// </summary>
    public partial class ObjectInfoContainer
    {
        public ImageSource ImageSource
        {
            get => ImgIcon.Source;
            set => ImgIcon.Source = value;
        }
        
        public string GameObjectName
        {
            get => TxbName.Text;
            set => TxbName.Text = value;
        }
        
        public string GameObjectDescription
        {
            get => TxbDescription.Text;
            set => TxbDescription.Text = value;
        }


        public ObjectInfoContainer()
        {
            InitializeComponent();
        }
    }
}
