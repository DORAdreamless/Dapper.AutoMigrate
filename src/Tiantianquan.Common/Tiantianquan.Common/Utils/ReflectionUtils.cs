using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Tiantianquan.Common.Utils {
	/// <summary>
	/// Reflection utility functions
	/// </summary>
	public static class ReflectionUtils {
		/// <summary>
		/// Make setter for member, member can be non public
		/// </summary>
		/// <typeparam name="T">Data Type</typeparam>
		/// <typeparam name="M">Member Type</typeparam>
		/// <param name="memberName">Member name</param>
		/// <returns></returns>
		public static Action<T, M> MakeSetter<T, M>(string memberName) {
			var objParam = Expression.Parameter(typeof(T), "obj");
			var memberParam = Expression.Parameter(typeof(M), "member");
			var memberExp = Expression.PropertyOrField(objParam, memberName);
			var body = Expression.Assign(memberExp, Expression.Convert(memberParam, memberExp.Type));
			return Expression.Lambda<Action<T, M>>(body, objParam, memberParam).Compile();
		}

		/// <summary>
		/// Make getter for member, member can be non public
		/// </summary>
		/// <typeparam name="T">Data Type</typeparam>
		/// <typeparam name="M">Member Type</typeparam>
		/// <param name="memberName">Member name</param>
		/// <returns></returns>
		public static Func<T, M> MakeGetter<T, M>(string memberName) {
			var objParam = Expression.Parameter(typeof(T), "obj");
			var body = Expression.Convert(Expression.PropertyOrField(objParam, memberName), typeof(M));
			return Expression.Lambda<Func<T, M>>(body, objParam).Compile();
		}

		/// <summary>
		/// Get generic arguments from type
		/// </summary>
		/// <param name="type">The type</param>
		/// <param name="genericType">The generic type</param>
		/// <example>GetGenericArguments(typeof(MyList), typeof(IList[]))</example>
		/// <returns></returns>
		public static Type[] GetGenericArguments(Type type, Type genericType) {
			var typeInfo = type.GetTypeInfo();
			foreach (var interfaceType in typeInfo.GetInterfaces()) {
				var interfaceTypeInfo = interfaceType.GetTypeInfo();
				if (interfaceTypeInfo.IsGenericType &&
					interfaceTypeInfo.GetGenericTypeDefinition() == genericType) {
					return interfaceTypeInfo.GetGenericArguments();
				}
			}
			while (typeInfo != null) {
				if (typeInfo.IsGenericType &&
					typeInfo.GetGenericTypeDefinition() == genericType) {
					return typeInfo.GetGenericArguments();
				}
				typeInfo = typeInfo.BaseType?.GetTypeInfo();
			}
			return null;
		}

        /// <summary>
        /// Checks whether <paramref name="givenType"/> implements/inherits <paramref name="genericType"/>.
        /// </summary>
        /// <param name="givenType">Type to check</param>
        /// <param name="genericType">Generic type</param>
        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            foreach (var interfaceType in givenType.GetInterfaces())
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
            }

            if (givenType.BaseType == null)
            {
                return false;
            }

            return IsAssignableToGenericType(givenType.BaseType, genericType);
        }

        /// <summary>
        /// Gets a list of attributes defined for a class member and it's declaring type including inherited attributes.
        /// </summary>
        /// <typeparam name="TAttribute">Type of the attribute</typeparam>
        /// <param name="memberInfo">MemberInfo</param>
        public static List<TAttribute> GetAttributesOfMemberAndDeclaringType<TAttribute>(MemberInfo memberInfo)
            where TAttribute : Attribute
        {
            var attributeList = new List<TAttribute>();

            //Add attributes on the member
            if (memberInfo.IsDefined(typeof(TAttribute), true))
            {
                attributeList.AddRange(memberInfo.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>());
            }

            //Add attributes on the class
            if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsDefined(typeof(TAttribute), true))
            {
                attributeList.AddRange(memberInfo.DeclaringType.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>());
            }

            return attributeList;
        }

        /// <summary>
        /// Tries to gets an of attribute defined for a class member and it's declaring type including inherited attributes.
        /// Returns null if it's not declared at all.
        /// </summary>
        /// <typeparam name="TAttribute">Type of the attribute</typeparam>
        /// <param name="memberInfo">MemberInfo</param>
        public static TAttribute GetSingleAttributeOfMemberOrDeclaringTypeOrNull<TAttribute>(MemberInfo memberInfo)
            where TAttribute : Attribute
        {
            //Get attribute on the member
            if (memberInfo.IsDefined(typeof(TAttribute), true))
            {
                return memberInfo.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>().First();
            }

            //Get attribute from class
            if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsDefined(typeof(TAttribute), true))
            {
                return memberInfo.DeclaringType.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>().First();
            }

            return null;
        }
    }
}
