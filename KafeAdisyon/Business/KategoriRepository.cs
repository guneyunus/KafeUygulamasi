using KafeAdisyon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using KafeAdisyon.Data.Models;

namespace KafeAdisyon.Business
{
    public class KategoriRepository : RepositoryBase<Kategori,int>
    {
        public void AddProduct(Kategori kategori, Urun urun)
        {
            _dbContext.Kategoriler.First(x => x.Id == kategori.Id).Urunler.Add(urun);
            _dbContext.SaveChanges();
        }
    }
}
