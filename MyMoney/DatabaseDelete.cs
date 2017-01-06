using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney
{
    public class DatabaseDelete
    {
        QLChiTieuContext context = new QLChiTieuContext(QLChiTieuContext.ConnectionString);
        public void DelGiaoDich(int id)
        {
            using (context)
            {
                //if (!context.DatabaseExists())
                //    context.CreateDatabase();
                IQueryable<GiaoDich> entityQuery = from c in context.GiaoDich where c.Id.Equals(id) select c;
                GiaoDich entityToDelete = entityQuery.FirstOrDefault();
                context.GiaoDich.DeleteOnSubmit(entityToDelete);
                context.SubmitChanges();
                //context.SubmitChanges();
            }
        }
    }
}
