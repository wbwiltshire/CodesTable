/******************************************************************************************************
 *This class was generated on 11/09/2019 04:47:14 using Development Center version 0.9.2. *
 *The class was generated from Database: DKittiwake and Table: Project.  *
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

    public class Project
    {

        public PrimaryKey PK { get; set; }
        public int Id
        {
            get { return (int)PK.Key; }
            set { PK.Key = (int)value; }
        }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Project Type Id")]
        public int TypeId { get; set; }
        [Display(Name = "Client Id")]
        public int ClientId { get; set; }
        [Display(Name = "Status Id")]
        public int StatusId { get; set; }
        [Display(Name = "Is Active")]
        public bool Active { get; set; }
        [Display(Name = "Modified Date")]
        public DateTime ModifiedDt { get; set; }
        [Display(Name = "Create Date")]
        public DateTime CreateDt { get; set; }
        public Project()
        {
            PK = new PrimaryKey() { Key = -1, IsIdentity = true };
        }
        public override string ToString()
        {
            return $"{Id}|{Name}|{TypeId}|{ClientId}|{StatusId}|{Active}|{ModifiedDt}|{CreateDt}|";
        }

        //Relation properties
        public Code ProjectType { get; set; }
        public Code Status { get; set; }

    }

    public class ProjectMapToObject : MapToObjectBase<Project>, IMapToObject<Project>
    {
        public ProjectMapToObject(ILogger l) : base(l)
        {
        }

        public override Project Execute(IDataReader reader)
        {
            Project project = new Project();
            int ordinal = 0;
            try
            {
                ordinal = reader.GetOrdinal("Id");
                project.Id = reader.GetInt32(ordinal);
                ordinal = reader.GetOrdinal("Name");
                if (reader.IsDBNull(ordinal) == false)
                    project.Name = reader.GetString(ordinal);
                ordinal = reader.GetOrdinal("TypeId");
                project.TypeId = reader.GetInt32(ordinal);
                ordinal = reader.GetOrdinal("ClientId");
                project.ClientId = reader.GetInt32(ordinal);
                ordinal = reader.GetOrdinal("StatusId");
                project.StatusId = reader.GetInt32(ordinal);
                ordinal = reader.GetOrdinal("Active");
                project.Active = reader.GetBoolean(ordinal);
                ordinal = reader.GetOrdinal("ModifiedDt");
                project.ModifiedDt = reader.GetDateTime(ordinal);
                ordinal = reader.GetOrdinal("CreateDt");
                project.CreateDt = reader.GetDateTime(ordinal);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return project;
        }
    }


    public class ProjectMapToObjectView : MapToObjectBase<Project>, IMapToObject<Project>
    {
        public ProjectMapToObjectView(ILogger l) : base(l)
        {
        }

        public override Project Execute(IDataReader reader)
        {
            IMapToObject<Project> map = new ProjectMapToObject(logger);
            Project project = map.Execute(reader);
            try
            {
                project.ProjectType = new Code
                {
                    PK = new PrimaryKey { Key = project.TypeId, IsIdentity = true },
                    Name = reader.GetString(reader.GetOrdinal("TypeName"))
                };
                project.Status = new Code
                {
                    PK = new PrimaryKey { Key = project.ClientId, IsIdentity = true },
                    Name = reader.GetString(reader.GetOrdinal("StatusName"))
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return project;
        }
    }
    public class ProjectMapFromObject : MapFromObjectBase<Project>, IMapFromObject<Project>
    {
        public ProjectMapFromObject(ILogger l) : base(l)
        {
        }

        public override void Execute(Project project, SqlCommand cmd)
        {
            SqlParameter parm;

            try
            {
                if (project.Name == null)
                    parm = new SqlParameter("@p1", DBNull.Value);
                else
                    parm = new SqlParameter("@p1", project.Name);
                cmd.Parameters.Add(parm);
                parm = new SqlParameter("@p2", project.TypeId);
                cmd.Parameters.Add(parm);
                parm = new SqlParameter("@p3", project.ClientId);
                cmd.Parameters.Add(parm);
                parm = new SqlParameter("@p4", project.StatusId);
                cmd.Parameters.Add(parm);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}