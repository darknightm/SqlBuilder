﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class ColumnsStatement
	{

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimpleEmpty()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			ColumnsList c = new ColumnsList(SqlBuilder.Parameters);
			c.Append();
			string result = c.GetSql();
			string sql = "*";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimple1()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			ColumnsList c = new ColumnsList(SqlBuilder.Parameters);
			c.Append("a", "b", "c");
			string result = c.GetSql();
			string sql = "[a], [b], [c]";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimple2()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			ColumnsList c = new ColumnsList(SqlBuilder.Parameters);
			c.Append("column");
			string result = c.GetSql();
			string sql = "[column]";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimple3()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			ColumnsList c = new ColumnsList(SqlBuilder.Parameters);
			c.Append("column1").Append("column2");
			string result = c.GetSql();
			string sql = "[column1], [column2]";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Columns - List")]
		public void ColumnsSimpleAlias()
		{
			SqlBuilder.Parameters = ParametersLibrary.MsSql;

			ColumnsList c = new ColumnsList(SqlBuilder.Parameters);
			c.AppendAlias("last_name", "l");
			c.AppendAlias("first_name", "f");
			string result = c.GetSql();
			string sql = "[last_name] as 'l', [first_name] as 'f'";
			Assert.AreEqual(sql, result);
		}

	}

}
