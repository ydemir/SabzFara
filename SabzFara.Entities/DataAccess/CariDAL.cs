using SabzFara.Entities.Context;
using SabzFara.Entities.Interfaces;
using SabzFara.Entities.Repositories;
using SabzFara.Entities.Tables;
using SabzFara.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SabzFara.Entities.DataAccess
{
    public class CariDAL :EntityRepositoryBase<SabzFaraContext,Cari,CariValidator>
    {
       
    }
}
