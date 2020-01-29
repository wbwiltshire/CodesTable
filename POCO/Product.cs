/******************************************************************************************************
 *This class was generated on 12/02/2015 05:59:35 using Repository Builder version 0.9. *
 *The class was generated from Database: CodesTable and Table: Product.  *
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

    public class Product
    {

        public PrimaryKey PK { get; set; }
        public int Id
        {
            get { return (int)PK.Key; }
            set { PK.Key = (int)value; }
        }
        public string SKU { get; set; }
        public int SizeId { get; set; }
        public int UOMId { get; set; }
        public int ColorId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime ModifiedDt { get; set; }
        public DateTime CreateDt { get; set; }
        public Product()
        {
            PK = new PrimaryKey() { Key = -1, IsIdentity = true };
        }
        public string ToPrint()
        {
            return String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|", Id, SKU, SizeId, UOMId, ColorId, Description, Active, ModifiedDt, CreateDt);
        }

        //Relation properties
        public Code ColorCode { get; set; }
        public Code SizeCode { get; set; }
        public Code UOMCode { get; set; }

    }

    public class ProductMapToObject : MapToObjectBase<Product>, IMapToObject<Product>
    {
        public ProductMapToObject(ILogger l) : base(l)
        {
        }

        public override Product Execute(IDataReader reader)
        {
            Product product = new Product();
            int ordinal = 0;
            try
            {
                ordinal = reader.GetOrdinal("Id");
                product.Id = reader.GetInt32(ordinal);
                ordinal = reader.GetOrdinal("SKU");
                product.SKU = reader.GetString(ordinal);
                ordinal = reader.GetOrdinal("SizeId");
                product.SizeId = reader.GetInt32(ordinal);
                ordinal = reader.GetOrdinal("UOMId");
                product.UOMId = reader.GetInt32(ordinal);
                ordinal = reader.GetOrdinal("ColorId");
                product.ColorId = reader.GetInt32(ordinal);
                ordinal = reader.GetOrdinal("Description");
                product.Description = reader.GetString(ordinal);
                ordinal = reader.GetOrdinal("Active");
                product.Active = reader.GetBoolean(ordinal);
                ordinal = reader.GetOrdinal("ModifiedDt");
                product.ModifiedDt = reader.GetDateTime(ordinal);
                ordinal = reader.GetOrdinal("CreateDt");
                product.CreateDt = reader.GetDateTime(ordinal);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return product;
        }
    }


    public class ProductMapToObjectView : MapToObjectBase<Product>, IMapToObject<Product>
    {
        public ProductMapToObjectView(ILogger l) : base(l)
        {
        }

        public override Product Execute(IDataReader reader)
        {
            IMapToObject<Product> map = new ProductMapToObject(logger);
            Product product = map.Execute(reader);
            try
            {
                product.SizeCode = new Code { PK = new PrimaryKey { Key = product.SizeId, IsIdentity = true }, Name = reader.GetString(reader.GetOrdinal("SizeCodeName")) };
                product.ColorCode = new Code { PK = new PrimaryKey { Key = product.UOMId, IsIdentity = true }, Name = reader.GetString(reader.GetOrdinal("ColorName")) };
                product.UOMCode = new Code { PK = new PrimaryKey { Key = product.ColorId, IsIdentity = true }, Name = reader.GetString(reader.GetOrdinal("UOMName")) };
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return product;
        }
    }
    public class ProductMapFromObject : MapFromObjectBase<Product>, IMapFromObject<Product>
    {
        public ProductMapFromObject(ILogger l) : base(l)
        {
        }

        public override void Execute(Product product, SqlCommand cmd)
        {
            SqlParameter parm;

            try
            {
                parm = new SqlParameter("@p1", product.SKU);
                cmd.Parameters.Add(parm);
                parm = new SqlParameter("@p2", product.SizeId);
                cmd.Parameters.Add(parm);
                parm = new SqlParameter("@p3", product.UOMId);
                cmd.Parameters.Add(parm);
                parm = new SqlParameter("@p4", product.ColorId);
                cmd.Parameters.Add(parm);
                parm = new SqlParameter("@p5", product.Description);
                cmd.Parameters.Add(parm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}

