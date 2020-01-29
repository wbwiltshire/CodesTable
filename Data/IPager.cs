/******************************************************************************************************
 *This template was generated on 11/08/2019 04:39:07 using Development Center version 0.9.2. *
******************************************************************************************************/
using System;
using System.Collections.Generic;

namespace CodesTable.Data
{
    public interface IPager<TEntity>
        where TEntity : class
    {
        int PageNbr { get; set; }
        int PageSize { get; set; }
        int RowCount { get; set; }
        ICollection<TEntity> Entities { get; set; }
    }
    public class Pager<TEntity> : IPager<TEntity>
        where TEntity : class
    {
        public int PageNbr { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public ICollection<TEntity> Entities { get; set; }
    }
}