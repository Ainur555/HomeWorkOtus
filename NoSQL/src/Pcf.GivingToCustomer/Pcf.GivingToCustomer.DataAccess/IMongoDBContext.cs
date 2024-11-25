using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Pcf.GivingToCustomer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pcf.GivingToCustomer.DataAccess
{
    public interface IMongoDBContext<T>
    {

        IMongoCollection<T> GetCollection<T>(string name);
    }     

}
