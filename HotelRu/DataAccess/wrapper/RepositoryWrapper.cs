using Domian.Models;
using DataAccess.Repositories;
using Domian.Interfaces;

namespace DataAccess.Wrapper
{

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private HotelRusBookingContext _repoContext;
        private IUserRepository _user; 

        public RepositoryWrapper(HotelRusBookingContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }


        public void Save()
        {
            _repoContext.SaveChanges();
        }

    }
}