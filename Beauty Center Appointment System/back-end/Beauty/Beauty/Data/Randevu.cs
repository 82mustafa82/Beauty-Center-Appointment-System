using System;
using System.Collections.Generic;

namespace Beauty.Data
{
    public partial class Randevu
    {
        public int id { get; set; }
        public int Uid { get; set; }
        public int Hno { get; set; }
        public int Cid { get; set; }
        public DateTime Tarih { get; set; }

        public virtual Calisan CidNavigation { get; set; } = null!;
        public virtual Hizmet HnoNavigation { get; set; } = null!;
        public virtual Uye UidNavigation { get; set; } = null!;
    }
}
