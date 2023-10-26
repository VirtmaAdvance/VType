using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using VIteration;

namespace VType
{
	/// <summary>
	/// Provides immediate <see cref="Type"/> information.
	/// </summary>
	public class VType:Type
	{
		/// <summary>
		/// The instance of the object.
		/// </summary>
		public object? Value { get; set; } = null;
		/// <summary>
		/// Indicates whether the value is <see langword="null"/>.
		/// </summary>
		public bool IsNull => this is null;
		/// <summary>
		/// Indicates whether the value is not <see langword="null"/>.
		/// </summary>
		public bool NotNull => this is not null;
		/// <summary>
		/// Indicates whether the value is a COMObject.
		/// </summary>
		public bool IsComObject => NotNull && IsCOMObject;
		/// <inheritdoc cref="Type.Assembly"/>
		public override Assembly Assembly => NotNull ? Assembly : throw new InvalidOperationException();
		/// <inheritdoc cref="Type.AssemblyQualifiedName"/>
		public override string? AssemblyQualifiedName => AssemblyQualifiedName;
		/// <inheritdoc cref="Type.BaseType"/>
		public override Type? BaseType => BaseType;
		/// <inheritdoc cref="Type.FullName"/>
		public override string? FullName => FullName;
		/// <inheritdoc cref="Type.GUID"/>
		public override Guid GUID => NotNull ? GUID : Guid.Empty;
		/// <inheritdoc cref="Type.Module"/>
		public override Module Module => NotNull ? Module : throw new InvalidOperationException();
		/// <inheritdoc cref="Type.Namespace"/>
		public override string? Namespace => Namespace;
		/// <inheritdoc cref="Type.UnderlyingSystemType"/>
		public override Type UnderlyingSystemType => NotNull ? UnderlyingSystemType : throw new InvalidOperationException();
		/// <summary>
		/// The name of the object data-type.
		/// </summary>
		public override string Name => NotNull ? Name : "null";
		/// <summary>
		/// Indicates whether the value is iterable.
		/// </summary>
		public bool IsIterable => NotNull && (IsAssignableFrom(typeof(IEnumerable)) || IsAssignableFrom(typeof(Array)) || ((IsClass || !IsArray) && Properties.FirstOrDefault(q => q.Name=="IsArray" || q.Name=="IsIterable") is not null));
		/// <summary>
		/// Indicates whether the object inherits from the <see cref="IEnumerable"/> interface.
		/// </summary>
		public bool IsEnumerable => NotNull && IsAssignableFrom(typeof(IEnumerable));
		/// <summary>
		/// Indicates whether the object inherits from the <see cref="ICollection"/> interface.
		/// </summary>
		public bool IsCollection => NotNull && IsAssignableFrom(typeof(ICollection));
		/// <summary>
		/// Determines if the value inherits from any numerical data-type or has a field "IsNumber" set to <see cref="bool">true</see>.
		/// </summary>
		public bool IsNumber => GetFields().Any(q => q.Name=="IsNumber" && q.FieldType==typeof(bool) && ((bool)q.GetValue(Value)!)) || InheritsAny(typeof(byte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(float), typeof(decimal), typeof(double));
		/// <summary>
		/// The object's members.
		/// </summary>
		public MemberInfo[] Members => NotNull ? this.GetAllMembers() : Array.Empty<MemberInfo>();
		/// <summary>
		/// The object's fields.
		/// </summary>
		public FieldInfo[] Fields => NotNull ? this.GetAllFields() : Array.Empty<FieldInfo>();
		/// <summary>
		/// The object's methods.
		/// </summary>
		public MethodInfo[] Methods => NotNull ? this.GetAllMethods() : Array.Empty<MethodInfo>();
		/// <summary>
		/// The object's constructors.
		/// </summary>
		public ConstructorInfo[] Constructors => NotNull ? this.GetAllConstructors() : Array.Empty<ConstructorInfo>();
		/// <summary>
		/// The object's properties.
		/// </summary>
		public PropertyInfo[] Properties => NotNull ? this.GetAllProperties() : Array.Empty<PropertyInfo>();


		/// <inheritdoc cref="VType(object)"/>
		public VType()
		{
			Value=Activator.CreateInstance(typeof(object))!;
		}
		/// <summary>
		/// Creates a new instance of the <see cref="VType"/> class.
		/// </summary>
		/// <param name="value"></param>
		public VType(object value)
		{
			Value=value;
		}
		/// <summary>
		/// Gets the attribute flags.
		/// </summary>
		/// <returns></returns>
		protected override TypeAttributes GetAttributeFlagsImpl() => NotNull ? Attributes : default;
		/// <summary>
		/// Gets the constructor info.
		/// </summary>
		/// <param name="bindingAttr"></param>
		/// <param name="binder"></param>
		/// <param name="callConvention"></param>
		/// <param name="types"></param>
		/// <param name="modifiers"></param>
		/// <returns></returns>
		protected override ConstructorInfo? GetConstructorImpl(BindingFlags bindingAttr, Binder? binder, CallingConventions callConvention, Type[] types, ParameterModifier[]? modifiers) => GetConstructor(bindingAttr, binder, callConvention, types, modifiers);
		/// <inheritdoc cref="Type.GetConstructors(BindingFlags)"/>
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr) => NotNull ? GetConstructors(bindingAttr) : Array.Empty<ConstructorInfo>();
		/// <inheritdoc cref="Type.GetElementType()"/>
		public override Type? GetElementType() => GetElementType();
		/// <inheritdoc cref="Type.GetEvent(string, BindingFlags)"/>
		public override EventInfo? GetEvent(string name, BindingFlags bindingAttr) => GetEvent(name, bindingAttr);
		/// <inheritdoc cref="Type.GetEvents(BindingFlags)"/>
		public override EventInfo[] GetEvents(BindingFlags bindingAttr) => NotNull ? GetEvents(bindingAttr) : Array.Empty<EventInfo>();
		/// <inheritdoc cref="Type.GetField(string, BindingFlags)"/>
		public override FieldInfo? GetField(string name, BindingFlags bindingAttr) => GetField(name, bindingAttr);
		/// <inheritdoc cref="Type.GetFields(BindingFlags)"/>
		public override FieldInfo[] GetFields(BindingFlags bindingAttr) => NotNull ? GetFields(bindingAttr) : Array.Empty<FieldInfo>();
		/// <inheritdoc cref="Type.GetInterface(string, bool)"/>
		[return: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.Interfaces)]
		public override Type? GetInterface(string name, bool ignoreCase) => GetInterface(name, ignoreCase);
		/// <inheritdoc cref="Type.GetInterfaces()"/>
		public override Type[] GetInterfaces() => NotNull ? GetInterfaces() : Array.Empty<Type>();
		/// <inheritdoc cref="Type.GetMembers(BindingFlags)"/>
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr) => NotNull ? GetMembers(bindingAttr) : Array.Empty<MemberInfo>();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="bindingAttr"></param>
		/// <param name="binder"></param>
		/// <param name="callConvention"></param>
		/// <param name="types"></param>
		/// <param name="modifiers"></param>
		/// <returns></returns>
		protected override MethodInfo? GetMethodImpl(string name, BindingFlags bindingAttr, Binder? binder, CallingConventions callConvention, Type[]? types, ParameterModifier[]? modifiers) => GetMethod(name, bindingAttr, binder, callConvention, types??Array.Empty<Type>(), modifiers);
		/// <inheritdoc cref="Type.GetMethods(BindingFlags)"/>
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr) => NotNull ? GetMethods(bindingAttr) : Array.Empty<MethodInfo>();
		/// <inheritdoc cref="Type.GetNestedType(string, BindingFlags)"/>
		public override Type? GetNestedType(string name, BindingFlags bindingAttr) => GetNestedType(name, bindingAttr);
		/// <inheritdoc cref="Type.GetNestedTypes(BindingFlags)"/>
		public override Type[] GetNestedTypes(BindingFlags bindingAttr) => NotNull ? GetNestedTypes(bindingAttr) : Array.Empty<Type>();
		/// <inheritdoc cref="Type.GetProperties(BindingFlags)"/>
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr) => NotNull ? GetProperties(bindingAttr) : Array.Empty<PropertyInfo>();
		/// <summary>
		/// 
		/// </summary>
		/// <param name="name"></param>
		/// <param name="bindingAttr"></param>
		/// <param name="binder"></param>
		/// <param name="returnType"></param>
		/// <param name="types"></param>
		/// <param name="modifiers"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		protected override PropertyInfo? GetPropertyImpl(string name, BindingFlags bindingAttr, Binder? binder, Type? returnType, Type[]? types, ParameterModifier[]? modifiers) => GetProperty(name, bindingAttr, binder, returnType, types!, modifiers);
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override bool HasElementTypeImpl() => NotNull && HasElementType;
		/// <inheritdoc cref="Type.InvokeMember(string, BindingFlags, Binder, object, object[], ParameterModifier[], CultureInfo, string[])"/>
		public override object? InvokeMember(string name, BindingFlags invokeAttr, Binder? binder, object? target, object?[]? args, ParameterModifier[]? modifiers, CultureInfo? culture, string[]? namedParameters) => InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		protected override bool IsArrayImpl() => NotNull && IsArray;
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		protected override bool IsByRefImpl() => NotNull && IsByRef;
		/// <summary>
		/// Determines if the value is a COMObject.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		protected override bool IsCOMObjectImpl() => NotNull && IsCOMObject;
		/// <summary>
		/// Determines if the value is a pointer reference.
		/// </summary>
		/// <returns></returns>
		protected override bool IsPointerImpl() => NotNull && IsPointer;
		/// <summary>
		/// Determines if the value is primitive.
		/// </summary>
		/// <returns></returns>
		protected override bool IsPrimitiveImpl() => NotNull && IsPrimitive;
		/// <summary>
		/// Gets an array of custom attributes.
		/// </summary>
		/// <param name="inherit"></param>
		/// <returns></returns>
		public override object[] GetCustomAttributes(bool inherit) => NotNull ? GetCustomAttributes(inherit) : Array.Empty<object>();
		/// <summary>
		/// Gets an array of custom attributes.
		/// </summary>
		/// <param name="attributeType"></param>
		/// <param name="inherit"></param>
		/// <returns></returns>
		public override object[] GetCustomAttributes(Type attributeType, bool inherit) => NotNull ? GetCustomAttributes(attributeType, inherit) : Array.Empty<object>();
		/// <summary>
		/// Determines if this object is defined.
		/// </summary>
		/// <param name="attributeType"></param>
		/// <param name="inherit"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public override bool IsDefined(Type attributeType, bool inherit) => NotNull && IsDefined(attributeType, inherit);
		/// <summary>
		/// Determines if the value can inherit from any of the given <paramref name="types"/>.
		/// </summary>
		/// <param name="types"></param>
		/// <returns></returns>
		public bool InheritsAny(params Type[] types) => (types??Array.Empty<Type>()).Any(q => IsAssignableFrom(q));
		/// <summary>
		/// Determines if the object instance contains a member with a matching name.
		/// </summary>
		/// <param name="names"></param>
		/// <returns></returns>
		public bool Contains(params string[] names)
		{
			names??=Array.Empty<string>();
			return names.Length>0 && Members.Any(sel => names.Contains(sel.Name));
		}
		/// <summary>
		/// Gets a <see cref="VMember"/> array representation of the <see cref="Members"/> field.
		/// </summary>
		/// <returns></returns>
		public VMember[] GetVMembers() => Members.Iterate(sel => new VMember(sel));
		/// <summary>
		/// Finds the member with the matching <paramref name="name"/>.
		/// </summary>
		/// <param name="name">A <see cref="string"/> representation of the name of a member to find.</param>
		/// <returns></returns>
		public MemberInfo? FindByName(string name) => Members.FirstOrDefault(sel => sel.Name==name);
		/// <summary>
		/// Gets the <see cref="string"/> representation of this object.
		/// </summary>
		/// <returns></returns>
		public override string ToString() => Name;

	}
}