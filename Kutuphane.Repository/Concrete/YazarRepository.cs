using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Repository.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository.Concrete
{
    public class YazarRepository:Repository<Yazar>,IYazarRepository
    {
        private readonly KutuphaneContext _db;

        public YazarRepository(KutuphaneContext db):base(db)
        {
            _db = db;
        }

        public List<Kitap> YazarinTumKitaplari(int id)
        {
           return _db.Kitaplar.Where(k=>k.Yazarlar.Any(y => y.Id == id)).ToList();
        }
    }
}
