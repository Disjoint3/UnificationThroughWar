using System;
using System.ComponentModel;

/// <summary>
/// 类拓展
/// </summary>
public static class Extends
{
    /// <summary>
    /// 拓展枚举类型，实现“键值对效果”
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    public static string GetValue<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        var type = typeof(TEnum);
        var field = type.GetField(enumValue.ToString());
        if (field != null)
        {
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }
        }

        return enumValue.ToString();
    }
}
