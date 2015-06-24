using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Zeje.Core
{
    /// <summary>表达式谓语扩展
    /// <remarks>
    /// 1、构造函数使用True时：
    /// （1）单个AND有效，多个AND有效，当然了True&&XX=XX
    /// （2）单个OR无效，多个OR无效：True || XX=True所以无效。
    /// （3）混合时：
    ///     ※(True && XX) || XX1 等于 XX || XX1，有效；
    ///     ※(True || XX) && XX1 等于 True && XX1 等于 XX1，局部有效
    ///     ※(True || XX) || XX1 等于 True||XX1 等于 True，全部无效
    /// 2、构造函数使用False时：和True情况一样 
    /// </remarks>
    /// </summary>
    public static class Predicate_
    {
        /// <summary>True
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        /// <summary>False
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, bool>> False<T>() { return f => false; }
        /// <summary>Or 或
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression1"></param>
        /// <param name="expression2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression1,
           Expression<Func<T, bool>> expression2)
        {
            var invokedExpression = Expression.Invoke(expression2, expression1.Parameters
                    .Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.Or(expression1.Body, invokedExpression),
            expression1.Parameters);
        }
        /// <summary>And 且
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression1"></param>
        /// <param name="expression2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression1,
              Expression<Func<T, bool>> expression2)
        {
            var invokedExpression = Expression.Invoke(expression2, expression1.Parameters
                 .Cast<Expression>());

            return Expression.Lambda<Func<T, bool>>(Expression.And(expression1.Body,
                   invokedExpression), expression1.Parameters);
        }
    }
}
