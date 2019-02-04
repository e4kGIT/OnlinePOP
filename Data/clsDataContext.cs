using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;

namespace DAL.Data
{
    public class StatusUpdate
    {
        
        public bool TriggerEvent { get; set; }
    }
    public partial class DataContext
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "LITwCMMwRkb4GqPzv74N5rIonNpMbv5jhFKLtAOo",
            BasePath = "https://e4kpop-2018.firebaseio.com",            
        };
        private void Contitions()
        { }
        public override int SaveChanges()
        {
            int changes = base.SaveChanges();
            //CallFirebaseUpdation();
            UpdateToFirebase(true);
            return changes;
        }
        public void UpdateToFirebase(bool StatusUpdate)
        {
            IFirebaseClient client = new FirebaseClient(config);
            if (client != null)
            {
                var response = client.Set("/StatusUpdate", StatusUpdate);
            }
        }
        private void CallFirebaseUpdation()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = js.Serialize(new { StatusUpdate = true });
            var request = WebRequest.CreateHttp("https://e4kpop-2018.firebaseio.com/.json");
            request.Method = "POST";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(obj);
            request.ContentLength = buffer.Length;            
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            var json = (new StreamReader(response.GetResponseStream())).ReadToEnd();

        }
    }
}
