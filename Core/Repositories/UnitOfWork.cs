using asp_code_base.Core.Contracts;
using asp_code_base.Models;
using AutoMapper;

namespace asp_code_base.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public IUserRepo User { get; private set; }

        public UnitOfWork(DataContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;

            User = new UserRepo(context, _configuration);
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
