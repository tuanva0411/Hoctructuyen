﻿using System;
using System.Collections.Generic;

namespace DayHocTrucTuyen.Models.Entities
{
    public partial class TinNhan
    {
        public int Id { get; set; }
        public string? NguoiGui { get; set; }
        public string? NguoiNhan { get; set; }
        public DateTime ThoiGian { get; set; }
        public string NoiDung { get; set; } = null!;
        public bool TrangThai { get; set; }

        public virtual NguoiDung? NguoiGuiNavigation { get; set; }
        public virtual NguoiDung? NguoiNhanNavigation { get; set; }

        DayHocTrucTuyenContext db = new DayHocTrucTuyenContext();

        public int setID()
        {
            var tn = db.TinNhans.OrderByDescending(x => x.Id).FirstOrDefault();
            if (tn != null) return tn.Id + 1;
            return 1;
        }
        public List<TinNhan> getTinNhanChuaXem(string maND)
        {
            var tn = db.TinNhans.Where(x => x.NguoiNhan == maND && x.TrangThai == false).ToList();

            tn = tn.OrderByDescending(x => x.ThoiGian).DistinctBy(x => x.NguoiGui).ToList();

            return tn;
        }
        public int getSLTinNhanChuaXem(string maND)
        {
            var tn = db.TinNhans.Where(x => x.NguoiNhan == maND && x.TrangThai == false).ToList();

            return tn.DistinctBy(x => x.NguoiGui).Count();
        }
        public NguoiDung getUser(string maND)
        {
            var nd = db.NguoiDungs.FirstOrDefault(x => x.MaNd == maND);
            if (nd != null)
            {
                nd.Sdt = null;
                nd.Email = "";
                nd.MatKhau = "";
            }
            return nd ?? new NguoiDung();
        }
        public List<TinNhan> getTinNhanTuUser(string nguoigui, string nguoinhan)
        {
            var tn = db.TinNhans.Where(x => x.NguoiGui == nguoigui && x.NguoiNhan == nguoinhan).OrderBy(x => x.ThoiGian);
            return tn.ToList();
        }
        public List<TinNhan> getAllTinNhan(string user1, string user2)
        {
            List<TinNhan> tinNhans = new List<TinNhan>();
            var tn1 = db.TinNhans.Where(x => x.NguoiGui == user1 && x.NguoiNhan == user2);
            var tn2 = db.TinNhans.Where(x => x.NguoiGui == user2 && x.NguoiNhan == user1);
            tinNhans.AddRange(tn1);
            tinNhans.AddRange(tn2);

            return tinNhans;
        }
    }
}
