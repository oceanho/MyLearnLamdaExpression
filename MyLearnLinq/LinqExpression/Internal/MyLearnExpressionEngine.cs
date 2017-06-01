using MyLearnLinq.Comunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyLearnLinq.LinqExpression.Internal
{
    public static class MyLearnExpressionEngine
    {
        public static object Execute(Expression expression, bool isIEnumerable)
        {
            // 构建一个最里层 Where 条件的Visitor，用于获取表达式中的 Where 语句的表达式部分
            var whereFinder = new InnerMostWhereExpressionVisitor();

            // 执行 Visit 并获取 Where 条件表达式对象
            var whereExpression = whereFinder.GetInnerWhereExpression(expression);

            var lambdaExpression = (LambdaExpression)((UnaryExpression)(whereExpression.Arguments[1])).Operand;

            // 计算表达式，并替换被计算表达式的为一个ConstatExpression（常量表达式）结果
            lambdaExpression = (LambdaExpression)Evaluator.PartialEval(lambdaExpression);

            // 获取Where条件中的表达式值，该Visitor通过重写ExpressionVisitor.VisitBinary(BinaryExpression node)获取Where表达式的值
            LocationFindExpressionVisitor locationFindVistor = new LocationFindExpressionVisitor(lambdaExpression.Body);

            var locations = locationFindVistor.Locations;

            var myDataSourceClient = new MyLearnLinqDataClient();

            var places = myDataSourceClient.GetPlace(locations.ToArray());

            var placeQueryable = places.AsQueryable();

            // 修改 ExpressionTree（表达式树）
            var myExpressionTreeModifier = new MyLearnExpressionTreeModifier(placeQueryable);

            var myModifiedExpression = myExpressionTreeModifier.Visit(expression);

            /*
             * 
             * System.ArgumentException:
             * “Expression of type 'System.Collections.Generic.IEnumerable`1[MyLearnLinq.Comunication.PlaceType]'
             *  cannot be used for return type 'System.Linq.IQueryable`1[MyLearnLinq.Comunication.PlaceType]'”
             */
            if (isIEnumerable)
                return placeQueryable.Provider.CreateQuery(myModifiedExpression).AsQueryable();
            return placeQueryable.Provider.Execute(myModifiedExpression);
        }
        public static TResult Execute<TResult>(Expression expression)
        {
            return (TResult)Execute(expression, isIEnumerable: IsEnumerable(typeof(TResult).Name));
        }

        private static Func<string, bool> IsEnumerable = (typeName) => { return typeName == "IEnumerator`1" || typeName == "IEnumerable`1"; };
    }
}
