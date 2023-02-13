using RestWithAPSNETUdemy.Model;

namespace RestWithAPSNETUdemy.Service.Implamentations
{
    public class PersonServiceImplementation : IPersonService//ai é a implementação do service em que eu tipei colocando o IPersonService, ai eu começo a realmente fazer as funções, são elas iram se comunicar com o meu banco pra fazer o put, post, get...
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person()
            {
                id = IncrementAndGet(),
                FirstName = "Person Name" + 1,
                LastName = "Person LastName" + 1,
                Address = "Some Address" + 1,
                Gender = "Masculino"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                id = IncrementAndGet(),
                FirstName = "Leonardo",
                LastName = "Lisboa",
                Address = "Aracaju, Sergipe",
                Gender = "Masculino"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
