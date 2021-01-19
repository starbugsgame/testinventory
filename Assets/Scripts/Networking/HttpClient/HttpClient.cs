using UnityEngine.Networking;

namespace Assets.Scripts.Networking.HttpClient
{
    internal class HttpClient
    {
        private const string URI = "https://dev3r02.elysium.today/inventory/status";
        public static void Post(string body)
        {
            var req = UnityWebRequest.Post(URI, body);
            req.SetRequestHeader("Auth", "BMeHG5xqJeB4qCjpuJCTQLsqNGaqkfB6");
            var reqOperation = req.SendWebRequest();
            reqOperation.completed += OperationCompleted;
        }

        private static void OperationCompleted(UnityEngine.AsyncOperation obj)
        {
            if (((UnityWebRequestAsyncOperation)obj).webRequest.result != UnityWebRequest.Result.Success)
            {
                // Roll back changes on client
            }
        }
    }
}
