using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Data;

namespace CarageMS.Model
{
    public class DBCarageMs 
    {
        public DBCarageMs() { }
        public Cars tbCars { get; set; } = new Cars(); 
       public Bills tbBills { get; set; } = new Bills();
       public Employees tbEmployees { get; set; } =new Employees();
       public Stocks tbStocks { get; set; } = new Stocks();
        
    }

    
}
