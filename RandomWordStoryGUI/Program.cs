using System;
using System.Threading;
using Gtk;

namespace NameGeneratorGUI
{
    class Program
    {
        private static MainWindow mainWindow = new MainWindow();

        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();
            mainWindow.ShowAll();
            Application.Run();
        }
    }
}
