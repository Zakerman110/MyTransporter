using Feedback.Core.Application.Interfaces;
using Feedback.Core.Domain.Entities;
using MediatR;
using MongoDB.Driver;

namespace Feedback.Core.Application.Features.CommentFeatures.Queries
{
    public class GetAllCommentsQuery : IRequest<IEnumerable<Comment>>
    {
        public class GetAllCommentsQueyHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<Comment>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllCommentsQueyHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Comment>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
            {
                var commentList = await _context.Comments.Find(c => true).ToListAsync();
                if (commentList == null)
                {
                    return null;
                }
                return commentList.AsReadOnly();
            }
        }
    }
}
