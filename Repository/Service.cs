using Contract;
using Data;
using Models;
using System;

namespace Repository
{
    public class Service : IService
    {
        private readonly AppDbContext _context;
        public Service(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TShirt> GetAll()
        {
            var items = _context.TShirts.ToList();
            return items;
        }

        public TShirt GetById(Guid cId) => _context.TShirts.FirstOrDefault(n => n.Id == cId);
    }
}