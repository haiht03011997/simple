using System.ComponentModel;

namespace Domain.Enumerations
{
    public enum CategoryOrganization
    {
        [Description("Tập đoàn")]
        Corporate,
        [Description("Công ty đầu ngành")]
        HeadCompany,
        [Description("Công ty")]
        Company,
        [Description("Khối")]
        Division,
        [Description("Ban")]
        Department,
        [Description("Phòng")]
        Section
    }
}
