using System;
using System.Linq.Expressions;
using System.Reflection;

namespace BoVoyage.Framework.UI
{
    internal static class OutilsReflection
    {
        private static MemberExpression ExtraireMemberExpression(Expression expression)
        {
            MemberExpression memberExpression;
            if (expression.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = (MemberExpression)expression;
            }
            else if (expression.NodeType != ExpressionType.Convert)
            {
                memberExpression = null;
            }
            else
            {
                memberExpression = ExtraireMemberExpression(((UnaryExpression)expression).Operand);
            }
            return memberExpression;
        }

        public static PropertyInfo GetInformationPropriete<T>(Expression<Func<T, object>> expression)
        {
            if (expression.NodeType != ExpressionType.Lambda)
            {
                throw new ArgumentException("L'expression doit être une expression lambda", "expression");
            }
            var memberExpression = ExtraireMemberExpression(expression.Body);
            if (memberExpression == null)
            {
                throw new ArgumentException("L'expression doit être une expression d'accès membre", "expression");
            }
            if (memberExpression.Member.DeclaringType == null)
            {
                throw new InvalidOperationException("La propriété n'a pas de type");
            }
            return memberExpression.Member.DeclaringType.GetProperty(memberExpression.Member.Name);
        }
    }
}