using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Commands
{
    public class DeleteImageRequest : IRequest<bool>
    {
        public int ImageId { get; set; }

        public DeleteImageRequest(int imageId)
        {
            ImageId = imageId;
        }
    }

    public class DeleteImageRequestHandler : IRequestHandler<DeleteImageRequest, bool>
    {
        private readonly IImageRepo _imageRepo;


        public DeleteImageRequestHandler(IImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }

        public async Task<bool> Handle(DeleteImageRequest request, CancellationToken cancellationToken)
        {
            var image = await _imageRepo.GetByIdAsync(request.ImageId);
            if(image == null)
            {
                return false;
            }
            await _imageRepo.DeleteAsync(image);
            return true;
        }
    }
}
