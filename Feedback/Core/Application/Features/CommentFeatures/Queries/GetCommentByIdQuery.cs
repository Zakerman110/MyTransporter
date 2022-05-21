using Feedback.Core.Application.Interfaces;
using Feedback.Core.Domain.Entities;
using MediatR;
using MongoDB.Driver;

namespace Feedback.Core.Application.Features.CommentFeatures.Queries
{
    public class GetCommentByIdQuery : IRequest<Comment>
    {
        public string Id { get; set; }
        public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
        {
            private readonly IApplicationDbContext _context;

            public GetCommentByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
            {
                var comment = await _context.Comments.Find(c => c.Id == request.Id).FirstOrDefaultAsync();
                if (comment == null) return null;
                return comment;
            }
        }
    }
}
