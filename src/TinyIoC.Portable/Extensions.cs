#undef APPDOMAIN_GETASSEMBLIES

using System;
using System.Collections.Generic;

namespace TinyMessenger
{
  public static class Extensions
  {
    public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
    {
      foreach (var item in list)
        action(item);
    }

  }
}

namespace TinyIoC
{
  public static class Extensions
  {
    public static Type[] FindInterfaces(this Type type, Func<Type, object, bool> filter, object filterCriteria)
    {
      if (filter != null)
      {
        Type[] interfaces = type.GetInterfaces();
        int num = 0;
        for (int i = 0; i < (int)interfaces.Length; i++)
        {
          if (filter(interfaces[i], filterCriteria))
          {
            num++;
          }
          else
          {
            interfaces[i] = null;
          }
        }
        if (num != (int)interfaces.Length)
        {
          Type[] typeArray = new Type[num];
          num = 0;
          for (int j = 0; j < (int)interfaces.Length; j++)
          {
            if (interfaces[j] != null)
            {
              int num1 = num;
              num = num1 + 1;
              typeArray[num1] = interfaces[j];
            }
          }
          return typeArray;
        }
        else
        {
          return interfaces;
        }
      }
      else
      {
        throw new ArgumentNullException("filter");
      }
    }
  }
}
