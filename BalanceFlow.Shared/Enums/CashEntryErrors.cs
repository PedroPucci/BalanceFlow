using System.ComponentModel;

namespace BalanceFlow.Shared.Enums
{
    public enum CasyEntryErrors
    {
        [Description("'Description' can not be null or empty!")]
        CasyEntry_Error_DescriptionCanNotBeNullOrEmpty,

        [Description("'Description' can not be less 4 letters!")]
        CasyEntry_Error_DescriptionLenghtLessFour
    }
}