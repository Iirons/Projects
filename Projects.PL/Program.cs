using Ninject;
using Ninject.Modules;
using Projects.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects.PL
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NinjectModule projectmodule = new ProjectModule();
            NinjectModule servicemodule = new ServiceModule();
            var kernel = new StandardKernel(projectmodule, servicemodule);
            Application.Run(kernel.Get<Form1>());
        }
    }
}
