using System;
using System.Windows;

namespace KBS1.Util
{
    public class ExceptionManager
    {
        public static bool Debug = false;

        /// <summary>
        ///     Shows a MessageBox instead of an exception when the Debug variable is set
        /// </summary>
        /// <param name="exception">The exception to be caught or thrown</param>
        public static void Catch(Exception exception)
        {
            if (Debug) throw exception;

            MessageBox.Show($"{exception.Message}", "Error");
            GameWindow.Instance.LoadHome();
        }
    }
}