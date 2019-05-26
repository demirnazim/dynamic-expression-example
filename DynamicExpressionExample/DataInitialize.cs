using System.Collections.Generic;

namespace DynamicExpressionExample
{
    public class DataInitialize
    {
        public List<Person> personList;
        public DataInitialize()
        {
            personList = new List<Person>();

            personList.Add(new Person()
            {
                Id = 1,
                Name = "test name 1",
                Surname = "test surname 1",
                Swimming = true
            });

            personList.Add(new Person()
            {
                Id = 2,
                Name = "test name 2",
                Surname = "test surname 2",
                Swimming = true,
                Climbing = true
            });

            personList.Add(new Person()
            {
                Id = 2,
                Name = "test name 3",
                Surname = "test surname 3",
                Basketball = true
            });
        }
    }
}