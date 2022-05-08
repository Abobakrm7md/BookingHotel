using RestSharp;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace BookingHotel.Interface.Configurations
{
    public class CreateClient
    {
        public static IRestClient _restClient;
        public static void IntializeClientRequest()
        {
            _restClient = new RestClient();
            _restClient.BaseUrl = new Uri(@"https://localhost:44385/");
            //var certStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine); //replace with appropriate values based on your cert configuration
            //certStore.Open(OpenFlags.ReadOnly);
            ////var cert = certStore.Certificates.Find(X509FindType.FindByThumbprint, "<cert Thumbprint>", false);
            //var ecdsa = ECDsa.Create(); // generate asymmetric key pair

            //var req = new CertificateRequest("cn=foobar", ecdsa, HashAlgorithmName.SHA256);
            //var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(10));
            //// Create PFX (PKCS #12) with private key
            //File.WriteAllBytes("c:\\temp\\mycert.pfx", cert.Export(X509ContentType.Pfx, "P@55w0rd"));

            //// Create Base 64 encoded CER (public key only)
            //File.WriteAllText("c:\\temp\\mycert.cer",
            //    "-----BEGIN CERTIFICATE-----\r\n"
            //    + Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks)
            //    + "\r\n-----END CERTIFICATE-----");
            //_restClient.ClientCertificates = new X509CertificateCollection();
            //_restClient.ClientCertificates.Add(new X509Certificate2("c:\\temp\\mycert.cer"));
        }
        public static IRestResponse SendRestPostRequest(string resource, Method method ,string token= "", string body = "")
        {
            IntializeClientRequest();
            IRestRequest request = new RestRequest();
            request.Resource = new Uri(_restClient.BaseUrl + resource).ToString();
            request.Method = method;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("content-type", "application/json");
//            request.AddHeader("Authorization", "Bearer " + token);

            var response = _restClient.Execute(method == Method.GET ? request : request.AddJsonBody(body));

            return response;
        }
    }
}
