using Feedback.Core.Application.Interfaces;
using Feedback.Core.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;

namespace Feedback.Core.Application.Features.CommentFeatures.Queries
{
    public class GetCommentByIdQuery : IRequest<Comment>
    {
        public string Id { get; set; }
        public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMemoryCache _memoryCache;

            public GetCommentByIdQueryHandler(IApplicationDbContext context, IMemoryCache memoryCache)
            {
                _context = context;
                _memoryCache = memoryCache;
            }
            public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
            {
                Comment comment = null;
                if (!_memoryCache.TryGetValue(request.Id, out comment))
                {
                    comment = await _context.Comments.Find(c => c.Id == request.Id).FirstOrDefaultAsync();
                    if (comment != null)
                    {
                        _memoryCache.Set(comment.Id, comment, new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                            SlidingExpiration = TimeSpan.FromMinutes(2),
                            Size = 1024,
                        });
                    }
                }
                if (comment == null) return null;
                return comment;
            }
        }
    }
}
