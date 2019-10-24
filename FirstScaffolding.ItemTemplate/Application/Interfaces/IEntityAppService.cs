using System.Threading.Tasks;
using System.Collections.Generic;
using $ApplicationViewModelsNamespace$

namespace $ApplicationInterfacesNamespace$
{
    public interface I$Entity$AppService
    {
        Task<IEnumerable<$Entity$ViewModel>> ReadAll();
        Task<$Entity$ViewModel> ReadById(int id);
        Task<$Entity$ViewModel> Create($Entity$ViewModel $Entity$ViewModel);
        Task<$Entity$ViewModel> Update($Entity$ViewModel $Entity$ViewModel);
        Task Remove(int id);
    }
}
