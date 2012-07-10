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
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using NHibernate.Cfg;
using NHibernate.Mapping;
using Iesi.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using NHibernate.Type;
using Iesi.Collections;

namespace ClearCanvas.Enterprise.Hibernate.Ddl
{
    /// <summary>
    /// Adds DB indexes on foreign key columns to the Hibernate relational model, based on a set of rules described below.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Rules:
    /// 1. For entities, create indexes on all references to other entities and enums.
    /// 2. For collections of values, create indexes only on the reference to the owner.
    /// 3. For many-to-many collection tables, create 2 indexes, each containing both of the columns, but varying which column is
    /// listed first.  This should improve join performance, going in either direction, by allowing the DB to bypass the join table
    /// altogether, using only the index.  This is explained to some degree here http://msdn2.microsoft.com/en-us/library/ms191195.aspx.
    /// </para>
    /// <para>
    /// This class make decisions about which indexes to create based on foreign keys.  Therefore, 
    /// ensure the that <see cref="EnumForeignKeyProcessor"/> and any other processors
    /// that create foreign keys are run prior to this processor.
    /// </para>
    /// </remarks>
    class ForeignKeyIndexProcessor : IndexCreatorBase
    {
        #region Overrides

        public override void Process(Configuration config)
        {
            // Rules:
            // 1. For entities, create indexes on all references to other entities and enums
            foreach (PersistentClass pc in config.ClassMappings)
            {
                CreateIndexes(config, pc.PropertyIterator);
            }

            // 2. For collections of values, create indexes only on the reference to the owner
            // 3. For many-to-many collection tables, create indexes on both columns together, going in both directions??

            foreach (Collection collection in config.CollectionMappings)
            {
                CreateIndexes(config, collection);
            }
        }

        #endregion

		private void CreateIndexes(Configuration config, Collection collection)
        {
            if(collection.Element is ManyToOne)
            {
                // many-to-many collection

                // collect all columns that participate in foreign keys
                HybridSet columns = new HybridSet();
                foreach (ForeignKey fk in collection.CollectionTable.ForeignKeyIterator)
                {
                    CollectionUtils.ForEach(fk.ColumnIterator, 
                        delegate(Column col)
                            {
                                columns.Add(col);
                            });
                }

                // there should always be exactly 2 "foreign key' columns in a many-many join table, AFAIK
                if (columns.Count != 2)
                {
                    throw new Exception("SNAFU");
                }

                List<Column> indexColumns = new List<Column>(new TypeSafeEnumerableWrapper<Column>(columns));

                // create two indexes, each containing both columns, going in both directions
                CreateIndex(collection.CollectionTable, indexColumns);

                indexColumns.Reverse();
                CreateIndex(collection.CollectionTable, indexColumns);
            }
            else
            {
                // this is a value collection, or a one-to-many collection

                // find the foreign-key that refers back to the owner table (assume there is only one of these - is this always true??)
                ForeignKey foreignKey = CollectionUtils.SelectFirst<ForeignKey>(collection.CollectionTable.ForeignKeyIterator,
                    delegate (ForeignKey fk) { return Equals(fk.ReferencedTable, collection.Table); });

                // create an index on all columns in this foreign key
                if(foreignKey != null)
                {
                    CreateIndex(collection.CollectionTable, new TypeSafeEnumerableWrapper<Column>(foreignKey.ColumnIterator));
                }
            }
        }

		private void CreateIndexes(Configuration config, IEnumerable properties)
        {
            foreach (Property prop in properties)
            {
                if (prop.Value is Component)
                {
                    // recur on component properties
                    Component comp = (Component) prop.Value;
                    CreateIndexes(config, comp.PropertyIterator);
                }
                else
                {
                    // is this property mapped with an EnumHbm class, or is it a many-to-one??
                    if (prop.Type is EnumStringType || prop.Type is ManyToOneType)
                    {
                        // index this column
                        Table indexedTable = prop.Value.Table;
                        Column indexedColumn = CollectionUtils.FirstElement<Column>(prop.ColumnIterator);
                        CreateIndex(indexedTable, new Column[] { indexedColumn });
                    }
                }
            }
        }
    }
}