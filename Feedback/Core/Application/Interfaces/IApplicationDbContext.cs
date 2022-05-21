﻿using Feedback.Core.Domain.Entities;
using MongoDB.Driver;

namespace Feedback.Core.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        IMongoCollection<Comment> Comments { get; set; }
    }
}
