using $DomainEntitiesNamespace$;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $ApplicationInterfacesNamespace$
{
    public interface I$Entity$DomainService
    {
        Task<IEnumerable<$Entity$>> ReadAll();
        Task<$Entity$> ReadById(int id);
        Task<$Entity$> Create($Entity$ $lowerEntity$);
        Task<$Entity$> Update($Entity$ $lowerEntity$);
        Task Remove(int id);
    }
}
