using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using TestDynamicAX.IDynamic;
using System.ComponentModel.Composition.Hosting;

namespace TestDynamicAX.AX
{
    public class DynamicExecuter
    {
        private static CompositionContainer _container;

        public string Execute(string param)
        {
            //var assemblyCatalog = new AssemblyCatalog(typeof(ProxyExecuter).Assembly);

            var directoryCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "\\Parts", "*.dll");
            _container = new CompositionContainer(directoryCatalog);

            var export = _container.GetExports<IDynamicExecuter>().First();

            //ProxyExecuter executer = new ProxyExecuter();
            //_container.ComposeParts(executer);//组装部件

            return export.Value.Execute(param);
        }

        internal class ProxyExecuter {
            [Import(typeof(IDynamicExecuter))]
            public IDynamicExecuter Executer { get; set; }

            public string Execute(string param)
            {
                return Executer.Execute(param);
            }
        }
    }
}
