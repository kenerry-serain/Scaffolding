using $DomainEntitiesNamespace$;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $DomainInterfacesNamespace$ 
{
    public interface I$Entity$Repository
    {
        Task<IEnumerable<$Entity$>> ReadAll();
        Task<$Entity$> ReadById(int id);
        Task<$Entity$> Create($Entity$ $lowerEntity$);
        Task<$Entity$> Update($Entity$ $lowerEntity$);
        Task Remove(int id);
    }
}
