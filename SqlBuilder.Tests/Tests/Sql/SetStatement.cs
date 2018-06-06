﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Sql;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class SetStatement
	{

		[TestMethod]
		[TestCategory("SetList")]
		public void ValuesSimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			SetList w = new SetList(SqlBuilder.DefaultFormatter);
			w.Append("a", "b", "c");
			string result = w.GetSql();
			string sql = "[a]=@a, [b]=@b, [c]=@c";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("SetList")]
		public void ValuesSimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			SetList w = new SetList(SqlBuilder.DefaultFormatter);
			w.AppendValue("a", "NOW()").AppendValue("b", "100").AppendValue("c", "NULL");
			string result = w.GetSql();
			string sql = "[a]=NOW(), [b]=100, [c]=NULL";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("SetList")]
		public void ValuesSimpleAlias()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			SetList w = new SetList(SqlBuilder.DefaultFormatter);
			w.AppendValue("a", "NOW()").AppendValue("b", "100").AppendValue("c", "NULL");
			string result = w.GetSql("t");
			string sql = "'t'.[a]=NOW(), 't'.[b]=100, 't'.[c]=NULL";
			Assert.AreEqual(sql, result);
		}

	}

}
