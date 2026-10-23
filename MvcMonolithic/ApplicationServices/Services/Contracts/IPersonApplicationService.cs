using MvcMonolithic.ApplicationServices.Dtos.PersonDtos;

namespace MvcMonolithic.ApplicationServices.Services.Contracts
{
    public interface IPersonApplicationService
    {
        #region Post
        Task Post(PostPersonDto postPersonDto);
        #endregion

        #region GetAll
        Task<IEnumerable<GetPersonDto>> GetAll();
        #endregion

        #region GetById
        Task<GetPersonByIdDto> GetById(Guid id);
        #endregion

        #region Delete
        Task Delete(DeletePersonDto deletePersonDto);
        #endregion

        #region Put
        Task Put(PutPersonDto putPresonDto);
        #endregion

    }
}
