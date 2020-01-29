/******************************************************************************************************
 *This class was generated on 12/03/2015 09:26:24 using Repository Builder version 0.9. *
 *The class was generated from Database: CodesTable and Table: Code.  *
******************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Logging;
using CodesTable.Data;
using CodesTable.Data.Interfaces;

namespace CodesTable.Data.POCO
{

    public class Code
    {

        public PrimaryKey PK { get; set; }
        public int Id
        {
            get { return (int)PK.Key; }
            set { PK.Key = (int)value; }
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime ModifiedDt { get; set; }
        public DateTime CreateDt { get; set; }
        public Code()
        {
            PK = new PrimaryKey() { Key = -1, IsIdentity = true };
        }
        public string ToPrint()
        {
            return String.Format("{0}|{1}|{2}|{3}|{4}|{5}|", Id, CategoryId, Name, Active, ModifiedDt, CreateDt);
        }

        //Relation properties
        public string CategoryName { get; set; }

    }

    public class CodeMapToObject : MapToObjectBase<Code>, IMapToObject<Code>
    {
        public CodeMapToObject(ILogger l) : base(l)
        {
        }

        public override Code Execute(IDataReader reader)
        {
            Code code = new Code();
            int ordinal = 0;
            try
            {
                ordinal = reader.GetOrdinal("Id");
                code.Id = reader.GetInt32(ordinal);
                ordinal = reader.GetOrdinal("CategoryId");
                code.CategoryId = reader.GetInt32(ordinal);
                ordinal = reader.GetOrdinal("Name");
                code.Name = reader.GetString(ordinal);
                ordinal = reader.GetOrdinal("Active");
                code.Active = reader.GetBoolean(ordinal);
                ordinal = reader.GetOrdinal("ModifiedDt");
                code.ModifiedDt = reader.GetDateTime(ordinal);
                ordinal = reader.GetOrdinal("CreateDt");
                code.CreateDt = reader.GetDateTime(ordinal);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return code;
        }
    }


    public class CodeMapToObjectView : MapToObjectBase<Code>, IMapToObject<Code>
    {
        public CodeMapToObjectView(ILogger l) : base(l)
        {
        }

        public override Code Execute(IDataReader reader)
        {
            IMapToObject<Code> map = new CodeMapToObject(logger);
            Code code = map.Execute(reader);
            try
            {
                code.CategoryName = reader.GetString(reader.GetOrdinal("CategoryName"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return code;
        }
    }
    public class CodeMapFromObject : MapFromObjectBase<Code>, IMapFromObject<Code>
    {
        public CodeMapFromObject(ILogger l) : base(l)
        {
        }

        public override void Execute(Code code, SqlCommand cmd)
        {
            SqlParameter parm;

            try
            {
                parm = new SqlParameter("@p1", code.CategoryId);
                cmd.Parameters.Add(parm);
                parm = new SqlParameter("@p2", code.Name);
                cmd.Parameters.Add(parm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}

