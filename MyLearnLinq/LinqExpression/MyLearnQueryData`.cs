using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyLearnLinq.LinqExpression
{
    public class MyLearnQueryData<TData> : IEnumerable<TData>, IEnumerable, IQueryable<TData>, IOrderedQueryable<TData>
    {
        private Expression _expression;
        private IQueryProvider _provider;

        public MyLearnQueryData()
        {
            _provider = new MyLearnQueryProvider();
            _expression = Expression.Constant(this);
        }

        public MyLearnQueryData(MyLearnQueryProvider provider, Expression expression)
        {
            _provider = provider;
            _expression = expression;
        }

        public Type ElementType => typeof(TData);

        public Expression Expression => _expression;

        public IQueryProvider Provider => _provider;

        public IEnumerator GetEnumerator()
        {
            return Provider.Execute<IEnumerable>(_expression).GetEnumerator();
        }

        IEnumerator<TData> IEnumerable<TData>.GetEnumerator()
        {
            return Provider.Execute<IEnumerable<TData>>(_expression).GetEnumerator();
        }
    }
}
