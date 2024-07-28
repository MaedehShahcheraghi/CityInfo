using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            people.Add(new Person()
            {
                Name = "maedeh",
                PhoneNumbers = new List<PhoneNumber>()
                {
                    new PhoneNumber()
                    {
                        Number="0985524"
                    },
                    new PhoneNumber(){
                            Number="09558858"
                    }
                }


            }); ;

            people.Add(new Person()
            {
                Name = "zahra",
                PhoneNumbers = new List<PhoneNumber>()
                {
                    new PhoneNumber()
                    {
                        Number="0985524"
                    },
                    new PhoneNumber(){
                            Number="09558858"
                    }
                }


            }); ;
            people.Add(new Person()
            {
                Name = "amir",
                PhoneNumbers = new List<PhoneNumber>()
                {
                    new PhoneNumber()
                    {
                        Number="0985524"
                    },
                    new PhoneNumber(){
                            Number="09558858"
                    }
                }


            }); ;
            var result1 = people.SelectMany(p => p.PhoneNumbers).ToList();

        }
    }
    public class PhoneNumber
    {
        public string Number { get; set; }
    }

    public class Person
    {
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }=new List<PhoneNumber>();
        public string Name { get; set; }
    }

   
}
