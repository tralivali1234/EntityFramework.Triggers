﻿using System;
using System.Linq;
using System.Reflection;

#if EF_CORE
namespace EntityFrameworkCore.Triggers {
#else
namespace EntityFramework.Triggers {
#endif
	public static class TypeInfoExtensions {
#if NET40
		public static Type GetTypeInfo(this Type type) => type;
#endif

		public static Type[] GetDeclaredInterfaces(this Type t) {
			var allInterfaces = t.GetInterfaces();
			var baseInterfaces = t.GetTypeInfo().BaseType?.GetInterfaces();
			return baseInterfaces == null ? allInterfaces : allInterfaces.Except(baseInterfaces).ToArray();
		}
	}
}
