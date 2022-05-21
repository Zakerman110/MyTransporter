﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Feedback.Core.Domain.Common
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
