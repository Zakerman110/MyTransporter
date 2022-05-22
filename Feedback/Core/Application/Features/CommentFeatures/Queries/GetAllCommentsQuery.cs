using Feedback.Core.Application.Interfaces;
using Feedback.Core.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Driver;

namespace Feedback.Core.Application.Features.CommentFeatures.Queries
{
    public class GetAllCommentsQuery : IRequest<IEnumerable<Comment>>
    {
        public class GetAllCommentsQueyHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<Comment>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMemoryCache _memoryCache;

            public GetAllCommentsQueyHandler(IApplicationDbContext context, IMemoryCache memoryCache)
            {
                _context = context;
                _memoryCache = memoryCache;
            }

            public async Task<IEnumerable<Comment>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
            {
                var cacheKey = "commentsList";
                List<Comment> commentList = null;
                if(!_memoryCache.TryGetValue(cacheKey, out commentList))
                {
                    commentList = await _context.Comments.Find(c => true).ToListAsync();
                    _memoryCache.Set(cacheKey, commentList, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                        Priority = CacheItemPriority.High,
                        SlidingExpiration = TimeSpan.FromMinutes(2)
                    });

                }
                if (commentList == null)
                {
                    return null;
                }
                return commentList.AsReadOnly();
            }
        }
    }
}
