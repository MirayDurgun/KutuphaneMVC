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
        }

        public override IQueryable<Kitap> GetAll()
        {
            return _db.Kitaplar.Include(k => k.Yazarlar).Include(k => k.YayinEvleri);
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

        public void AddKitap(Kitap kitap)
        {


            foreach (var item in kitap.Yazarlar.Select(y => y.Id).ToList())
            //kitap üzerinden yazarlara erişiyoruz. ve her yazarın idsini seçip liste dönüştürüyoruz
            {
                var yazar = _db.Yazarlar.Find(item); //itemda id değeri var, belitilen idye sahip olan yazarı arar
                if (yazar != null) //yazar boş değilse
                {
                    kitap.Yazarlar.Add(yazar); //kitap nersnesine yazarı ekle
                }
            }

            foreach (var item in kitap.YayinEvleri.Select(ye => ye.Id).ToList())
            {
                var yayinEvi = _db.YayinEvleri.Find(item);
                if (yayinEvi != null)
                {
                    kitap.YayinEvleri.Add(yayinEvi);
                }
            }

            _db.Kitaplar.Add(kitap);
            _db.SaveChanges();
        }

        public void Update(int id)
        {
            _db.Update(id);
            _db.Kitaplar.Include(k => k.Yazarlar).Include(k => k.YayinEvleri).FirstOrDefault(k => k.Id == id);
        }
    }

}

