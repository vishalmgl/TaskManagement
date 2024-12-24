using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TaskManagement.Application.Interfaces.Repositories;
using TaskManagement.Domain.Entities;
using TaskManagement.Application.Wrappers;

namespace TaskManagement.Application.Features.CityFeatures.Queries
{
    public class GetCitiesQuery : IRequest<PagedResponse<IEnumerable<City>?>>
    {
        public string? SearchText { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, PagedResponse<IEnumerable<City>?>>
        {
            private readonly ICityRepository _cityRepository;
            private readonly IMapper _mapper;

            public GetCitiesQueryHandler(ICityRepository cityRepository, IMapper mapper)
            {
                _cityRepository = cityRepository;
                _mapper = mapper;
            }

            public async Task<PagedResponse<IEnumerable<City>?>> Handle(GetCitiesQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<City> cities = await _cityRepository.GetAllAsync();
                if (cities == null) return new PagedResponse<IEnumerable<City>?>(null, query.PageNumber, query.PageSize);
                return new PagedResponse<IEnumerable<City>?>(_mapper.Map<IEnumerable<City>>(cities), query.PageNumber, query.PageSize);
            }
        }
    }
}
