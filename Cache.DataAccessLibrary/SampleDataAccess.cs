using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache.DataAccessLibrary
{
    public class SampleDataAccess
    {
        private IMemoryCache _memoryCache;
        public SampleDataAccess(IMemoryCache memoryCache) {
            _memoryCache = memoryCache;
        }
        public List<EmployeeData> GetEmployees() { 
        
            List<EmployeeData> output = new();
            output.Add(new() { FirstName = "Puja", LastName = "Panchal" });
            output.Add(new() { FirstName = "Mayank", LastName = "Panchal" });
            output.Add(new() { FirstName = "Poonam", LastName = "Panchal-Gupta" });
            output.Add(new() { FirstName = "Sanjay", LastName = "Gupta" });

            Thread.Sleep(3000);

            return output;
        }

        /// <summary>
        /// Async call
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeData>> GetEmployeesAsync()
        {

            List<EmployeeData> output = new();
            output.Add(new() { FirstName = "Puja", LastName = "Panchal" });
            output.Add(new() { FirstName = "Mayank", LastName = "Panchal" });
            output.Add(new() { FirstName = "Poonam", LastName = "Panchal-Gupta" });
            output.Add(new() { FirstName = "Sanjay", LastName = "Gupta" });
            await Task.Delay(3000);

            return output;
        }
        /// <summary>
        /// Async Call and keeping In Memory cache
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmployeeData>> GetEmployeesAsyncCache()
        {
            List<EmployeeData> output;
            output = _memoryCache.Get<List<EmployeeData>>("Employees");
            if (output is null)
            {
                output = new();
                output.Add(new() { FirstName = "Puja", LastName = "Panchal" });
                output.Add(new() { FirstName = "Mayank", LastName = "Panchal" });
                output.Add(new() { FirstName = "Poonam", LastName = "Panchal-Gupta" });
                output.Add(new() { FirstName = "Sanjay", LastName = "Gupta" });
                await Task.Delay(3000);

                _memoryCache.Set("Employees", output, TimeSpan.FromMinutes(1));
            }


            

            return output;
        }
    }
}
