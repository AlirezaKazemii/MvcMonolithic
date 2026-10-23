using MvcMonolithic.Models.DomainModels.PersonAggregate;

namespace MvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {
        #region Insert
        Task Insert(Person person);
        #endregion

        #region SelectAll
        Task<IEnumerable<Person>> SelectAll(); // ?
        #endregion

        #region SelectById
        Task<Person?> SelectById(Guid id);
        #endregion

        #region Delete
        Task Delete(Person person);
        #endregion

        #region Update
        Task Update(Person person);
        #endregion
    }
}
