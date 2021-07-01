using Ciber.ViewModels.Catalog.Products;
using Ciber.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ciber.Services.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductEditRequest request);
        Task<int> Delete(int Id);
        Task<List<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetByID(int Id);
        Task<PagedResult<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize);
    }
}
