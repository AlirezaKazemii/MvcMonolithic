namespace MvcMonolithic.Models.DomainModels.PersonAggregate
{
    public class Person
    {
        public Person()
        {
            
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        public void UpdatePerson(string  firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
