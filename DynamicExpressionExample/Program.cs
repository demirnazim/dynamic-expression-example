using System;
using System.Linq;
using System.Linq.Expressions;

namespace DynamicExpressionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DataInitialize dataInitialize = new DataInitialize();
            var personList = dataInitialize.personList;

            Filter filter = new Filter() { Swimming = true };

            var filterList = filter.GetType().GetProperties()
                                   .Select(prop =>
                                   new
                                   {
                                       name = prop.Name,
                                       value = prop.GetValue(filter, null)
                                   }).Where(x => x.value != null).ToList();

            BinaryExpression binaryExpression = null;
            var parameter = Expression.Parameter(typeof(Person));
            Expression defaultExpression = Expression.Constant(true);

            filterList.ForEach(item =>
            {
                binaryExpression = Expression.AndAlso(binaryExpression == null ? defaultExpression : binaryExpression, Expression.Equal
                                                   (
                                                       Expression.PropertyOrField(parameter, item.name),
                                                       Expression.Constant(item.value)
                                                   ));
            });

            var finalExpression = Expression.Lambda<Func<Person, bool>>(binaryExpression, parameter);
            var result = personList.AsQueryable().Where(finalExpression).ToList();

            foreach (var person in result)
            {
                Console.WriteLine(string.Format("Name: {0}", person.Name));
                Console.WriteLine(string.Format("Surname: {0}", person.Surname));
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - -");
            }

            Console.ReadLine();
        }
    }
}