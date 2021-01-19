using System.Text;
using UnityEngine.Networking;

namespace Assets.Scripts.Networking.HttpClient
{
    internal class HttpClient
    {
        private const string URL = "https://dev3r02.elysium.today/inventory/status";
        public static void Post(string body)
        {
            var req = new UnityWebRequest(URL, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(body);
            req.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");
            req.SetRequestHeader("Authorization", "Bearer " + "BMeHG5xqJeB4qCjpuJCTQLsqNGaqkfB6");

            var reqOperation = req.SendWebRequest();
            reqOperation.completed += OperationCompleted;
        }

        private static void OperationCompleted(UnityEngine.AsyncOperation obj)
        {
            if (((UnityWebRequestAsyncOperation)obj).webRequest.responseCode != 200)
            {
                // Roll back changes on client
            }
        }
    }
}
