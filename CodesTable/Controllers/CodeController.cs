using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CodesTable.Models;
using CodesTable.Data;
using CodesTable.Data.Interfaces;
using CodesTable.Data.POCO;
using CodesTable.Data.Repository;

namespace CodesTable.Controllers
{
    public class CodeController : Controller
    {
        private readonly ILogger<CodeController> logger;
        private readonly AppSettingsConfiguration settings;

        public CodeController(ILogger<CodeController> l, IOptions<AppSettingsConfiguration> s)
        {
            logger = l;
            settings = s.Value;
        }

        #region /Code/Index
        // GET: /Code/
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            CodeRepository codeRepo;
            IPager<Code> pager = null;

            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    codeRepo = new CodeRepository(settings, logger, dbc);
                    pager = await codeRepo.FindAllView(new Pager<Code>() { PageNbr = 0, PageSize = 20 });

                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return View(pager);
        }
        #endregion

        #region /Code/Details
        //GET: /Code/{id}
        [Route("/[controller]/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            CodeRepository codeRepo;
            Code code;

            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    codeRepo = new CodeRepository(settings, logger, dbc);

                    code = await codeRepo.FindByPKView(new PrimaryKey() { Key = id, IsIdentity = true });
                }
            }
            catch (Exception ex)
            {
                throw (Exception)Activator.CreateInstance(ex.GetType(), ex.Message + ex.StackTrace);
            }

            return View("Details", code);
        }
        #endregion

        #region /Code/Edit
        // GET: /Code/Edit/{id}
        [HttpGet]
        [Route("/[controller]/Edit/{id:Int}")]
        public async Task<ActionResult> Edit(int id)
        {
            CodeRepository codeRepo;
            CodeView view = new CodeView() { Code = new Code() { Active = true }, CodeCategories = new List<CodeCategory>()};

            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    codeRepo = new CodeRepository(settings, logger, dbc);

                    view.Code = await codeRepo.FindByPKView(new PrimaryKey() { Key = id, IsIdentity = true });
                    view.CodeCategories = CategoryTypeHelper.ToPickList();
                }
            }
            catch (Exception ex)
            {
                throw (Exception)Activator.CreateInstance(ex.GetType(), ex.Message + ex.StackTrace);
            }

            return View("Edit", view);
        }

        // POST: /Code/Edit
        [HttpPost]
        [Route("/[controller]/Edit/{id:Int?}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CodeView view)
        {
            CodeRepository codeRepo;

            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    codeRepo = new CodeRepository(settings, logger, dbc);

                    if (ModelState.IsValid)
                    {
                        codeRepo = new CodeRepository(settings, logger, dbc);

                        await codeRepo.Update(view.Code);

                        return RedirectToAction("Index", "Code");
                    }
                    else
                    {
                        // Only get here if couldn't update code
                        view.CodeCategories = CategoryTypeHelper.ToPickList();

                        return View("Edit", view);
                    }
                }
            }
            catch (Exception ex)
            {
                throw (Exception)Activator.CreateInstance(ex.GetType(), ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region /Code/Create
        // GET: /Code/Create
        [HttpGet]
        [Route("/[controller]/Create")]
        public async Task<ActionResult> Create()
        {
            CodeView view = new CodeView()
            {
                Code = new Code() { Active = true },
                CodeCategories = new List<CodeCategory>()
            };

            try
            {
                view.CodeCategories = CategoryTypeHelper.ToPickList();
            }
            catch (Exception ex)
            {
                throw (Exception)Activator.CreateInstance(ex.GetType(), ex.Message + ex.StackTrace);
            }

            return await System.Threading.Tasks.Task.Run(() => View("Create", view));
        }

        // POST: /Code/Create
        [HttpPost]
        [Route("/[controller]/Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CodeView view)
        {
            CodeRepository codeRepo;

            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    codeRepo = new CodeRepository(settings, logger, dbc);

                    if (ModelState.IsValid)
                    {
                        await codeRepo.Add(view.Code);
                        return RedirectToAction("Index", "Code");
                    }

                    view.CodeCategories = CategoryTypeHelper.ToPickList();
                    return View("Create", view);
                }
            }
            catch (Exception ex)
            {
                throw (Exception)Activator.CreateInstance(ex.GetType(), ex.Message + ex.StackTrace);
            }

        }
        #endregion

    }
}