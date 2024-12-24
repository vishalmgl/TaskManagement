using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskManagement.Application.Interfaces.Repositories;
using TaskManagement.Application.Wrappers;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.CityFeatures.Queries
{
    public class GetCityQuery : IRequest<APIResponse<City?>>
    {
        public string? Code { get; set; }

        public class GetCityQueryHandler : IRequestHandler<GetCityQuery, APIResponse<City?>>
        {
            private readonly ICityRepository _cityRepository;

            public GetCityQueryHandler(ICityRepository cityRepository)
            {
                _cityRepository = cityRepository;
            }

            public async Task<APIResponse<City?>> Handle(GetCityQuery query, CancellationToken cancellationToken)
            {
                City? city = await _cityRepository.GetAsync(ct => ct.Code == query.Code);
                if (city == null) return new APIResponse<City?>(null);
                return new APIResponse<City?>(city);
            }
        }
    }
}
