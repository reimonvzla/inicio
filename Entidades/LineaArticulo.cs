namespace Requerimientos.Entidades
{
    using System;
    using System.Collections.Generic;

    public class LineaArticulo
    {
        public string CoLin { get; set; }
        public string LinDes { get; set; }
        public string DisCen { get; set; }
        public string CoImun { get; set; }
        public string CoReten { get; set; }
        public decimal ComiLin { get; set; }
        public decimal ComiLin2 { get; set; }
        public string ILinDes { get; set; }
        public bool Va { get; set; }
        public bool Movil { get; set; }
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public string Campo3 { get; set; }
        public string Campo4 { get; set; }
        public string Campo5 { get; set; }
        public string Campo6 { get; set; }
        public string Campo7 { get; set; }
        public string Campo8 { get; set; }
        public string CoUsIn { get; set; }
        public string CoSucuIn { get; set; }
        public DateTime FeUsIn { get; set; }
        public string CoUsMo { get; set; }
        public string CoSucuMo { get; set; }
        public DateTime FeUsMo { get; set; }
        public string Revisado { get; set; }
        public string Trasnfe { get; set; }
        public byte[] Validador { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime? Feccom { get; set; }
        public int? Numcom { get; set; }
        public virtual ICollection<SubLineaArticulo> SubLineaArticulo { get; set; }
    }
}
