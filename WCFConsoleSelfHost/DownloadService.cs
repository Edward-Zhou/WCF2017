using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFConsoleSelfHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IDownloadService" in both code and config file together.
    public class DownloadService : IDownloadService
    {
        public string GetData()
        {
            return "aaa";
        }

        public File DownloadDocument()
        {
            File file = new File
            {
                Content = System.IO.File.
                    ReadAllBytes(@"D:\WCF\Img\Message.png"),
                Name = "Message.png"
            };

            return file;
        }
    }
}
