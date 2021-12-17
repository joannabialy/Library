using Library.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Library.Application.Features.DigitalEntities.Queries.GetDigitalEntitiesList
{
    public class GetDigitalEntitiesListQuery : IRequest<List<DigitalEntitiesListVM>>
    {
    }
}
