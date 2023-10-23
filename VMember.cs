using System.Reflection;

namespace VType
{
	/// <summary>
	/// An advanced class of the <see cref="MemberInfo"/> class.
	/// </summary>
	public class VMember : MemberInfo
	{
		/// <summary>
		/// The current <see cref="MemberInfo"/> instance.
		/// </summary>
		public readonly MemberInfo MInfo;
		/// <summary>
		/// The declaring type of the member.
		/// </summary>
		public override Type? DeclaringType => MInfo.DeclaringType;
		/// <summary>
		/// The member type.
		/// </summary>
		public override MemberTypes MemberType => MInfo.MemberType;
		/// <summary>
		/// The name of the member.
		/// </summary>
		public override string Name => MInfo.Name;
		/// <summary>
		/// The reflected <see cref="Type"/> of the member.
		/// </summary>
		public override Type? ReflectedType => MInfo.ReflectedType;
		/// <summary>
		/// Indicates whether the member is a field.
		/// </summary>
		public bool IsField => MemberType.HasFlag(MemberTypes.Field);
		/// <summary>
		/// Indicates whether the member is a method.
		/// </summary>
		public bool IsMethod => MemberType.HasFlag(MemberTypes.Method);
		/// <summary>
		/// Indicates whether the member is a constructor.
		/// </summary>
		public bool IsConstructor => MemberType.HasFlag(MemberTypes.Constructor);
		/// <summary>
		/// Indicates whether the member is a property.
		/// </summary>
		public bool IsProperty => MemberType.HasFlag(MemberTypes.Property);
		/// <summary>
		/// Indicates whether the member is a type info object.
		/// </summary>
		public bool IsTypeInfo => MemberType.HasFlag(MemberTypes.TypeInfo);
		/// <summary>
		/// Indicates whether the member is an event.
		/// </summary>
		public bool IsEvent => MemberType.HasFlag(MemberTypes.Event);
		/// <summary>
		/// Gets the input argument types.
		/// </summary>
		public Type[] InputTypes
		{
			get
			{
				if(IsProperty)
					return (((PropertyInfo)MInfo).GetSetMethod()??((PropertyInfo)MInfo).GetGetMethod())?.GetParameters().Select(q=>q.ParameterType).ToArray()??Array.Empty<Type>();
				if(IsMethod)
					return ((MethodInfo)MInfo).GetParameters().Select(q=>q.ParameterType).ToArray();
				if(IsConstructor)
					return ((ConstructorInfo)MInfo).GetParameters().Select(q=>q.ParameterType).ToArray();
				return Array.Empty<Type>();
			}
		}
		/// <summary>
		/// Gets the output/return <see cref="Type"/> of the object.
		/// </summary>
		public Type? OutputType
		{
			get
			{
				if(IsField)
					return ((FieldInfo)MInfo).FieldType;
				if(IsProperty)
					return ((PropertyInfo)MInfo).GetSetMethod()?.ReturnType;
				if(IsMethod)
					return ((MethodInfo)MInfo).ReturnType;
				if(IsConstructor)
					return ((ConstructorInfo)MInfo).GetType();
				return null;
			}
		}


		/// <summary>
		/// Creates a new instance of the <see cref="VMember"/> class.
		/// </summary>
		/// <param name="mInfo">The <see cref="MemberInfo"/> object to use.</param>
		public VMember(MemberInfo mInfo)
		{
			MInfo=mInfo;
		}
		/// <summary>
		/// Gets the custom attributes of the member.
		/// </summary>
		/// <param name="inherit"></param>
		/// <returns></returns>
		public override object[] GetCustomAttributes(bool inherit) => MInfo.GetCustomAttributes(inherit);
		/// <summary>
		/// Gets the custom attributes of the member.
		/// </summary>
		/// <param name="attributeType"></param>
		/// <param name="inherit"></param>
		/// <returns></returns>
		public override object[] GetCustomAttributes(Type attributeType, bool inherit) => MInfo.GetCustomAttributes(attributeType, inherit);
		/// <summary>
		/// Determines if the member is defined.
		/// </summary>
		/// <param name="attributeType"></param>
		/// <param name="inherit"></param>
		/// <returns></returns>
		public override bool IsDefined(Type attributeType, bool inherit) => MInfo.IsDefined(attributeType, inherit);

	}
}
