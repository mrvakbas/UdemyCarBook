using MediatR;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetAllBlogWithAuthorQuery : IRequest<List<GetAllBlogWithAuthorQueryResult>>
    {
    }
}
