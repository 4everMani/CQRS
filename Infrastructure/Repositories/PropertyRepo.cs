﻿using Application.Repositories;
using Domain;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PropertyRepo : IPropertyRepo
    {

        private readonly ApplicationDbContext _context;

        public PropertyRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNewAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Property property)
        {
            _context.Properties.Remove(property);
            await _context.SaveChangesAsync(); 
        }

        public Task<List<Property>> GetAllAsync()
        {
            return _context.Properties.ToListAsync();
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            return await _context.Properties.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Property property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }
    }
}
