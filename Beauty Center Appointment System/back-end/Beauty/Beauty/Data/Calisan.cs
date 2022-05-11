using System;
using System.Collections.Generic;

namespace Beauty.Data
{
    public partial class Calisan
    {
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public int Cid { get; set; }
        public DateTime? Dgunu { get; set; }
        public string? Adres { get; set; }
        public string? Cinsiyet { get; set; }
        public float Maas { get; set; }
    }
}
