using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LiquidacionServices.BE
{
    [DataContract]
    public class PresupuestoBE
    {
        [DataMember]
        public int PRESUPUESTOID { get; set; }
        [DataMember]
        public int CENTROGESTORID { get; set; }
        [DataMember]
        public int PARTIDAID { get; set; }
        [DataMember]
        public int ANHO { get; set; }
        [DataMember]
        public string MES { get; set; }
        [DataMember]
        public double MONTO { get; set; }
        [DataMember]
        public double MONTODISPONIBLE { get; set; }
        [DataMember]
        public string PARTIDA { get; set; }
        [DataMember]
        public Boolean EXCEDIDO { get; set; }
        [DataMember]
        public int DETPRESUPUESTO { get; set; }
        [DataMember]
        public string CENTROGESTOR { get; set; }
        [DataMember]
        public double MONTOEXCEDIDO { get; set; }

    }
}