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
    public class ImageRepo : IImageRepo
    {
        private readonly ApplicationDbContext _context;

        public ImageRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddNewAsync(Image image)
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Image image)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _context.Images
                .Include(i => i.Property)
                .ToListAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _context.Images.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Image image)
        {
            _context.Images.Update(image);
            await _context.SaveChangesAsync();
        }
    }
}
