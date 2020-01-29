/******************************************************************************************************
 *This template was generated on 11/08/2019 04:42:05 using Development Center version 0.9.2. *
******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using CodesTable.Data.Interfaces;

namespace CodesTable.Data
{
    public abstract class MapToObjectBase<TEntity> : IMapToObject<TEntity>
        where TEntity : class
    {
        protected readonly ILogger logger;

        protected MapToObjectBase(ILogger l)
        {
            logger = l;
        }

        public abstract TEntity Execute(IDataReader reader);
    }
    public abstract class MapFromObjectBase<TEntity> : IMapFromObject<TEntity>
        where TEntity : class
    {
        protected readonly ILogger logger;

        protected MapFromObjectBase(ILogger l)
        {
            logger = l;
        }

        public abstract void Execute(TEntity entity, SqlCommand cmd);
    }
}