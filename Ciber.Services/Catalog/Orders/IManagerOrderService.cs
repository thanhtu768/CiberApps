using Ciber.Data.Enititys;
using Ciber.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ciber.Services.Catalog.Orders
{
    public interface IManagerOrderService<ReqCreate,ReqEdit,ObjView,ReqPage>
    {
        Task<int> Create(ReqCreate obj);
        Task<int> Update(ReqEdit obj);
        Task<int> Delete(int Id);
        Task<List<ObjView>> GetAll();
        Task<PagedResult<ObjView>> GetAllPaging(ReqPage page);
        Task<ObjView> GetByID(int ID);
        Task<List<Product>> ListSourceProduct();
        Task<List<Customer>> ListSourceCustomer();
    }
}
