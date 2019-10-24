using AutoMapper;
using $ApplicationViewModelsNamespace$;
using $ApplicationInterfacesNamespace$;
using $DomainEntitiesNamespace$;
using $DomainInterfacesNamespace$;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace $ApplicationServicesNamespace$
{
    public class $Entity$ApplicationService : I$Entity$AppService
    {
        private readonly I$Entity$DomainService _$lowerEntity$DomainService;
        private readonly IMapper _mapper;
        public $Entity$ApplicationService(I$Entity$DomainService $lowerEntity$DomainService, IMapper mapper)
        {
            _mapper = mapper;
            _$lowerEntity$DomainService = $lowerEntity$DomainService;
        }

        public async Task<$Entity$ViewModel> Create($Entity$ViewModel $lowerEntity$ViewModel)
        {
            var $lowerEntity$ = _mapper.Map<$Entity$>($lowerEntity$ViewModel);
            var created$Entity$ = await _$lowerEntity$DomainService.Create($lowerEntity$);
            return _mapper.Map<$Entity$ViewModel>(created$Entity$);
        }

        public async Task<IEnumerable<$Entity$ViewModel>> ReadAll()
        {
            var $lowerEntity$List = await _$lowerEntity$DomainService.ReadAll();
            return _mapper.Map<IEnumerable<$Entity$ViewModel>>($lowerEntity$List);
        }

        public async Task<$Entity$ViewModel> ReadById(int id)
        {
            var $lowerEntity$ = await _$lowerEntity$DomainService.ReadById(id);
            return _mapper.Map<$Entity$ViewModel>($lowerEntity$);
        }

        public async Task Remove(int id)
        {
            await _$lowerEntity$DomainService.Remove(id);
        }

        public async Task<$Entity$ViewModel> Update($Entity$ViewModel $lowerEntity$ViewModel)
        {
            var $lowerEntity$ = _mapper.Map<$Entity$>($lowerEntity$ViewModel);
            var created$Entity$ = await _$lowerEntity$DomainService.Update($lowerEntity$);
            return _mapper.Map<$Entity$ViewModel>(created$Entity$);
        }
    }
}