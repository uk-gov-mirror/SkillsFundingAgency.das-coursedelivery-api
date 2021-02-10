﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SFA.DAS.CourseDelivery.Domain.Entities;
using SFA.DAS.CourseDelivery.Domain.Interfaces;

namespace SFA.DAS.CourseDelivery.Data.Repository
{
    public class ShortlistRepository : IShortlistRepository
    {
        private readonly ILogger<ShortlistRepository> _logger;
        private readonly ICourseDeliveryDataContext _dataContext;
        private readonly ICourseDeliveryReadonlyDataContext _readonlyDataContext;

        public ShortlistRepository(
            ILogger<ShortlistRepository> logger,
            ICourseDeliveryDataContext dataContext, 
            ICourseDeliveryReadonlyDataContext readonlyDataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
            _readonlyDataContext = readonlyDataContext;
        }

        public async Task<IEnumerable<Shortlist>> GetAllForUser(Guid userId)
        {
            return await _readonlyDataContext.Shortlists
                .Where(shortlist => shortlist.ShortlistUserId == userId)
                .ToListAsync();
        }

        public async Task<Shortlist> GetShortlistUserItem(Shortlist item)
        {
            return await _readonlyDataContext.Shortlists.SingleOrDefaultAsync(c=>
                c.ShortlistUserId.Equals(item.ShortlistUserId)
                && c.CourseId.Equals(item.CourseId)
                && c.ProviderUkprn.Equals(item.ProviderUkprn)
                && c.Lat.Equals(item.Lat)
                && c.Long.Equals(item.Long)
                );
        }

        public async Task Insert(Shortlist item)
        {
            try
            {
                await _dataContext.Shortlists.AddAsync(item);
                _dataContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                _logger.LogInformation(e, "Unable to add shortlist item");
            }
        }
    }
}