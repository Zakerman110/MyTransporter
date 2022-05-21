using Feedback.Core.Application.Interfaces;
using MediatR;
using MongoDB.Driver;

namespace Feedback.Core.Application.Features.CommentFeatures.Commands
{
    public class DeleteCommentByIdCommand : IRequest<string>
    {
        public string Id { get; set; }
        public class DeleteCommentByIdCommandHandler : IRequestHandler<DeleteCommentByIdCommand, string>
        {
            private readonly IApplicationDbContext _context;

            public DeleteCommentByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
            {
                await _context.Comments.DeleteOneAsync(c => c.Id == request.Id);
                return request.Id;
            }
        }
    }
}
