using System;
using System.Reflection;
using ReflectionPerformance.External;

namespace ReflectionPerformance
{

    public static class ReflectionUsage
    {

        public static string SingleGet()
        {
            var someClass = new VeryPublicClass();
            return someClass.VeryPublicProperty;
        }

        public static string TraditionalReflection()
        {
            var someClass = new VeryPublicClass();

            var propertyInfo = someClass.GetType()
                .GetProperty("VeryPrivateProperty", BindingFlags.Instance | BindingFlags.NonPublic);
            var value = propertyInfo!.GetValue(someClass);
            return value!.ToString();
        }

        private static readonly PropertyInfo CachedProperty = typeof(VeryPublicClass)
            .GetProperty("VeryPrivateProperty", BindingFlags.Instance | BindingFlags.NonPublic);

        public static string OptimizedTraditionalReflection()
        {
            var someClass = new VeryPublicClass();

            var value = CachedProperty!.GetValue(someClass);
            return value!.ToString();
        }

        private static readonly Func<VeryPublicClass, string> GetPropertyDelegate =
            (Func<VeryPublicClass, string>) Delegate.CreateDelegate(typeof(Func<VeryPublicClass, string>),
                CachedProperty.GetGetMethod(true)!);

        public static string CompiledDelegate()
        {
            var someClass = new VeryPublicClass();

            return GetPropertyDelegate(someClass);
        }
    }
}
