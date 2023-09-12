using Kutuphane.Models;
using Kutuphane.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Repository.Abstract
{
    public interface IKitapRepository: IRepository<Kitap>
    {
        List<Kitap> GetAllKitaplar();
        List<Yazar> GetAllYazarlar();
        List<YayinEvi> GetAllYayinEvleri();
        void AddKitap(Kitap kitap);
        void Update(int id);

    }
}
