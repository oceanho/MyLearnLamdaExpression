using MyLearnLinq.Comunication;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyLearnLinq.LinqExpression.Internal
{
    /// <summary>
    /// 位置参数
    /// </summary>
    internal class LocationFindExpressionVisitor : ExpressionVisitor
    {
        private Expression _expression;
        private List<string> _locations;

        public LocationFindExpressionVisitor(Expression expression)
        {
            _expression = expression;
        }

        public List<string> Locations
        {
            get
            {
                if (_locations == null)
                {
                    _locations = new List<string>();
                    Visit(_expression);
                }
                return _locations;
            }
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Equal)
            {
                if (ExpressionTreeHelper.IsMemberEqualsValueExpression(node, typeof(Place), "Name"))
                {
                    _locations.Add(ExpressionTreeHelper.GetValueFromEqualsExpression(node, typeof(Place), "Name"));
                    return node;
                }
                else if (ExpressionTreeHelper.IsMemberEqualsValueExpression(node, typeof(Place), "State"))
                {
                    _locations.Add(ExpressionTreeHelper.GetValueFromEqualsExpression(node, typeof(Place), "State"));
                    return node;
                }
                else
                    return base.VisitBinary(node);
            }
            else
                return base.VisitBinary(node);
        }
    }
}
