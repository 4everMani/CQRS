using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Properties.Queries
{
    public class GetPropertyRequest : IRequest<PropertyDto>
    {
        public int PropertyId { get; set; }

        public GetPropertyRequest(int propertyId)
        {
            PropertyId = propertyId;
        }
    }

    public class GetPropertyRequestHandler : IRequestHandler<GetPropertyRequest, PropertyDto>
    {
        private readonly IPropertyRepo _propertyRepo;

        private readonly IMapper _mapper;

        public GetPropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<PropertyDto> Handle(GetPropertyRequest request, CancellationToken cancellationToken)
        {
            var propertyIndb = await _propertyRepo.GetByIdAsync(request.PropertyId);
            var propertyDto = _mapper.Map<PropertyDto>(propertyIndb);
            return propertyDto;
        }
    }
}
