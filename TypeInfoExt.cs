using System.Reflection;

namespace VType
{
	/// <summary>
	/// Provides informational extension methods for the <see cref="Type"/> class.
	/// </summary>
	public static class TypeInfoExt
	{
		/// <summary>
		/// Gets all members of the <paramref name="type"/>.
		/// </summary>
		/// <param name="type">The <see cref="Type"/> object to search through.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static MemberInfo[] GetAllMembers(this Type type) => type is null ? Array.Empty<MemberInfo>()! : type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.IgnoreReturn | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.CreateInstance | BindingFlags.Default | BindingFlags.DeclaredOnly | BindingFlags.DoNotWrapExceptions | BindingFlags.ExactBinding | BindingFlags.FlattenHierarchy | BindingFlags.GetField | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.OptionalParamBinding | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.SetField | BindingFlags.SuppressChangeType)!;
		/// <inheritdoc cref="GetAllMembers(Type)" />
		public static FieldInfo[] GetAllFields(this Type type) => type is null ? Array.Empty<FieldInfo>()! : type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.IgnoreReturn | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.CreateInstance | BindingFlags.Default | BindingFlags.DeclaredOnly | BindingFlags.DoNotWrapExceptions | BindingFlags.ExactBinding | BindingFlags.FlattenHierarchy | BindingFlags.GetField | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.OptionalParamBinding | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.SetField | BindingFlags.SuppressChangeType)!;
		/// <inheritdoc cref="GetAllMembers(Type)" />
		public static PropertyInfo[] GetAllProperties(this Type type) => type is null ? Array.Empty<PropertyInfo>()! : type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.IgnoreReturn | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.CreateInstance | BindingFlags.Default | BindingFlags.DeclaredOnly | BindingFlags.DoNotWrapExceptions | BindingFlags.ExactBinding | BindingFlags.FlattenHierarchy | BindingFlags.GetField | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.OptionalParamBinding | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.SetField | BindingFlags.SuppressChangeType)!;
		/// <inheritdoc cref="GetAllMembers(Type)" />
		public static MethodInfo[] GetAllMethods(this Type type) => type is null ? Array.Empty<MethodInfo>()! : type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.IgnoreReturn | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.CreateInstance | BindingFlags.Default | BindingFlags.DeclaredOnly | BindingFlags.DoNotWrapExceptions | BindingFlags.ExactBinding | BindingFlags.FlattenHierarchy | BindingFlags.GetField | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.OptionalParamBinding | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.SetField | BindingFlags.SuppressChangeType)!;
		/// <inheritdoc cref="GetAllMembers(Type)" />
		public static ConstructorInfo[] GetAllConstructors(this Type type) => type is null ? Array.Empty<ConstructorInfo>()! : type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.IgnoreReturn | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.CreateInstance | BindingFlags.Default | BindingFlags.DeclaredOnly | BindingFlags.DoNotWrapExceptions | BindingFlags.ExactBinding | BindingFlags.FlattenHierarchy | BindingFlags.GetField | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.OptionalParamBinding | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.SetField | BindingFlags.SuppressChangeType)!;
		/// <inheritdoc cref="GetAllMembers(Type)" />
		public static EventInfo[] GetAllEvents(this Type type) => type is null ? Array.Empty<EventInfo>()! : type.GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.IgnoreCase | BindingFlags.IgnoreReturn | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.CreateInstance | BindingFlags.Default | BindingFlags.DeclaredOnly | BindingFlags.DoNotWrapExceptions | BindingFlags.ExactBinding | BindingFlags.FlattenHierarchy | BindingFlags.GetField | BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.OptionalParamBinding | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.SetField | BindingFlags.SuppressChangeType)!;

	}
}
