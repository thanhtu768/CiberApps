using Ciber.Data.EF;
using Ciber.Data.Enititys;
using Ciber.ViewModels.Catalog.Products;
using Ciber.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ciber.Services.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly CiberDbContext _context;
        public ManageProductService(CiberDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Name = request.Name
            };
            _context.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductViewModel> GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
