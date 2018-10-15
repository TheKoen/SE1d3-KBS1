using System;
using System.Linq;
using System.Windows.Media;

namespace KBS1.Windows
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
            set => TxbName.Text = FirstCharToUpper(value);
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

        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}