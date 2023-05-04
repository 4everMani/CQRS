using Application.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Images.Queries
{
    public class GetImageRequest : IRequest<ImageDto>
    {
        public int ImageId { get; set; }

        public GetImageRequest(int imageId)
        {
            ImageId = imageId;
        }
    }

    public class GetImageRequestHandler : IRequestHandler<GetImageRequest, ImageDto>
    {
        private readonly IImageRepo _imageRepo;

        private readonly IMapper _mapper;

        public GetImageRequestHandler(IImageRepo imageRepo, IMapper mapper)
        {
            _imageRepo = imageRepo;
            _mapper = mapper;
        }
        public async Task<ImageDto> Handle(GetImageRequest request, CancellationToken cancellationToken)
        {
            var image = await _imageRepo.GetByIdAsync(request.ImageId);
            return _mapper.Map<ImageDto>(image);
        }
    }

}
