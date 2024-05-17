
using System.ComponentModel;

namespace VPG_QLKH_Organization.Enums
{
    public enum PostType
    {
        [Description("Ban điều hành")]
        BDH,
        [Description("Tổng giám đốc")]
        TGD,
        [Description("Phó tổng giám đốc")]
        PTGD,
        [Description("Giám đốc")]
        GD,
        [Description("Phó giám đốc")]
        PGD,
        [Description("Trưởng ban")]
        TB,
        [Description("Phó ban")]
        PB,
        [Description("Trưởng phòng")]
        TP,
        [Description("Phó phòng")]
        PP,
        [Description("Nhân viên")]
        NV,
    }
}
