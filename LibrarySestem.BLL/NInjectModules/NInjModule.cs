using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace LibrarySestem.BLL.NInjectModules
{
    public class NInjModule : Ninject.Modules.NinjectModule
    {
        private string connectionString;

        public NInjModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<DAL.Interfaces.IUnitOfWork>()
                .To<DAL.UnitOfWork.UnitOfWork>()
                .WithConstructorArgument(connectionString);
        }
    }
}
