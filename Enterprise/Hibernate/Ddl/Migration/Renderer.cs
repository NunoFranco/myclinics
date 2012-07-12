﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Common.Utilities;
using NHibernate.Dialect;
using ClearCanvas.Enterprise.Hibernate.Ddl.Migration.Renderers;
using NHibernate.Cfg;

namespace ClearCanvas.Enterprise.Hibernate.Ddl.Migration
{
	/// <summary>
	/// Base implementation of <see cref="IRenderer"/>.
	/// </summary>
	class Renderer : IRenderer
	{
		/// <summary>
		/// Gets the renderer implementation based on the dialect specified in the configuration.
		/// </summary>
		/// <returns></returns>
		public static IRenderer GetRenderer(Configuration config)
		{
			// TODO use config to choose renderer
			return new MsSqlRenderer(config);
		}

        private readonly Configuration _config;
		private readonly Dialect _dialect;
        private readonly string _defaultSchema;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="config"></param>
        protected Renderer(Configuration config)
		{
            _config = config;
			_dialect = Dialect.GetDialect(config.Properties);
            _defaultSchema = config.GetProperty(NHibernate.Cfg.Environment.DefaultSchema);

		}

		#region IRenderer Members

        public virtual IEnumerable<RelationalModelChange> PreFilter(IEnumerable<RelationalModelChange> changes)
        {
            // don't filter any changes
            return changes;
        }

		public virtual Statement[] Render(AddTableChange change)
		{
			TableInfo table = change.Table;

			StringBuilder sql = new StringBuilder("create table ")
				.Append(GetQualifiedName(table))
				.Append(" (");

			string columns = StringUtilities.Combine(
				CollectionUtils.Map<ColumnInfo, string>(table.Columns,
					delegate(ColumnInfo col)
					{
						return GetColumnDefinitionString(col);
					}), ", ");

			sql.Append(columns);

			if (table.PrimaryKey != null)
			{
				sql.Append(',').Append(GetPrimaryKeyString(table.PrimaryKey));
			}

			sql.Append(")");

			return new Statement[] { new Statement(sql.ToString()) };
		}

		public virtual Statement[] Render(DropTableChange change)
		{
			return new Statement[] { new Statement(_dialect.GetDropTableString(GetQualifiedName(change.Table))), };
		}

		public virtual Statement[] Render(AddColumnChange change)
		{
			string sql = string.Format("alter table {0} add {1}", GetQualifiedName(change.Table), GetColumnDefinitionString(change.Column));
			return new Statement[] { new Statement(sql) };
		}

		public virtual Statement[] Render(DropColumnChange change)
		{
			string sql = string.Format("alter table {0} drop column {1}", GetQualifiedName(change.Table), change.Column.Name);
			return new Statement[] { new Statement(sql) };
		}

		public virtual Statement[] Render(AddIndexChange change)
		{
			IndexInfo index = change.Index;
			StringBuilder buf = new StringBuilder("create index ")
				.Append(_dialect.QualifyIndexName ? index.Name : NHibernate.Util.StringHelper.Unqualify(index.Name))
				.Append(" on ")
				.Append(GetQualifiedName(change.Table))
				.Append(" (");

			buf.Append(StringUtilities.Combine(index.Columns, ", "));
			buf.Append(")");

			return new Statement[] { new Statement(buf.ToString()) };
		}

		public virtual Statement[] Render(DropIndexChange change)
		{
			IndexInfo index = change.Index;
			StringBuilder buf = new StringBuilder("drop index ")
				.Append(this.Dialect.QualifyIndexName ? index.Name : NHibernate.Util.StringHelper.Unqualify(index.Name))
				.Append(" on ")
				.Append(GetQualifiedName(change.Table));

			return new Statement[] { new Statement(buf.ToString()) };
		}

        public virtual Statement[] Render(AddPrimaryKeyChange change)
		{
			string sql = string.Format("alter table {0} add {1}",
				GetQualifiedName(change.Table),
				GetPrimaryKeyString(change.PrimaryKey));

			return new Statement[] { new Statement(sql) };
		}

        public virtual Statement[] Render(DropPrimaryKeyChange change)
		{
			string sql = string.Format("alter table {0} drop primary key", GetQualifiedName(change.Table));
			return new Statement[] { new Statement(sql) };
		}

		public virtual Statement[] Render(AddForeignKeyChange change)
		{
			ForeignKeyInfo fk = change.ForeignKey;
			string[] cols = fk.Columns.ToArray();
			string[] refcols = fk.ReferencedColumns.ToArray();

			string sql = string.Format("alter table {0} {1}",
				GetQualifiedName(change.Table),
				_dialect.GetAddForeignKeyConstraintString(fk.Name, cols, GetQualifiedName(change.Table.Schema, fk.ReferencedTable), refcols, true));

			return new Statement[] { new Statement(sql) };
		}

		public virtual Statement[] Render(DropForeignKeyChange change)
		{
			string sql = string.Format("alter table {0} {1}", GetQualifiedName(change.Table),
							  _dialect.GetDropForeignKeyConstraintString(change.ForeignKey.Name));

			return new Statement[] { new Statement(sql) };
		}

		public virtual Statement[] Render(AddUniqueConstraintChange change)
		{
			string sql = string.Format("alter table {0} add constraint {1} {2}",
				GetQualifiedName(change.Table),
				change.Constraint.Name,
				GetUniqueConstraintString(change.Constraint));

			return new Statement[] { new Statement(sql) };
		}

		public virtual Statement[] Render(DropUniqueConstraintChange change)
		{
			string sql = "alter table " + GetQualifiedName(change.Table) + _dialect.GetDropIndexConstraintString(change.Constraint.Name);
			return new Statement[] { new Statement(sql) };
		}

		public virtual Statement[] Render(ModifyColumnChange change)
		{
			string sql = string.Format("alter table {0} alter column {1}", GetQualifiedName(change.Table), GetColumnDefinitionString(change.Column));
			return new Statement[] { new Statement(sql) };
		}

        public virtual Statement[] Render(AddEnumValueChange change)
		{
			EnumerationMemberInfo e = change.Value;
			string sql = string.Format("insert into {0} (OID_, Code_, Value_, Description_, DisplayOrder_, Deactivated_) values (newid(),{1}, {2}, {3}, {4}, {5})",
				GetQualifiedName(change.Table),
				FormatValue(e.Code),
				FormatValue(e.Value),
				FormatValue(e.Description),
				e.DisplayOrder,
				FormatValue(false.ToString()));
			return new Statement[] { new Statement(sql) };
		}

        public virtual Statement[] Render(DropEnumValueChange change)
		{
			string sql = string.Format("delete from {0} where Code_ = {1}",
				GetQualifiedName(change.Table),
				FormatValue(change.Value.Code));
			return new Statement[] { new Statement(sql) };
		}

		#endregion

		#region Helpers

		/// <summary>
		/// Gets the configuration.
		/// </summary>
        protected Configuration Config
        {
            get { return _config; }
        }

		/// <summary>
		/// Gets the default schema defined in the configuration.
		/// </summary>
        protected string DefaultSchema
        {
            get { return _defaultSchema; }
        }

		/// <summary>
		/// Gets the dialect specified in the configuration.
		/// </summary>
		protected Dialect Dialect
		{
			get { return _dialect; }
		}

		/// <summary>
		/// Formats the specified string for SQL.
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
        protected static string FormatValue(string str)
		{
			// todo: can we use dialect here?
			if (str == null)
				return "NULL";

			// make sure to escape ' to ''
			return string.Format("'{0}'", str.Replace("'", "''"));
		}

		/// <summary>
		/// Gets the schema qualified name of the Table.
		/// </summary>
		protected string GetQualifiedName(TableInfo table)
		{
			return GetQualifiedName(table.Schema, table.Name);
		}

		/// <summary>
		/// Gets the schema qualified name of the table.
		/// </summary>
		/// <param name="schema"></param>
		/// <param name="table"></param>
		/// <returns></returns>
		protected string GetQualifiedName(string schema, string table)
		{
            string qualifier = schema ?? _defaultSchema;
            return qualifier == null ? table : qualifier + "." + table;
		}

		/// <summary>
		/// Gets the primary key definition string.
		/// </summary>
		/// <param name="pk"></param>
		/// <returns></returns>
		protected string GetPrimaryKeyString(ConstraintInfo pk)
		{
			return string.Format(" primary key ({0})", StringUtilities.Combine(pk.Columns, ", "));
		}

		/// <summary>
		/// Gets the unique constraint definition string.
		/// </summary>
		/// <param name="uk"></param>
		/// <returns></returns>
		protected string GetUniqueConstraintString(ConstraintInfo uk)
		{
			return string.Format(" unique ({0})", StringUtilities.Combine(uk.Columns, ", "));
		}

		/// <summary>
		/// Gets the column definition string.
		/// </summary>
		/// <param name="col"></param>
		/// <returns></returns>
		protected string GetColumnDefinitionString(ColumnInfo col)
		{
			StringBuilder colStr = new StringBuilder();
			colStr.Append(col.Name).Append(' ').Append(col.SqlType);

			if (col.Nullable)
			{
				colStr.Append(_dialect.NullColumnString);
			}
			else
			{
				colStr.Append(" not null");
			}

			return colStr.ToString();
		}

		#endregion
	}
}