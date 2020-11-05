namespace Requerimientos.Entidades
{
    using System;
    public class UnidadesArticulo
    {
        public string CoArt { get; set; }
        public string CoUni { get; set; }
        public bool Relacion { get; set; }
        public decimal Equivalencia { get; set; }
        public bool UsoVenta { get; set; }
        public bool UsoCompra { get; set; }
        public bool UniPrincipal { get; set; }
        public bool UsoPrincipal { get; set; }
        public bool UniSecundaria { get; set; }
        public bool UsoSecundaria { get; set; }
        public bool UsoNumDecimales { get; set; }
        public int NumDecimales { get; set; }
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

    }
}
