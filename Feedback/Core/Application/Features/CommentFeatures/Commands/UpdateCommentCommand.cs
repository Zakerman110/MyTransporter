using Feedback.Core.Application.Interfaces;
using Feedback.Core.Domain.Entities;
using MediatR;
using MongoDB.Driver;

namespace Feedback.Core.Application.Features.CommentFeatures.Commands
{
    public class UpdateCommentCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, string>
        {
            private readonly IApplicationDbContext _context;

            public UpdateCommentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = new Comment();
                comment.Id = request.Id;
                comment.Name = request.Name;
                comment.Rate = request.Rate;
                comment.Description = request.Description;
                comment.CustomerId = request.CustomerId;
                comment.OrderId = request.OrderId;
                await _context.Comments.ReplaceOneAsync(c => c.Id == request.Id, comment);
                return request.Id;
            }
        }
    }
}
