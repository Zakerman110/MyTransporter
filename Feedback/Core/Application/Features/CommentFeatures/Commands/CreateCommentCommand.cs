using Feedback.Core.Application.Interfaces;
using Feedback.Core.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Feedback.Core.Application.Features.CommentFeatures.Commands
{
    public class CreateCommentCommand : IRequest<string>
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, string>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMemoryCache _memoryCache;

            public CreateCommentCommandHandler(IApplicationDbContext context, IMemoryCache memoryCache)
            {
                _context = context;
                _memoryCache = memoryCache;
            }
            public async Task<string> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = new Comment();
                comment.Name = request.Name;
                comment.Rate = request.Rate;
                comment.Description = request.Description;
                comment.CustomerId = request.CustomerId;
                comment.OrderId = request.OrderId;
                await _context.Comments.InsertOneAsync(comment);
                if (comment.Id != null)
                {
                    _memoryCache.Set(comment.Id, comment, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                        SlidingExpiration = TimeSpan.FromMinutes(2),
                        Size = 1024,
                    });
                }
                return comment.Id;
            }
        }
    }
}
