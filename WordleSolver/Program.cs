using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordleSolver.views;

namespace WordleSolver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static Form currentView;
        public static FileHandler historyFile;

        [STAThread]
        static void Main()
        {
            historyFile = new FileHandler("history.txt");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            currentView = new views.Menu();
            Application.Run(currentView);
        }

        public static void SwitchView(Form form)
        {
            currentView.Controls.Clear();
            currentView.Controls.AddRange(GetControls(form));
        }

        public static Control[] GetControls(Form form)
        {
            IEnumerator componentEnumerator = form.Controls.GetEnumerator();
            List<Control> components = new List<Control>();

            while (componentEnumerator.MoveNext())
            {
                components.Add((Control)componentEnumerator.Current);

            }

            return components.ToArray();
        }

        public static void CloseApplication()
        {
            Application.Exit();
        }
    }
}
