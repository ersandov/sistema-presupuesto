using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using LiquidacionServices.BE;
using System.Web.Script.Serialization;

namespace TestPresupuesto
{
    [TestClass]
    public class TestGasto
    {
        [TestMethod]
        public void TestGastoExcedido()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:50534/GastoExcedidoSrv.svc/GastosExcedidos/1/2015/1");
            req.Method = "GET";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string gastoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<PresupuestoBE> gastolista = js.Deserialize<List<PresupuestoBE>>(gastoJson);
            Assert.AreEqual(true, (gastolista.Count > 0) ? true : false);
        }
    }
}
