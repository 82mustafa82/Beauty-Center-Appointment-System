using Beauty.Data;

namespace Beauty.Models
{
    public class CountView
    {
        public CountView()
        {
            BeautyContext context = new BeautyContext();
            this.Musteri = context.Uyes.Count();
            this.Calisan = context.Calisans.Count();
            this.Randevu = context.Randevus.Count();
            this.Hizmet = context.Hizmets.Count();
        }
        public int Musteri { get; set; } = 0;
        public int Calisan { get; set; } = 0;
        public int Hizmet { get; set; } = 0;
        public int Randevu { get; set; } = 0;
    }
}
