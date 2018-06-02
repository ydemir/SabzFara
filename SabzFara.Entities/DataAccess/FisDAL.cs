using SabzFara.Entities.Context;
using SabzFara.Entities.Repositories;
using SabzFara.Entities.Tables;
using SabzFara.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzFara.Entities.DataAccess
{
    public class FisDAL : EntityRepositoryBase<NetSatisContext, Fis,FisValidator>
    {
    }
}
