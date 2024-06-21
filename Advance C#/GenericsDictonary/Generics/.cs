using Generics.Controllers;
using Generics.IService;
using Generics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace Generics
{
    public class MyDependencyResolver : IDependencyResolver
    {
        private readonly IGenericService<Stu01> _studentService;

        public MyDependencyResolver(IGenericService<Stu01> studentService)
        {
            _studentService = studentService;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            
        }

        public object GetService(Type serviceType)
        {
            // Return the appropriate service instances based on serviceType
            if (serviceType == typeof(StudentController))
            {
                return new StudentController(_studentService);
            }

            // Handle other services...

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            // Implement if needed
            return Enumerable.Empty<object>();
        }
    }

}