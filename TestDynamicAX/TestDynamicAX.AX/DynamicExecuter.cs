using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.ComponentModel.Composition;
using TestDynamicAX.IDynamic;
using System.ComponentModel.Composition.Hosting;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace TestDynamicAX.AX
{
    public class DynamicExecuter : IObjectSafety
    {
        private static CompositionContainer _container;

        private const string _remoteUrl = "http://localhost:7656/";

        private readonly string _dataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "DynamicAX");

        #region IObjectSafety Members
        public void GetInterfacceSafyOptions(int riid, out int pdwSupportedOptions, out int pdwEnabledOptions)
        {
            pdwSupportedOptions = 1;
            pdwEnabledOptions = 2;
        }

        public void SetInterfaceSafetyOptions(int riid, int dwOptionsSetMask, int dwEnabledOptions)
        {
        }
        #endregion

        public DynamicExecuter()
        {
            Update();
        }

        public string Execute(string name, string param)
        {
            //var assemblyCatalog = new AssemblyCatalog(typeof(ProxyExecuter).Assembly);

            var directoryCatalog = new DirectoryCatalog(_dataPath + "\\Parts", name + ".dll");
            _container = new CompositionContainer(directoryCatalog);

            var export = _container.GetExports<IDynamicExecuter>().FirstOrDefault();

            //ProxyExecuter executer = new ProxyExecuter();
            //_container.ComposeParts(executer);//组装部件

            if (export == null)
            {
                return "not found export";
            }

            return export.Value.Execute(param);
        }

        public string GetUrl()
        {
            return _remoteUrl;
        }

        private void Update()
        {
            Log("update start.");

            if (!Directory.Exists(_dataPath))
            {
                Directory.CreateDirectory(_dataPath);
            }

            var verFile = Path.Combine(_dataPath, "ver.dat");
            var listFile = Path.Combine(_dataPath, "list.dat");
            var partsFolder = Path.Combine(_dataPath, "Parts");


            if (!File.Exists(verFile))
            {
                Log("ver file not exist.");
                Log("_remoteUrl:" + _remoteUrl);

                Download(verFile, listFile, partsFolder);

            }
            else
            {
                Log("ver file existed.");

                try
                {
                    WebClient client = new WebClient();
                    client.DownloadFile(_remoteUrl + "DynamicAX/Ver", verFile + ".new");

                    Log("compare ver file start.");
                    if (File.ReadAllText(verFile) != File.ReadAllText(verFile + ".new"))
                    {
                        Log("compare ver file : false");
                        Download(verFile, listFile, partsFolder);
                    }
                }
                catch (Exception ex)
                {
                    Log("compare ver file error: " + ex.Message);
                }
            }
        }

        private void Download(string verFile, string listFile, string partsFolder)
        {
            Log("down start.");
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(_remoteUrl + "DynamicAX/List", listFile);

                var files = File.ReadAllText(listFile).Split(',');

                if (!Directory.Exists(partsFolder))
                {
                    Directory.CreateDirectory(partsFolder);
                }

                Log("down part start.");
                foreach (var file in files)
                {

                    client.DownloadFile(_remoteUrl + file,
                        Path.Combine(
                        partsFolder,
                        Path.GetFileName(file).Replace(".part", "")));
                }

                //所有dll都下载完毕后再更新版本
                client.DownloadFile(_remoteUrl + "DynamicAX/Ver", verFile);
            }
            catch (Exception ex)
            {
                Log("download error: " + ex.Message);
            }
        }

        private void Log(string s)
        {
            File.AppendAllText(Path.Combine(_dataPath, "update.log"),
                String.Format("[{0}] {1} \r\n", DateTime.Now, s));
        }

        internal class ProxyExecuter
        {
            [Import(typeof(IDynamicExecuter))]
            public IDynamicExecuter Executer { get; set; }

            public string Execute(string param)
            {
                return Executer.Execute(param);
            }
        }
    }
}
