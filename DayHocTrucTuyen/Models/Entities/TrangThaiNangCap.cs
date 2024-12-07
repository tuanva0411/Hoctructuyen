﻿using System;
using System.Collections.Generic;

namespace DayHocTrucTuyen.Models.Entities
{
    public partial class TrangThaiNangCap
    {
        public string MaNd { get; set; } = null!;
        public int? MaGoi { get; set; }
        public DateTime NgayDangKy { get; set; }

        public virtual GoiNangCap? MaGoiNavigation { get; set; }
        public virtual NguoiDung MaNdNavigation { get; set; } = null!;
    }
}
