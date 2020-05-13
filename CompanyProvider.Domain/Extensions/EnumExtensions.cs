using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CompanyProvider.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum e)
        {
            Type type = e.GetType();
            MemberInfo[] memberInfo = type.GetMember(e.ToString());

            if ((memberInfo != null && memberInfo.Length > 0))
            {
                List<object> attributes = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false).ToList();
                if ((attributes != null && attributes.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)attributes.ElementAt(0)).Description;
                }
            }

            return e.ToString();
        }
    }
}
