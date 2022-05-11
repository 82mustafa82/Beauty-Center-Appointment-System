using System;
using System.Collections.Generic;

namespace Beauty.Data
{
    public partial class Uye
    {
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public int Uid { get; set; }
        public string? Cinsiyet { get; set; }
        public string Email { get; set; } = null!;
        public string Sifre { get; set; } = null!;
        public string? Telefon { get; set; }
    }
}
