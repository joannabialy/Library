using MediatR;

namespace Library.Application.Features.DigitalEntities.Commands.DeleteDigitalEntity
{
    public class DeleteDigitalEntityCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
