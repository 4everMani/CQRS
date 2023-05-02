using Application.Repositories;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Properties.Commands
{
    public class GetPropertyRequest : IRequest<Property>
    {
        public int PropertyId { get; set; }

        public GetPropertyRequest(int propertyId)
        {
            PropertyId = propertyId;
        }
    }

    public class GetPropertyRequestHandler : IRequestHandler<GetPropertyRequest, Property>
    {
        private readonly IPropertyRepo _propertyRepo;

        public GetPropertyRequestHandler(IPropertyRepo propertyRepo)
        {
            _propertyRepo = propertyRepo;
        }

        public async Task<Property> Handle(GetPropertyRequest request, CancellationToken cancellationToken)
        {
            var propertyIndb = await _propertyRepo.GetByIdAsync(request.PropertyId);
            return propertyIndb;
        }
    }
}
