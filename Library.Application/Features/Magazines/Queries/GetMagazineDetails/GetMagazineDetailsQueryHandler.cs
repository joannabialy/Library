using AutoMapper;
using Library.Application.Contracts.Repositories;
using Library.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Features.Magazines.Queries.GetMagazineDetails
{
    public class GetMagazineDetailsQueryHandler : IRequestHandler<GetMagazineDetailsQuery, Magazine>
    {
        private readonly IMagazinesRepository _magazineRepository;

        public GetMagazineDetailsQueryHandler(IMagazinesRepository magazineRepository)
        {
            _magazineRepository = magazineRepository;
        }

        public async Task<Magazine> Handle(GetMagazineDetailsQuery request, CancellationToken cancellationToken)
        {
            var magazine = await _magazineRepository.GetMagazine(request.Id);

            return magazine;
        }
    }
}