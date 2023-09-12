using Kutuphane.Data;
using Kutuphane.Models;
using Kutuphane.Repository.Abstract;
using Kutuphane.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class YazarController : Controller
    {
        //Dependency Injection
        private readonly IYazarRepository _repo;
        

        public YazarController(IYazarRepository repo)
        {
            _repo = repo;
          
        }

        public IActionResult Index()
        {
            
            return View();
        }

        //CONCRETE
        public IActionResult GetAll()
        {

            
            return Json(new { data = _repo.GetAll() });
        }
               
        public IActionResult Delete(int id)
        {
            // Yazar yazar = _context.Yazarlar.Where(y => y.Id == id).First();

            // Yazar yazar = _context.Yazarlar.FirstOrDefault(x => x.Id == id);

            _repo.Remove(_repo.GetById(id));
            _repo.Save();
           

            


            return RedirectToAction("Index");

        }
             

        public IActionResult Upsert(int id)
        {
            if (id != 0)
            {
                return View(_repo.GetById(id));
            }
            else {
                return View();
            }
          
        }
        [HttpPost]
        public IActionResult Upsert(Yazar yazar)
        {
            if(yazar.Id==0)
            {
                _repo.Add(yazar);
                _repo.Save();
            }
            else
            {
                _repo.Update(yazar);
                _repo.Save();
            }
            return RedirectToAction("Index");
        }


    }
}
