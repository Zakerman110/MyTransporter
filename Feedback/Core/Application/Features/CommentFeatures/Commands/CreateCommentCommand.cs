using Feedback.Core.Application.Interfaces;
using Feedback.Core.Domain.Entities;
using MediatR;

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

            public CreateCommentCommandHandler(IApplicationDbContext context)
            {
                _context = context;
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
                return comment.Id;
            }
        }
    }
}
