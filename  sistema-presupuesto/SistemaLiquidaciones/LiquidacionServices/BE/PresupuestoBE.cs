using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiquidacionServices.BE
{
    public class PresupuestoBE
    {
        public int PRESUPUESTOID{get;set;}
        public int CENTROGESTORID{get;set;}
        public int PARTIDAID{get;set;}
        public int ANHO{get;set;}
        public string MES{get;set;}
        public double MONTO{get;set;}
        public double MONTODISPONIBLE{get;set;}
        public string PARTIDA { get; set; }

    }
}