using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManagement.Application.Interfaces.Repositories;
using TaskManagement.Domain.Entities;
using TaskManagement.Application.Wrappers;

namespace TaskManagement.Application.Features.CityFeatures.Command
{
    public class CreateCityCommand : IRequest<APIResponse<int>>
    {
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, APIResponse<int>>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;

            public CreateCityCommandHandler(ICityRepository cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }

            public async Task<APIResponse<int>> Handle(CreateCityCommand command, CancellationToken cancellationToken)
            {
                City city = _mapper.Map<City>(command);
                _cityRepository.Add(city);
                int affectedRecordsCount = await _cityRepository.CommitAsync();
                return new APIResponse<int>(affectedRecordsCount);
            }
        }
    }

}
