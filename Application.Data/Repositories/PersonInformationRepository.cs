using Application.Data.Infrastructure;
using Application.Model.Models;

namespace Application.Data.Repositories
{
    public interface IPersonInformationRepository : IRepository<PersonInformation>
    {
    }

    internal class PersonInformationRepository : RepositoryBase<PersonInformation>, IPersonInformationRepository
    {
        public PersonInformationRepository(IMongoContext context) : base(context)
        {
        }
    }
}