using Library.Application.ViewModels;
using MediatR;

namespace Library.Application.Features.DigitalEntities.Commands.UpdateDigitalEntity
{
    public class UpdateDigitalEntityCommand : IRequest<int>
    {
        public DigitalEntityDto DigitalEntityDto { get; set; }
    }
}
