﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SqlBuilder.Tests.DataBaseDemo
{

	[TableName("tab_books")]
	public class Book
	{

		[PrimaryKey]
		[StatementIgnore]
		public int ID { get; set; }

		public string Name { get; set; }

		[Column("created_at")]
		[InsertDefault("NOW()")]
		public DateTime CreatedAt {get;set;}

		public int Year { get; set; }


		public int ID_Author { get; set; }

	}

	[TableName("tab_authors")]
	public class Author
	{

		[PrimaryKey]
		[StatementIgnore]
		public int ID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

	}

	public class Config
	{

		public string Value { get; set; }

	}

}
