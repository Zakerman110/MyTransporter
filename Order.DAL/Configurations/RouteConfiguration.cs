using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.DAL.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.Property(team => team.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.HasOne(r => r.StartPoint)
                   .WithMany(c => c.StartPoints)
                   .HasForeignKey(r => r.StartPoint)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(r => r.EndPoint)
                   .WithMany(c => c.EndPoints)
                   .HasForeignKey(r => r.EndPoint)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
