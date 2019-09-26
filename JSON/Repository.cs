using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    public class Repository
    {
        private readonly string file = ConfigurationManager.AppSettings["file"];
        private List<Person> getPersonList
        {
            get
            {
                var data =  File.ReadAllText(file);
                return JsonConvert.DeserializeObject<List<Person>>(data);
            }
        }

        internal void Update(Person person)
        {
            var personList = getPersonList;
            var item = personList.FirstOrDefault(x => x.Name == person.Name);
            item.LastName = person.LastName;
            item.ListOfObjects = person.ListOfObjects;            
            serialize(personList);
        }

        internal void Delete(string name)
        {
            var personList = getPersonList;
            personList.Remove(personList.FirstOrDefault(x => x.Name == name));
            serialize(personList);
        }

        private void serialize(List<Person> people)
        {
            string dataToSave = JsonConvert.SerializeObject(people);
            File.WriteAllText(file, JToken.Parse(dataToSave).ToString());
        }
        internal void Add(Person person)
        {
            var personList = getPersonList;
            personList.Add(person);
            serialize(personList);
        }

        internal List<Person> GetList()
        {
            return getPersonList;
        }
    }
}
