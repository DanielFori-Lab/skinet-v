using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly TiendaContext _context;
        public ProductoRepository(TiendaContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductoBrand>> GetProductoBrandsAsync()
        {
            return await _context.ProductoBrands.ToListAsync();
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.ProductoType)
                .Include(p => p.ProductoBrand)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await _context.Productos
                .Include(p => p.ProductoType)
                .Include(p => p.ProductoBrand)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductoType>> GetProductoTypesAsync()
        {
            return await _context.ProductoTypes.ToListAsync();
        }
    }
}