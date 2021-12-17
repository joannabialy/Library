using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.DigitalEntities.Commands.DeleteDigitalEntity
{
    public class DeleteDigitalEntityCommandHandler : IRequestHandler<DeleteDigitalEntityCommand, int>
    {
        public IAsyncDomainRepository<DigitalEntity> _digitalEntitiesRepository;

        public DeleteDigitalEntityCommandHandler(IAsyncDomainRepository<DigitalEntity> digitalEntitiesRepository)
        {
            _digitalEntitiesRepository = digitalEntitiesRepository;
        }

        public async Task<int> Handle(DeleteDigitalEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _digitalEntitiesRepository.GetByIdAsync(request.Id);

            if (entity != null)
                await _digitalEntitiesRepository.DeleteAsync(entity);

            return entity.DigitalEntityId;
        }
    }
}
