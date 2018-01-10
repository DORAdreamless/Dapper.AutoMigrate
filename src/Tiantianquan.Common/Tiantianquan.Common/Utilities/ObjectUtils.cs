﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Tiantianquan.Common.Utilities
{
    /// <summary>A class provides utility methods.
    /// </summary>
    public static class ObjectUtils
    {
        /// <summary>Create an object from the source object, assign the properties by the same name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T CreateObject<T>(object source) where T : class, new()
        {
            var obj = new T();
            var propertiesFromSource = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var property in properties)
            {
                var sourceProperty = propertiesFromSource.FirstOrDefault(x => x.Name == property.Name);
                if (sourceProperty != null)
                {
                    property.SetValue(obj, sourceProperty.GetValue(source, null), null);
                }
            }

            return obj;
        }
        /// <summary>Update the target object by the source object, assign the properties by the same name.
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <param name="propertyExpressionsFromSource"></param>
        public static void UpdateObject<TTarget, TSource>(TTarget target, TSource source, params Expression<Func<TSource, object>>[] propertyExpressionsFromSource)
            where TTarget : class
            where TSource : class
        {
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (propertyExpressionsFromSource == null)
            {
                throw new ArgumentNullException("propertyExpressionsFromSource");
            }

            var properties = target.GetType().GetProperties();

            foreach (var propertyExpression in propertyExpressionsFromSource)
            {
                var propertyFromSource = GetProperty<TSource, object>(propertyExpression);
                var propertyFromTarget = properties.SingleOrDefault(x => x.Name == propertyFromSource.Name);
                if (propertyFromTarget != null)
                {
                    propertyFromTarget.SetValue(target, propertyFromSource.GetValue(source, null), null);
                }
            }
        }

        private static PropertyInfo GetProperty<TSource, TProperty>(Expression<Func<TSource, TProperty>> lambda)
        {
            var type = typeof(TSource);
            MemberExpression memberExpression = null;

            switch (lambda.Body.NodeType)
            {
                case ExpressionType.Convert:
                    memberExpression = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
                    break;
                case ExpressionType.MemberAccess:
                    memberExpression = lambda.Body as MemberExpression;
                    break;
            }

            if (memberExpression == null)
            {
                throw new ArgumentException(string.Format("Invalid Lambda Expression '{0}'.", lambda.ToString()));
            }

            var propInfo = memberExpression.Member as PropertyInfo;
            if (propInfo == null)
            {
                throw new ArgumentException(string.Format("Expression '{0}' refers to a field, not a property.", lambda.ToString()));
            }

            if (type != propInfo.ReflectedType && !type.IsSubclassOf(propInfo.ReflectedType))
            {
                throw new ArgumentException(string.Format("Expresion '{0}' refers to a property that is not from type {1}.", lambda.ToString(), type));
            }

            return propInfo;
        }
    }
}