using Library.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Magazines.Commands.DeleteMagazine
{
    public class DeleteMagazineCommandHandler : IRequestHandler<DeleteMagazineCommand, int>
    {
        private readonly IMagazinesRepository _magazinesRepository;

        public DeleteMagazineCommandHandler(IMagazinesRepository magazinesRepository)
        {
            _magazinesRepository = magazinesRepository;
        }

        public async Task<int> Handle(DeleteMagazineCommand request, CancellationToken cancellationToken)
        {
            var magazine = await _magazinesRepository.GetByIdAsync(request.Id);

            if (magazine != null)
                await _magazinesRepository.DeleteAsync(magazine);

            return magazine.DigitalEntityId;
        }
    }
}
