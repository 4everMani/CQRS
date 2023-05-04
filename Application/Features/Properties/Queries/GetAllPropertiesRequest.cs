using Application.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Properties.Queries
{
    public class GetAllPropertiesRequest : IRequest<List<PropertyDto>>
    {
    }

    public class GetAllPropertiesRequestHandler : IRequestHandler<GetAllPropertiesRequest, List<PropertyDto>>
    {
        private readonly IPropertyRepo _propertyRepo;

        private readonly IMapper _mapper;

        public GetAllPropertiesRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }



        public async Task<List<PropertyDto>> Handle(GetAllPropertiesRequest request, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepo.GetAllAsync();
            var propertiesDto = _mapper.Map<List<PropertyDto>>(properties);
            return propertiesDto;
        }
    }
}
