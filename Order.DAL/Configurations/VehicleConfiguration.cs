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
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(vehicle => vehicle.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(vehicle => vehicle.ExternalId)
                   .IsRequired();

            builder.Property(vehicle => vehicle.Plate)
                   .HasMaxLength(10);

            builder.Property(vehicle => vehicle.Color)
                   .HasMaxLength(50);

            builder.Property(vehicle => vehicle.Model)
                   .HasMaxLength(50);

            builder.Property(vehicle => vehicle.Make)
                   .HasMaxLength(50);

        }
    }
}
