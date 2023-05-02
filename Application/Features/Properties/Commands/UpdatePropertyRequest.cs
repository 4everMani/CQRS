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

namespace Application.Features.Properties.Commands
{
    public class UpdatePropertyRequest : IRequest<bool>
    {
        public UpdateProperty UpdateProperty { get; set; }

        public UpdatePropertyRequest(UpdateProperty updateProperty)
        {
            this.UpdateProperty = updateProperty;
        }
    }

    public class UpdatePropertyRequestHandler : IRequestHandler<UpdatePropertyRequest, bool>
    {
        private readonly IPropertyRepo _propertyRepo;

        private readonly IMapper _mapper;

        public UpdatePropertyRequestHandler(IPropertyRepo propertyRepo, IMapper mapper)
        {
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdatePropertyRequest request, CancellationToken cancellationToken)
        {
            // check if property is exists in db
            Property propertyInDb = await _propertyRepo.GetByIdAsync(request.UpdateProperty.Id);
            if (propertyInDb == null) return false;

            // update property
            //var property = _mapper.Map<Property>(request.UpdateProperty, propertyInDb);
            propertyInDb = _mapper.Map(request.UpdateProperty, propertyInDb);
            await _propertyRepo.UpdateAsync(propertyInDb);
            return true;

        }
    }
}
