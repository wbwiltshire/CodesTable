using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CodesTable.Data;
using CodesTable.Data.Interfaces;
using CodesTable.Data.POCO;
namespace CodesTable.Data.Repository
{
    public class CodeRepository : RepositoryBase<Code>, IRepository<Code>
    {
		private const string FINDALLCOUNT_STMT = "SELECT COUNT(Id) FROM Code WHERE Active=1;";
		private const string FINDALL_STMT = "SELECT Id,CategoryId,Name,Active,ModifiedDt,CreateDt FROM Code WHERE Active=1";
		private const string FINDALLVIEW_STMT = "SELECT Id,CategoryId,Name,CategoryName,Active,ModifiedDt,CreateDt FROM vwFindAllCodeView";
		private const string FINDALLPAGER_STMT = "SELECT Id,CategoryId,Name,Active,ModifiedDt,CreateDt FROM Code WHERE Active=1 ORDER BY Id OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY;";
		private const string FINDALLVIEWPAGER_STMT = "SELECT Id,CategoryId,Name,CategoryName,Active,ModifiedDt,CreateDt FROM vwFindAllCodeView WHERE Active=1 ORDER BY Id OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY;";
		private const string FINDBYPK_STMT = "SELECT Id,CategoryId,Name,Active,ModifiedDt,CreateDt FROM Code WHERE Id=@pk;";
		private const string FINDBYPKVIEW_STMT = "SELECT Id,CategoryId,Name,CategoryName,Active,ModifiedDt,CreateDt FROM vwFindAllCodeView WHERE Id=@pk;";
		private const string ADD_STMT = "INSERT INTO Code (CategoryId, Name, Active, ModifiedDt, CreateDt) VALUES (@p1, @p2,  1, GETDATE(), GETDATE()); SELECT CAST(SCOPE_IDENTITY() AS INT);";
		private const string UPDATE_STMT = "UPDATE Code SET CategoryId=@p1,Name=@p2, ModifiedDt=GETDATE() WHERE Id=@pk;";
		private const string DELETE_STMT = "";
		private const string ORDERBY_STMT = " ORDER BY ";
		private const string FINDALL_PAGEDPROC = "uspFindAllCodePaged";
		private const string FINDALL_PAGEDVIEWPROC = "uspFindAllCodePagedView";
		private const string ADD_PROC = "uspAddCode";
		private const string UPDATE_PROC = "uspUpdateCode";

		private ILogger logger;

		#region ctor
		//Default constructor calls the base ctor
		public CodeRepository(AppSettingsConfiguration s, ILogger l, DBConnection d) :
			base(s, l, d)
		{ Init(l); }
		public CodeRepository(ILogger l, UnitOfWork uow, AppSettingsConfiguration s, DBConnection d) :
			base(s, l, uow, d)
		{ Init(l); }

		private void Init(ILogger l)
		{
			logger = l;
			OrderBy = "Id";
		}
		#endregion

		#region FindAll
		public override async Task<ICollection<Code>> FindAll()
		{
			CMDText = FINDALL_STMT;
			CMDText += ORDERBY_STMT + OrderBy;
			MapToObject = new CodeMapToObject(logger);
			return await base.FindAll();
		}
		#endregion

		#region FindAll(IPager pager)
		public async Task<IPager<Code>> FindAll(IPager<Code> pager)
		{
			string storedProcedure = String.Empty;

			MapToObject = new CodeMapToObject(logger);

			storedProcedure = Settings.Database.StoredProcedures.FirstOrDefault(p => p == FINDALL_PAGEDPROC);
			if (storedProcedure == null)
			{
				SqlCommandType = Constants.DBCommandType.SQL;
				CMDText = String.Format(FINDALLPAGER_STMT, pager.PageSize * pager.PageNbr, pager.PageSize);
				pager.Entities = await base.FindAll();
			}
			else
			{
				SqlCommandType = Constants.DBCommandType.SPROC;
				CMDText = storedProcedure;
				pager.Entities = await base.FindAllPaged(pager.PageSize * pager.PageNbr, pager.PageSize);
			}
			CMDText = FINDALLCOUNT_STMT;
			pager.RowCount = await base.FindAllCount();
			return pager;
		}
		#endregion

		#region FindAllView
		public async Task<ICollection<Code>> FindAllView()
		{
			CMDText = String.Format(FINDALLVIEW_STMT);
			CMDText += ORDERBY_STMT + OrderBy;
			MapToObject = new CodeMapToObjectView(logger);
			return await base.FindAll();
		}
		#endregion

		#region FindAllView(IPager pager)
		public async Task<IPager<Code>> FindAllView(IPager<Code> pager)
		{
			string storedProcedure = String.Empty;

			MapToObject = new CodeMapToObjectView(logger);

			storedProcedure = Settings.Database.StoredProcedures.FirstOrDefault(p => p == FINDALL_PAGEDVIEWPROC);
			if (storedProcedure == null)
			{
				SqlCommandType = Constants.DBCommandType.SQL;
				CMDText = String.Format(FINDALLVIEWPAGER_STMT, pager.PageSize * pager.PageNbr, pager.PageSize);
				pager.Entities = await base.FindAll();
			}
			else
			{
				SqlCommandType = Constants.DBCommandType.SPROC;
				CMDText = storedProcedure;
				pager.Entities = await base.FindAllPaged(pager.PageSize * pager.PageNbr, pager.PageSize);
			}
			CMDText = FINDALLCOUNT_STMT;
			pager.RowCount = await base.FindAllCount();
			return pager;
		}
		#endregion

		#region FindByPK(IPrimaryKey pk)
		public override async Task<Code> FindByPK(IPrimaryKey pk)
		{
			CMDText = FINDBYPK_STMT;
			MapToObject = new CodeMapToObject(logger);
			return await base.FindByPK(pk);
		}
		#endregion

		#region FindViewByPK(IPrimaryKey pk)
		public async Task<Code> FindByPKView(IPrimaryKey pk)
		{
			CMDText = FINDBYPKVIEW_STMT;
			MapToObject = new CodeMapToObjectView(logger);
			return await base.FindByPK(pk);
		}
		#endregion

		#region Add(Code)
		public async Task<object> Add(Code entity)
		{
			string storedProcedure = String.Empty;
			object result;
			int key = 0;

			storedProcedure = Settings.Database.StoredProcedures.FirstOrDefault(p => p == ADD_PROC);
			if (storedProcedure == null)
			{
				SqlCommandType = Constants.DBCommandType.SQL;
				CMDText = ADD_STMT;
			}
			else
			{
				SqlCommandType = Constants.DBCommandType.SPROC;
				CMDText = storedProcedure;
			}
			MapFromObject = new CodeMapFromObject(logger);
			result = await base.Add(entity, entity.PK);
			if (result != null)
				key = Convert.ToInt32(result);
			else
				key = -1;
			return key;
		}
		#endregion

		#region Update(Code)
		public async Task<int> Update(Code entity)
		{
			string storedProcedure = String.Empty;

			storedProcedure = Settings.Database.StoredProcedures.FirstOrDefault(p => p == UPDATE_PROC);
			if (storedProcedure == null)
			{
				SqlCommandType = Constants.DBCommandType.SQL;
				CMDText = UPDATE_STMT;
			}
			else
			{
				SqlCommandType = Constants.DBCommandType.SPROC;
				CMDText = storedProcedure;
			}
			MapFromObject = new CodeMapFromObject(logger);
			return await base.Update(entity, entity.PK);
		}
		#endregion

		#region Delete(PrimaryKey pk)
		public async Task<int> Delete(PrimaryKey pk)
		{
			CMDText = DELETE_STMT;
			return await base.Delete(pk);
		}
		#endregion

	}
}
