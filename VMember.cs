using System.Reflection;

namespace VAdvanceType
{
	/// <summary>
	/// An advanced class of the <see cref="MemberInfo"/> class.
	/// </summary>
	public class VMember:MemberInfo
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
		/// The method info object.
		/// </summary>
		public MethodInfo? MethodInfo => IsMethod ? (MethodInfo)MInfo : null;
		/// <summary>
		/// The field info object.
		/// </summary>
		public FieldInfo? FieldInfo => IsField ? (FieldInfo)MInfo : null;
		/// <summary>
		/// The property info object.
		/// </summary>
		public PropertyInfo? PropertyInfo => IsProperty ? (PropertyInfo)MInfo : null;
		/// <summary>
		/// The constructor info object.
		/// </summary>
		public ConstructorInfo? ConstructorInfo => IsConstructor ? (ConstructorInfo)MInfo : null;
		/// <summary>
		/// The type info object.
		/// </summary>
		public TypeInfo? TypeInfo => IsTypeInfo ? (TypeInfo)MInfo : null;
		/// <summary>
		/// The event info object.
		/// </summary>
		public EventInfo? EventInfo => IsEvent ? (EventInfo)MInfo : null;
		/// <summary>
		/// Gets the input argument types.
		/// </summary>
		public Type[] InputTypes
		{
			get
			{
				if(IsProperty)
					return (PropertyInfo!.GetSetMethod()??PropertyInfo.GetGetMethod())?.GetParameters().Select(q => q.ParameterType).ToArray()??Array.Empty<Type>();
				if(IsMethod)
					return MethodInfo!.GetParameters().Select(q => q.ParameterType).ToArray();
				if(IsConstructor)
					return ConstructorInfo!.GetParameters().Select(q => q.ParameterType).ToArray();
				return IsField ? (new Type[] { FieldInfo!.FieldType }) : Array.Empty<Type>();
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
					return FieldInfo!.FieldType;
				if(IsProperty)
					return PropertyInfo!.GetSetMethod()?.ReturnType;
				if(IsMethod)
					return MethodInfo!.ReturnType;
				return IsConstructor ? ConstructorInfo!.DeclaringType : null;
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
		/// <inheritdoc cref="VMember(MemberInfo)"/>
		public static implicit operator VMember(MethodInfo value) => new(value);
		/// <inheritdoc cref="VMember(MemberInfo)"/>
		public static implicit operator VMember(FieldInfo value) => new(value);
		/// <inheritdoc cref="VMember(MemberInfo)"/>
		public static implicit operator VMember(PropertyInfo value) => new(value);
		/// <inheritdoc cref="VMember(MemberInfo)"/>
		public static implicit operator VMember(ConstructorInfo value) => new(value);
		/// <inheritdoc cref="VMember(MemberInfo)"/>
		public static implicit operator VMember(TypeInfo value) => new(value);
		/// <inheritdoc cref="VMember(MemberInfo)"/>
		public static implicit operator VMember(EventInfo value) => new(value);
		/// <summary>
		/// Gets the <see cref="string"/> representation of this object.
		/// </summary>
		/// <returns></returns>
		public override string ToString() => MInfo is null ? "null" : Name + " (" + GetMemberTypeString() + ")";
		/// <summary>
		/// Gets the member type represented as a <see cref="string"/> value.
		/// </summary>
		/// <returns></returns>
		public string GetMemberTypeString()
		{
			return MemberType switch
			{
				MemberTypes.Constructor => "ConstructorInfo",
				MemberTypes.Field => "FieldInfo",
				MemberTypes.Property => "PropertyInfo",
				MemberTypes.Method => "MethodInfo",
				MemberTypes.Event => "EventInfo",
				MemberTypes.TypeInfo => "TypeInfo",
				MemberTypes.Custom => "Custom",
				MemberTypes.NestedType => "NestedType / TypeInfo",
				MemberTypes.All => "All",
				_ => "UNKNOWN",
			};
		}

	}
}
