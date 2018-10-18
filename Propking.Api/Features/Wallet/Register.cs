using MediatR;
using Propking.Api.Models;

namespace Propking.Api.Features.Position
{
    public class Register
    {
        public class Command : IRequest<int>
        {
            PositionChange.PositionChangeType ChangeType { get; set; }
            public string Code { get; set; }
        }
    }
}
