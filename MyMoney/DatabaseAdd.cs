using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney
{
    public class DatabaseAdd
    {
        QLChiTieuContext context = new QLChiTieuContext(QLChiTieuContext.ConnectionString);
        public void AddGiaoDich(GiaoDich gd)
        {
            using (context)
            {
                //if (!context.DatabaseExists())
                //    context.CreateDatabase();
                context.GiaoDich.InsertOnSubmit(gd);
                context.SubmitChanges();
            }
        }

        //public void AddTaiKhoan(TaiKhoan tk)
        //{
             
        //    using (context)
        //    {
        //        /*if (!context.DatabaseExists())
        //            context.CreateDatabase();*/
        //        context.TaiKhoan.InsertOnSubmit(tk);
        //        context.SubmitChanges();
        //    }
        //}
    }
}
