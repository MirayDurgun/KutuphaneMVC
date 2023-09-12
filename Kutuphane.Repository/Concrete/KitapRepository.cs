using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Repository.Shared.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository.Concrete
{
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        private readonly KutuphaneContext _db;

        public KitapRepository(KutuphaneContext db) : base(db)
        {
            _db = db;
        }


        public List<Kitap> GetAllKitaplar()
        {
            return _db.Kitaplar
                .Include(k => k.YayinEvleri)
                .Include(k => k.Yazarlar)
                .ToList();
        }
        public List<Yazar> GetAllYazarlar()
        {
            return _db.Yazarlar.ToList();
        }

        public List<YayinEvi> GetAllYayinEvleri()
        {
            return _db.YayinEvleri.ToList();
        }
        public void Add(Kitap kitap, List<int> yazarlar, List<int> yayinEvleri)
        {
            foreach (int s in yazarlar)
            { kitap.Yazarlar.Add(_db.Yazarlar.Find(s)); }


            foreach (int s in yayinEvleri)
            { kitap.YayinEvleri.Add(_db.YayinEvleri.Find(s)); }

            _db.Kitaplar.Add(kitap);
            _db.SaveChanges();

        }

        public void AddKitap(Kitap kitap)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            _db.Update(id);
            _db.Kitaplar.Include(k => k.Yazarlar).Include(k => k.YayinEvleri).FirstOrDefault(k => k.Id == id);
        }

    }
}
