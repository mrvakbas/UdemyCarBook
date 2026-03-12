using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogWithAuthorQueryHandler : IRequestHandler<GetAllBlogWithAuthorQuery, List<GetAllBlogWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogWithAuthorQueryResult>> Handle(GetAllBlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogWithAuthorQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                AuthorName = x.Author.Name,
                Description = x.Description,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl,
            }).ToList();
        }
    }
}