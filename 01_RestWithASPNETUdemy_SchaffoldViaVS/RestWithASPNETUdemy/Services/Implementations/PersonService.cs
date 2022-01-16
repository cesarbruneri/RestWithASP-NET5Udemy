using RestWithASPNETUdemy.IServices;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Services
{
    public class PersonService : IPersonSerevice
    {
        private SqlContext _sqlContext;

        public PersonService(SqlContext context)
        {
            _sqlContext = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _sqlContext.Add(person);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _sqlContext.Persons
                .FirstOrDefault(x => x.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _sqlContext.Persons.Remove(result);
                    _sqlContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public List<Person> FindAll()
        {
            return _sqlContext.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _sqlContext.Persons.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();
            var result = _sqlContext.Persons
                .FirstOrDefault(x => x.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _sqlContext.Entry(result).CurrentValues.SetValues(person);
                    _sqlContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return person;
        }

        private bool Exists(long id)
        {
            return _sqlContext.Persons.Any(x => x.Id.Equals(id));
        }
    }
}
