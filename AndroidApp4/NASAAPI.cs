using System.Net;

namespace AndroidApp4
{
    public class NASAAPI
    {
        HttpWebRequest _request;
        string _address;
        public string Response {  get; set; }

        public NASAAPI(string address)
        {
            _address = address;
        }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "GET";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    Response = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
