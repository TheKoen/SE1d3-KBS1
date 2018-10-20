using System;
using System.Windows;

namespace KBS1.Util
{
    public class ExceptionManager
    {
        public static bool Debug = false;

        public static void Catch(Exception exception)
        {
            if (Debug) throw exception;

            MessageBox.Show($"{exception.Message}", "Error");
            GameWindow.Instance.LoadHome();
        }
    }
}