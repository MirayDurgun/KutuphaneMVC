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
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        private readonly KutuphaneContext _db;

        public KitapRepository(KutuphaneContext db) : base(db)
        {
            _db = db;
        }
    }
}
