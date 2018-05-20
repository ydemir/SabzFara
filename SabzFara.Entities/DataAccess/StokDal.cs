using SabzFara.Entities.Context;
using SabzFara.Entities.Repositories;
using SabzFara.Entities.Tables;
using SabzFara.Entities.Validations;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace SabzFara.Entities.DataAccess
{
    public class StokDAL:EntityRepositoryBase<SabzFaraContext,Stok,StokValidator>
    {
        
    }
}
