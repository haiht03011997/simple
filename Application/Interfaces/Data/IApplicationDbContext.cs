﻿using Domain.AggregateRoot.Organizations.Entities.Positions;
using Domain.AggregateRoot.Organizations.Entities.StaffPositions;
using Domain.Entities.Organizations;
using Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Organization> Organizations { get; set; }
        DbSet<Staff> Staffs { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<StaffPosition> StaffPositions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
