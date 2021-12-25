using Application.Data.Repositories;
using Application.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Services
{
    public interface IPersonInformationService
    {
        Task<IEnumerable<PersonInformation>> GetAll();
        Task<IEnumerable<PersonInformation>> GetAll(string keyword);
    }
    internal class PersonInformationService : IPersonInformationService
    {
        private readonly IPersonInformationRepository _personInformationRepository;
        public PersonInformationService(IPersonInformationRepository personInformationRepository)
        {
            _personInformationRepository = personInformationRepository;
        }

        public Task<IEnumerable<PersonInformation>> GetAll()
        {
            return _personInformationRepository.GetAll();
        }

        public async Task<IEnumerable<PersonInformation>> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return await _personInformationRepository.GetAll(x=>x.)
            } 
        }
    }
}
