using Microsoft.EntityFrameworkCore;
using She.Data;
using She.Data.Interfaces;
using She.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace She.Services.ProductsServices
{
    public class ProductService : IProduct
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            product.CreationDate = DateTime.UtcNow;
            product.LastEdit = DateTime.UtcNow;
            product.UserId = 6;

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }


        public async Task Delete(int id) { _context.Remove(await _context.Products.FindAsync(id)); await SaveAll(); }





        public async Task<Product> GetById(int id)
        {
            var product = await _context.Products.Include(p => p.Category).Include(p => p.SubCategory).Include(p => p.ProductPhotos)
                          .Include(p => p.User).Include(p => p.Seller).SingleOrDefaultAsync(p => p.Id == id);


            //Collect product sizes 
            var sizeIds = await _context.ProductSizes.Where(p => p.ProductId == id).Select(p => p.AvailableSizeId).ToListAsync();
            

            return (product);
        }



        public async Task<List<Product>> List()
        {
            return await _context.Products.Include(p => p.ProductSizes).ThenInclude(p=> p.AvailableSize)
                        .Include(p => p.ProductPhotos).Include(p => p.Category).Include(p => p.SubCategory)
                        .Include(p => p.User).Include(p => p.Seller).ToListAsync();
        }



        public async Task<bool> SaveAll() => await _context.SaveChangesAsync() > 0;


        public async Task<bool> Update(Product product)
        {
            product.LastEdit = DateTime.UtcNow;
            _context.Entry(product).State = EntityState.Modified;
            if (await SaveAll()) return true;
            else return false;
        }


        public async Task<bool> SaveImages(int productId, IEnumerable<dynamic> files)
        {
            if (files.Count() > 0)
            {
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads", "ProductsImages", productId.ToString());
                if (!Directory.Exists(pathToSave)) Directory.CreateDirectory(pathToSave);

                // check if the url exists
                var photosWithSameProductId = await _context.ProductPhotos.Where(ph => ph.ProductId == productId).ToListAsync();

                foreach (var file in files)
                {
                    // Copy to server folder
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create)) file.CopyTo(stream);

                    // save path to db
                    var photoToDb = new ProductPhoto()
                    {
                        Url = "~/Uploads/ProductsImages/" + productId.ToString() + "/" + fileName,
                        DateAdded = DateTime.UtcNow,
                        ProductId = productId
                    };

                    foreach (var photo in photosWithSameProductId)
                    {
                        if (photo.Url == photoToDb.Url) return false;
                    }

                    _context.ProductPhotos.Add(photoToDb);
                    _context.SaveChanges();
                }
                return true;
            }

            else return false;
        }



        public async Task SaveProductSizes(int id, IEnumerable<int> sizes)
        {
            if(sizes.Count() > 0)
            {
                foreach (var size in sizes)
                {
                    var productSize = new ProductSize() { AvailableSizeId = size, ProductId = id };
                    await _context.SaveChangesAsync();
                }
            }
        }


        public void SaveProductColors(int id, IEnumerable<int> colors)
        {
            if (colors.Count() > 0)
            {
                foreach (var color in colors)
                {
                    //var productColor = new ProductColor() { AvailableColorId = color, ProductId = id };
                    //await _context.SaveChangesAsync();
                }
            }
        }

       

        ///---


    }
}
