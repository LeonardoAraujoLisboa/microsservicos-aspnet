using RestWithAPSNETUdemy.Model;

namespace RestWithAPSNETUdemy.Service.Implamentations
{
    public interface IPersonService //Ai é uma interface para o meu service mesmo, to tipando o service (ou uma assinatura do service), dizendo quais sao os métodos
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
