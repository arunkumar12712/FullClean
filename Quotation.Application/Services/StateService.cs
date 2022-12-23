using MapsterMapper;
using Quotation.Application.Repositories.Interface;
using Quotation.Application.Services.Interfaces;
using Quotation.Application.ViewModel;
using Quotation.Domain.Entities;

namespace Quotation.Application.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public StateService(IStateRepository stateRepository, IMapper mapper) 
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }
        public StateViewModel CreateState(StateViewModel state)
        {
            var result = _stateRepository.CreateState(_mapper.Map<State>(state));
            return _mapper.Map<StateViewModel>(result);
        }

        public List<StateViewModel> GetAllStates()
        {
            return _mapper.Map<List<StateViewModel>>(_stateRepository.GetAllStates());
        }
    }
}
