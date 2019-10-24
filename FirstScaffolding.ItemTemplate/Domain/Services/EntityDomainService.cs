using System.Collections.Generic;
using System.Threading.Tasks;
using $DomainInterfaceNamespace$;
using $DomainEntitiesNamespace$;

namespace $DomainServicesNamespace$
{
    public class $Entity$DomainService : I$Entity$DomainService
    {
        private readonly I$Entity$Repository _$lowerEntity$Repository;
        public $Entity$DomainService(I$Entity$Repository $lowerEntity$Repository)
        {
            _$lowerEntity$Repository = $lowerEntity$Repository;
        }
        public async Task<$Entity$> Create($Entity$ $lowerEntity$)
        {
            return await _$lowerEntity$Repository.Create($lowerEntity$);
        }

        public async Task<IEnumerable<$Entity$>> ReadAll()
        {
            return await _$lowerEntity$Repository.ReadAll();
        }

        public async Task<$Entity$> ReadById(int id)
        {
            return await _$lowerEntity$Repository.ReadById(id);
        }

        public async Task Remove(int id)
        {
            await _$lowerEntity$Repository.Remove(id);
        }

        public async Task<$Entity$> Update($Entity$ $lowerEntity$)
        {
            return await _$lowerEntity$Repository.Update($lowerEntity$);
        }
    }
}
