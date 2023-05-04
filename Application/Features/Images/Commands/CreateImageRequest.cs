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

namespace Application.Features.Images.Commands
{
    public class CreateImageRequest : IRequest<bool>
    {
        public NewImage Image { get; set; }

        public CreateImageRequest(NewImage image)
        {
            Image = image;
        }

    }

    public class CreateImageRequestHandler : IRequestHandler<CreateImageRequest, bool>
    {
        private readonly IImageRepo _imagrRepo;

        private readonly IMapper _mapper;

        public CreateImageRequestHandler(IImageRepo imagrRepo, IMapper mapper)
        {
            _imagrRepo = imagrRepo;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateImageRequest request, CancellationToken cancellationToken)
        {
            var image = _mapper.Map<Image>(request.Image);
            await _imagrRepo.AddNewAsync(image);
            return true;
        }
    }
}
