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

	}
}
