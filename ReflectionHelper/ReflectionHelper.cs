using HarmonyLib;
using System.Reflection;

namespace ReflectionHelper
{
    public static class ReflectionHelper
    {

        public static T QuickGetProperty<T>(this object obj, string field)
        {
            return (T)AccessTools.Field(obj.GetType(), field).GetValue(obj);
        }
        public static void QuickSetProperty<T>(this object obj, string field, T value)
        {
            AccessTools.Field(obj.GetType(), field).SetValue(obj, value);
        }
        public static T QuickGetField<T>(this object obj, string field)
        {
            return (T)AccessTools.Field(obj.GetType(), field).GetValue(obj);
        }
        public static void QuickSetField<T>(this object obj, string field, T value)
        {
            AccessTools.Field(obj.GetType(), field).SetValue(obj, value);
        }
        public static T QuickCall<T>(this object obj, string method, object[] args = null)
        {
            return (T)AccessTools.Method(obj.GetType(), method).Invoke(obj, args);
        }
        public static void QuickCall(this object obj, string method, object[] args = null)
        {
            AccessTools.Method(obj.GetType(), method).Invoke(obj, args);
        }
        public static T QuickDelegate<T>(this object obj, string method) where T : System.Delegate
        {
            return AccessTools.Method(obj.GetType(), method).CreateDelegate(typeof(T), obj) as T;
        }
        public static MethodInfo GetMethodInfo<T>(T a) where T:System.Delegate
        {
            return a.GetMethodInfo();
        }
    }
}