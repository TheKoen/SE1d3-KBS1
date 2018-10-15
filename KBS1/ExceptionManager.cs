using System;
using System.Windows;

namespace KBS1
{
    public class ExceptionManager
    {
        public static bool Debug = true;

        public static void Catch(Exception exception)
        {
            if (Debug)
            {
                throw exception;
            }
            else
            {
                MessageBox.Show($"{exception.Message}", "Error");
                GameWindow.Instance.LoadHome();
            }
        }
    }
}
