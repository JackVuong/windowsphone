using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoney
{
    public class DatabaseUpdate
    {
        QLChiTieuContext context = new QLChiTieuContext(QLChiTieuContext.ConnectionString);
        public void UpdateGiaoDich(int id, GiaoDich gd)
        {
            IQueryable<GiaoDich> entityQuery = from c in context.GiaoDich where c.Id == id select c;
            GiaoDich entityToUpdate = entityQuery.FirstOrDefault();
            entityToUpdate.TenGD = gd.TenGD;
            entityToUpdate.SoTien = gd.SoTien;
            entityToUpdate.GhiChu = gd.GhiChu;
            entityToUpdate.Hinh = gd.Hinh;
            entityToUpdate.TenTaiKhoan = gd.TenTaiKhoan;
            entityToUpdate.TienConLai = gd.TienConLai;
            entityToUpdate.NgayGD = gd.NgayGD;
            context.SubmitChanges();
        }
    }
}
