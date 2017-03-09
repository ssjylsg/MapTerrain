using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MapTerrain
{
    class TerrainHelper
    {
        private string filePath;
        private WebProxy proxy;
        public TerrainHelper(string filePath)
        {
            this.filePath = filePath;
            this.proxy = new WebProxy("http://127.0.0.1:8087");
        }

        private string url = "http://assets.agi.com/stk-terrain/tilesets/world/tiles/{0}/{1}/{2}.terrain?v=1.31376.0&f=TerrainTile";

        public void DownLoad()
        {
             
            this.DownLayerJson();


            //var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(
            //      new StreamReader(Path.Combine(this.filePath, "layer.json")).ReadToEnd()) as Newtonsoft.Json.Linq.JObject;
            //var available = obj.GetValue("available").ToList().ToArray();
            //for (int i = 0; i < available.Length; i++)
            //{
            //    var p = available[i].ToArray()[0];
            //    Console.WriteLine(p);
                
            //}

            var java = new System.Web.Script.Serialization.JavaScriptSerializer();
            java.MaxJsonLength = int.MaxValue;
            var availableObj = (java.DeserializeObject(new StreamReader(Path.Combine(this.filePath, "layer.json")).ReadToEnd()) as Dictionary<string, object>)["available"];

            Console.WriteLine(availableObj);
            var available = (Object[]) availableObj;



            //for (int i = 7; i < 9; i++)
            //{
            //    var list = ((Object[])available[i]);
            //    for (int j = 0; j < list.Length; j++)
            //    {
            //        var dict = (Dictionary<string, object>) list[j];
            //        DownLoadCell(int.Parse(dict["startX"].ToString()), int.Parse(dict["startY"].ToString()), int.Parse(dict["endX"].ToString()), int.Parse(dict["endY"].ToString()), i);
            //    }
            //}
            var start =
                new
                {
                    startX = 6400,
                    endX = 6500,
                    startY = 2880,
                    endY = 2890 
                };
            var startZoom = 12;
            for (int zoom = startZoom; zoom <= 14; zoom++)
            {
                int startX = start.startX * (zoom - startZoom + 1);
                int endX = start.endX * (zoom - startZoom + 1);
                for (int x = startX; x <=endX ; x++)
                {
                    int startY = start.startY * (zoom - startZoom + 1);
                    int endY = start.endY * (zoom - startZoom + 1);
                    for (int y = startY; y <= endY; y++)
                    {
                        DownLoad(zoom, x, y);
                    }
                }
            }
             
            MessageBox.Show("OK");
        }

        public void DownLoadCell(int startX, int startY, int endX, int endY, int zoom)
        {
            for (int i = startX; i <= endX; i++)
            {
                for (int j = startY; j <= endY; j++)
                {
                    this.DownLoad(zoom,i,j);
                }
            }
        }

        private void DownLayerJson()
        {
            if (File.Exists(Path.Combine(this.filePath, "layer.json")))
            {
                return;
            }
            var layer = "https://assets.agi.com/stk-terrain/world/layer.json";
            using (var client = new WebClient())
            {
                client.Proxy = this.proxy;
                client.Headers.Add("Accept", "application/json,*/*;q=0.01");
                client.Headers.Add("Accept-Encoding", "gzip, deflate, sdch, br");
                client.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");

                var content = client.DownloadString(layer);
                var buffer = System.Text.ASCIIEncoding.UTF8.GetBytes(content);
                 
                var fileStream = new FileStream(Path.Combine(this.filePath, "layer.json"), FileMode.OpenOrCreate);
                fileStream.Write(buffer, 0, buffer.Length);
                fileStream.Close();

            }

        }

        public void DownLoad(int z, int x, int y)
        {
            var temp = System.IO.Path.Combine(this.filePath, z.ToString());
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
                temp = System.IO.Path.Combine(temp, x.ToString());
                Directory.CreateDirectory(temp);
            }
            else
            {
                temp = System.IO.Path.Combine(temp, x.ToString());
                if (!Directory.Exists(temp))
                {
                    Directory.CreateDirectory(temp);
                }
            }
            var target = Path.Combine(temp, string.Format("{0}.terrain", y));
            if (File.Exists(target))
            {
                return;
            }
            using (var client = new System.Net.WebClient())
            {
                client.Proxy = this.proxy;
                
                 
                var tempUrl = string.Format(url, z, x, y);
              

                //client.DownloadFileAsync(new Uri(tempUrl), target);
                //client.DownloadFileCompleted += (sender, e) =>
                //{
                //    if (e.Error != null)
                //    {
                //        Console.WriteLine(e.Error);
                //    }
                //};

                try
                {
                    var buffer = client.DownloadData(tempUrl);
                    using (var fileStream = new FileStream(target, FileMode.OpenOrCreate))
                    {
                        fileStream.Write(buffer, 0, buffer.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

 

         
    }
}
