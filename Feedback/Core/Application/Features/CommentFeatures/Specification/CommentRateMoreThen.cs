using Feedback.Core.Application.Features;
using Feedback.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Core.Application.Features.CommentFeatures.Specification
{
    public class CommentRateMoreThen : BaseSpecification<Comment>
    {
        public CommentRateMoreThen(decimal rate) : base(x => x.Rate > rate)
        {

        }
    }
}
