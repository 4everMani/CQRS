using Application.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Queries
{
    public class GetAllImagesRequest : IRequest<List<ImageDto>>
    {
    }

    public class GetAllImagesRequestHandler : IRequestHandler<GetAllImagesRequest, List<ImageDto>>
    {
        private readonly IImageRepo _imageRepo;

        private readonly IMapper _mapper;

        public GetAllImagesRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }
        public async Task<List<ImageDto>> Handle(GetAllImagesRequest request, CancellationToken cancellationToken)
        {
            var images = await _imageRepo.GetAllAsync();
            return _mapper.Map<List<ImageDto>>(images);
        }
    }
}
