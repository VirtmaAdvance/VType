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
		/// <returns>a <see cref="MemberInfo"/> array representing all of the members.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static MemberInfo[] GetAllMembers(this Type type) => type is null ? Array.Empty<MemberInfo>()! : type.GetMembers(VType.AllBindingFlags)!;
		/// <inheritdoc cref="GetAllMembers(Type)" />
		public static FieldInfo[] GetAllFields(this Type type) => type is null ? Array.Empty<FieldInfo>()! : type.GetFields(VType.AllBindingFlags)!;
		/// <inheritdoc cref="GetAllMembers(Type)" />
		public static PropertyInfo[] GetAllProperties(this Type type) => type is null ? Array.Empty<PropertyInfo>()! : type.GetProperties(VType.AllBindingFlags)!;
		/// <inheritdoc cref="GetAllMembers(Type)" />
		public static MethodInfo[] GetAllMethods(this Type type) => type is null ? Array.Empty<MethodInfo>()! : type.GetMethods(VType.AllBindingFlags)!;
		/// <inheritdoc cref="GetAllMembers(Type)" />
		public static ConstructorInfo[] GetAllConstructors(this Type type) => type is null ? Array.Empty<ConstructorInfo>()! : type.GetConstructors(VType.AllBindingFlags)!;
		/// <inheritdoc cref="GetAllMembers(Type)" />
		public static EventInfo[] GetAllEvents(this Type type) => type is null ? Array.Empty<EventInfo>()! : type.GetEvents(VType.AllBindingFlags)!;

	}
}
