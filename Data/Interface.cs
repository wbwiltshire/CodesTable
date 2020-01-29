/******************************************************************************************************
 *This template was generated on 11/08/2019 04:19:56 using Development Center version 0.9.2. *
******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CodesTable.Data.Interfaces
{

    public enum Action { Add, Update, Delete };

    public interface IPrimaryKey
    {
        object Key { get; set; }
        bool IsIdentity { get; set; }
        bool IsComposite { get; set; }
    }

    public class PrimaryKey : IPrimaryKey
    {
        private string tempString = String.Empty;
        public object Key { get; set; }
        public object[] CompositeKey { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsComposite { get; set; }

        public PrimaryKey()
        {
            IsIdentity = false;
            IsComposite = false;
        }

        public override string ToString()
        {
            if (IsComposite)
            {
                foreach (object k in CompositeKey)
                    tempString += k.ToString() + "|";
                return $"|{tempString}{IsComposite}";
            }
            else
                return $"|{Key}|{IsIdentity}";
        }
    }

    public interface IDBConnection : IDisposable
    {
        Task<bool> Open();
        void Close();
    }

    public interface IUOW
    {
        Task<bool> Save();
        Task<bool> Rollback();
    }

    public interface IRepository<TEntity> 
        where TEntity : class
    {
        Task<IPager<TEntity>> FindAll(IPager<TEntity> pager);
        Task<ICollection<TEntity>> FindAll();
        Task<TEntity> FindByPK(IPrimaryKey pk);
        Task<object> Add(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(PrimaryKey pk);
    }

    public interface IMapToObject<TEntity>
        where TEntity : class
    {
        TEntity Execute(IDataReader reader);
    }
    public interface IMapFromObject<TEntity>
        where TEntity : class
    {
        void Execute(TEntity entity, SqlCommand cmd);
    }
}
