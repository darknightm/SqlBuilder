﻿using SqlBuilder.Interfaces;
using SqlBuilder.Sql;
using SqlBuilder.Templates;

namespace SqlBuilder
{

	public class Select<T> : IStatementSelect
	{

		public string TableAlias { get; set; }

		public IFormatter Formatter { get; set; }

		public IColumnsListAggregation Columns { get; set; }

		public IWhereList Where { get; set; }

		public IGroupByList GroupBy { get; set; }

		public IOrderByList OrderBy { get; set; }

		public Select(string tableAlias = "") : this(SqlBuilder.DefaultFormatter, tableAlias)
		{
		}

		public Select(IFormatter parameters, string tableAlias = "")
		{
			this.Formatter = parameters;
			this.TableAlias = tableAlias;
			this.Columns = new ColumnsListAggregation(this.Formatter);
			this.Where = new WhereList(this.Formatter);
			this.OrderBy = new OrderByList(this.Formatter);
			this.GroupBy = new GroupByList(this.Formatter, this.Columns);
		}

		public string GetSql()
		{
			string table = Reflection.GetTableName<T>();

			ITemplate result = TemplateLibrary.Select;
			result.Append(SnippetLibrary.Table(table, this.TableAlias));
			result.Append(SnippetLibrary.Columns(this.Columns.GetSql(this.TableAlias)));

			if (this.Where.Count > 0)
				result.Append(SnippetLibrary.Where(this.Where.GetSql()));
			if (this.GroupBy.Count > 0)
				result.Append(SnippetLibrary.GroupBy(this.GroupBy.GetSql()));
			if (this.OrderBy.Count > 0)
				result.Append(SnippetLibrary.OrderBy(this.OrderBy.GetSql()));

			return result.GetSql();
		}

		public override string ToString()
		{
			return this.GetSql();
		}

		public static Select<T> SelectAll(params string[] Columns)
		{
			Select<T> result = new Select<T>();
			result.Columns.Append(Columns);
			return result;
		}

		public static Select<T> SelectWherePK(params string[] Columns)
		{
			return SelectWherePK(SqlBuilder.DefaultFormatter, Columns);
		}

		public static Select<T> SelectWherePK(IFormatter parameters, params string[] Columns)
		{
			string pk = Reflection.GetPrimaryKey<T>();
			Select<T> result = new Select<T>(parameters);
			result.Columns.Append(Columns);
			result.Where.Equal(pk);
			return result;
		}

	}

}