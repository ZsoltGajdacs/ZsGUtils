using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZsGUtilsTest.EnumUtils
{
    internal enum TestEnum
    {
        [Description("Something boring")]
        [Display(Name = "Something")]
        SOMETHING,

        [Display(Name = "Whatever")]
        WHATEVER,

        [Description("Dunno what is this")]
        DUNNO,

        [Description("")]
        [Display(Name = "")]
        EMPTY,

        ANYTHING
    }
}
