using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Assets.Scripts.Networking
{
    internal class HttpClient
    {
        private const string URI = "https://dev3r02.elysium.today/inventory/status";
        public static void Post(string body)
        {
            var r = UnityWebRequest.Post(URI, body);
            var v = r.SendWebRequest();
            v.completed += V_completed;
        }

        private static void V_completed(UnityEngine.AsyncOperation obj)
        {
          
        }
    }
}
