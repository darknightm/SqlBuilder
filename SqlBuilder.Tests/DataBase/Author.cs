﻿using SqlBuilder.Attributes;

namespace SqlBuilder.Tests.DataBaseDemo
{

	[TableName("tab_authors")]
	public class Author
	{

		[PrimaryKey(true), IgnoreInsert, IgnoreUpdate]
		public int ID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

	}

}
