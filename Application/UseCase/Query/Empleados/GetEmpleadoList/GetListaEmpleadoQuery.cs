using Application.Dto;
using Application.Utils;
using MediatR;

namespace Application.UseCase.Query.Accounts.GetAccountListByUserId
{
    public class GetListaEmpleadoQuery : IRequest<Result<IEnumerable<EmpleadoDto>>>
    {

        public GetListaEmpleadoQuery() 
        {
        }
    }
}
