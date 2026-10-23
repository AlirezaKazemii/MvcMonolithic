using MvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithic.ApplicationServices.Services.Contracts;
using MvcMonolithic.Models.DomainModels.PersonAggregate;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.ApplicationServices.Services
{
    public class PersonApplicationService : IPersonApplicationService
    {
        #region Private Feilds
        private readonly IPersonRepository _personRepository;
        #endregion

        #region Constructor
        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region Implemention of IPersonApplicationService

        #region Delete
        public async Task Delete(DeletePersonDto deletePersonDto)
        {
            var person = await _personRepository.SelectById(deletePersonDto.Id);

            if (person == null)
                throw new NullReferenceException();

            await _personRepository.Delete(person);
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<GetPersonDto>> GetAll()
        {
            var personList = await _personRepository.SelectAll();

            if (personList is null)
                throw new NullReferenceException();

            var PersonDtoList = new List<GetPersonDto>();

            foreach(var person in personList)
            {
                var PersonDto = new GetPersonDto()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName
                };
                PersonDtoList.Add(PersonDto);
            }

            return PersonDtoList;
        }
        #endregion

        #region GetById
        public async Task<GetPersonByIdDto> GetById(Guid id)
        {
            var person = await _personRepository.SelectById(id);

            if (person is null)
                throw new NullReferenceException();

            var personDto = new GetPersonByIdDto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };
                        
            return personDto;
        }
        #endregion

        #region Post
        public async Task Post(PostPersonDto postPersonDto)
        {
            var person = new Person(postPersonDto.FirstName, postPersonDto.LastName);

            await _personRepository.Insert(person);
        }
        #endregion

        #region Put
        public async Task Put(PutPersonDto putPresonDto)
        {
            var person = await _personRepository.SelectById(putPresonDto.Id);

            if (person is null)
                throw new NullReferenceException();

            person.UpdatePerson(putPresonDto.FirstName, putPresonDto.LastName);

            await _personRepository.Update(person);
        }
        #endregion

        #endregion
    }
}   
