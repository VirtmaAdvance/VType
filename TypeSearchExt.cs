using System.Reflection;

namespace VAdvanceType
{
	/// <summary>
	/// Provides search extension methods for the <see cref="Type"/> class.
	/// </summary>
	public static class TypeSearchExt
	{
		/// <inheritdoc cref="FindMembersByName(Type, string, MemberTypes, BindingFlags)"/>
		public static MemberInfo[] FindMembersByName(this Type type, string name) => type.GetMember(name, MemberTypes.All, VType.AllBindingFlags);
		/// <summary>
		/// Attempts to find a member with a given <paramref name="name"/>.
		/// </summary>
		/// <param name="type">The <see cref="Type"/> object to search in.</param>
		/// <param name="name">A <see cref="string"/> representation of the member name to look for.</param>
		/// <param name="memberTypes">The type of member(s) to allow in the search results.</param>
		/// <param name="bindingFlags">The <see cref="BindingFlags"/> filter to apply to the search results.</param>
		/// <returns>a <see cref="MemberInfo"/>[] array consisting of the results. Returns an empty array if none match.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="ArgumentException"></exception>
		public static MemberInfo[] FindMembersByName(this Type type, string name, MemberTypes memberTypes, BindingFlags bindingFlags)
		{
			if(type is null)
				throw new ArgumentNullException(nameof(type));
			if(name is null)
				throw new ArgumentNullException(nameof(name));
			return name.Length==0
				? throw new ArgumentException("The member name argument value cannot be an empty string value.", nameof(name))
				: type.GetMember(name, memberTypes, bindingFlags);
		}

	}
}
