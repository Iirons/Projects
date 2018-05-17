using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.BL;
using Projects.BL.Services;

namespace Projects.PL
{
    public class ProjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProjectsService>().To<ProjectsService>();
        }
    }
}
