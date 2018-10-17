using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace SendGridTest.Helpers
{
    /// <summary>
    /// PropertyChangedDelegate
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <param name="sender"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    public delegate void PropertyChangedDelegate<TSource>(TSource sender, object newValue)
        where TSource : class;

    /// <summary>
    /// PropertyChangedManager
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public class PropertyChangedManager<TSource>
        where TSource : class
    {
        /// <summary>
        /// Private reference to a dictionary that maps property names to their callback
        /// </summary>
        private Dictionary<string, PropertyMapperInfo> _propertyCallbackMapper =
            new Dictionary<string, PropertyMapperInfo>();

        /// <summary>
        /// Add PropertyChanged callback
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public PropertyChangedManager<TSource> AddPropertyChanged<TProperty>(Expression<Func<TSource, TProperty>> expression, PropertyChangedDelegate<TSource> callback)
        {
            if (callback == null)
                throw new ArgumentNullException($"The value for {nameof(callback)} cannot be null.");

            if (!(expression.Body is MemberExpression memberExpression))
                throw new InvalidOperationException("The lambda expression must refer to a property.");

            if (!(memberExpression.Member is PropertyInfo propertyInfo))
                throw new InvalidOperationException("The lambda expression must refer to a property.");

            string key = propertyInfo.Name;

            if (_propertyCallbackMapper.ContainsKey(key))
                _propertyCallbackMapper.Remove(key);

            _propertyCallbackMapper.Add(key, new PropertyMapperInfo(propertyInfo, callback));

            return this;
        }

        /// <summary>
        /// PropertyChanged event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            string key = e.PropertyName;

            if (_propertyCallbackMapper.TryGetValue(key, out PropertyMapperInfo propertyMapperInfo))
            {
                if (propertyMapperInfo == null)
                    return;

                object newValue = propertyMapperInfo.PropertyInfo.GetValue(sender);
                propertyMapperInfo.Callback.Invoke(sender as TSource, newValue);
            }
        }

        /// <summary>
        /// PropertyMapperInfo
        /// </summary>
        private class PropertyMapperInfo
        {
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="propertyInfo"></param>
            /// <param name="callback"></param>
            public PropertyMapperInfo(PropertyInfo propertyInfo, PropertyChangedDelegate<TSource> callback)
            {
                PropertyInfo = propertyInfo;
                Callback = callback;
            }

            /// <summary>
            /// PropertyInfo
            /// </summary>
            public PropertyInfo PropertyInfo { get; }

            /// <summary>
            /// Callback
            /// </summary>
            public PropertyChangedDelegate<TSource> Callback { get; }
        }
    }
}
