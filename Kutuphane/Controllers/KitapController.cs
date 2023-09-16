using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kutuphane.Controllers
{
    public class KitapController : Controller
    {
        //dependency injection ile contextimizi çekelim
        private readonly IKitapRepository _kitapRepository;

        public KitapController(IKitapRepository kitapRepository)
        {
            _kitapRepository = kitapRepository;
        }

        public IActionResult Index()
        {
            var kitaplar = _kitapRepository.GetAllKitaplar(); // Repository üzerinden kitapları alır orada include tanımlı
            return View(kitaplar);

        }

        public IActionResult Add()
        {
            ViewData["Yazarlar"] = _kitapRepository.GetAllYazarlar();
            ViewData["YayinEvleri"] = _kitapRepository.GetAllYayinEvleri();

            return View();
        }
        //[HttpPost]
        //public IActionResult Add(Kitap kitap, List<int> yazarlar,List<int> yayinEvleri)
        //{
        //    foreach(int s in yazarlar)
        //        kitap.Yazarlar.Add(_kitapRepository.GetAllYazarlar.Find(s));

        //    foreach (int s in yayinEvleri)
        //        kitap.YayinEvleri.Add(_kitapRepository.YayinEvleri.Find(s));


        //    _kitapRepository.AddKitap(kitap);
        //    return RedirectToAction("Index");
        //}

        public IActionResult Update(int id)
        {
            ViewData["Yazarlar"] = _kitapRepository.GetAllYazarlar();
            ViewData["YayinEvleri"] = _kitapRepository.GetAllYayinEvleri();


            return View();
        }

        [HttpPost]
        //public IActionResult Update(Kitap kitap, List<int> yazarlar, List<int> yayinEvleri)
        //{
        //    Kitap asil = _kitapRepository.Kitaplar.Include(k=>k.YayinEvleri).Include(k=>k.Yazarlar).FirstOrDefault(k=>k.Id==kitap.Id);

        //    asil.Ad = kitap.Ad;
        //    asil.ISBN = kitap.ISBN;

        //    List<Yazar> yazarListesi = new List<Yazar>();
        //    List<YayinEvi> yayinEvleriListesi = new List<YayinEvi>();
        //    foreach (int s in yazarlar)
        //        yazarListesi.Add(_kitapRepository.Yazarlar.Find(s));

        //    foreach (int s in yayinEvleri)
        //       yayinEvleriListesi.Add(_kitapRepository.YayinEvleri.Find(s));

        //    asil.Yazarlar = yazarListesi;
        //    asil.YayinEvleri = yayinEvleriListesi;


        //    _kitapRepository.Kitaplar.Update(asil);
        //    _kitapRepository.SaveChanges();
        //    return RedirectToAction("Index");



        //}

        public IActionResult GetAll()
        {
            return Json(new { data = _kitapRepository.GetAll().Include(k => k.Yazarlar).Include(k => k.YayinEvleri).ToList() });

        }

        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Json(_kitapRepository.GetAll().Where(k => k.Id == id).Include(k => k.Yazarlar).Include(k => k.YayinEvleri).First());
        }
    }
}
