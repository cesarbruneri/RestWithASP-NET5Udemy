using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.IServices
{
    public interface IPersonSerevice
    {
        Person Create(Person person);

        Person FindById(long id);

        List<Person> FindAll();
        Person Update(Person person);

        void Delete(long id);
    }
}
