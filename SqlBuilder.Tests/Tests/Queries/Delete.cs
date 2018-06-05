﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class Delete
	{

		#region Delete Simple

		[TestMethod]
		[TestCategory("Query - Delete")]
		public void QueryDeleteSimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Delete<DataBaseDemo.Author> d = new Delete<DataBaseDemo.Author>();
			
			string result = d.GetSql();
			string sql = "DELETE FROM [tab_authors];";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("Query - Delete")]
		public void QueryDeleteSimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			Delete<DataBaseDemo.Author> d = new Delete<DataBaseDemo.Author>();
			d.Where.Equal("p1").Less("p2").IsNULL("p3");

			string result = d.GetSql();
			string sql = "DELETE FROM [tab_authors] WHERE [p1]=@p1 AND [p2]<@p2 AND [p3] IS NULL;";
			Assert.AreEqual(sql, result);
		}

		#endregion

	}

}