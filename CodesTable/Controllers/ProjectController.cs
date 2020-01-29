using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using CodesTable.Data;
using CodesTable.Data.Interfaces;
using CodesTable.Data.POCO;
using CodesTable.Data.Repository;
using CodesTable.Models;

namespace CodeTables.Web.UI.Controllers
{
    public class ProjectController : Controller
    {
        private ILogger logger;
        private readonly AppSettingsConfiguration settings;

        public ProjectController(ILogger<ProjectController> l, IOptions<AppSettingsConfiguration> s)
        {
            logger = l;
            settings = s.Value;
        }

        #region /Project/Index
        // GET: /Project/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ProjectRepository projectRepo;
            IPager<Project> pager = null;
            
            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    projectRepo = new ProjectRepository(settings, logger, dbc);
                    pager = await projectRepo.FindAllView(new Pager<Project>() { PageNbr = 0, PageSize = 20 });

                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return View(pager);
        }
        #endregion

        #region /Project/Details
        //GET: /Project/{id}
        [Route("/[controller]/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            ProjectRepository projectRepo;
            Project project;

            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    projectRepo = new ProjectRepository(settings, logger, dbc);

                    project = await projectRepo.FindByPKView(new PrimaryKey() { Key = id, IsIdentity = true });
                }
            }
            catch (Exception ex)
            {
                throw (Exception)Activator.CreateInstance(ex.GetType(), ex.Message + ex.StackTrace);
            }

            return View("Details", project);
        }
        #endregion

        #region /Project/Edit
        // GET: /Project/Edit/{id}
        [HttpGet]
        [Route("/[controller]/Edit/{id:Int}")]
        public async Task<ActionResult> Edit(int id)
        {
            ProjectRepository projectRepo;
            CodeRepository codeRepo;
            ProjectView view = new ProjectView() { Project = new Project() { Active = true }, ProjectTypes = new List<Code>(), StatusTypes = new List<Code>() };

            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    projectRepo = new ProjectRepository(settings, logger, dbc);
                    codeRepo = new CodeRepository(settings, logger, dbc);

                    view.Project = await projectRepo.FindByPKView(new PrimaryKey() { Key = id, IsIdentity = true });
                    view.ProjectTypes = (await codeRepo.FindAllByCategory(CodeCategory.PROJECT_TYPE)).ToList();
                    view.StatusTypes = (await codeRepo.FindAllByCategory(CodeCategory.STATUS)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (Exception)Activator.CreateInstance(ex.GetType(), ex.Message + ex.StackTrace);
            }

            return View("Edit", view);
        }

        // POST: /Project/Edit
        [HttpPost]
        [Route("/[controller]/Edit/{id:Int?}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProjectView view)
        {
            ProjectRepository projectRepo;
            CodeRepository codeRepo;

            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    codeRepo = new CodeRepository(settings, logger, dbc);

                    if (ModelState.IsValid)
                    {
                        projectRepo = new ProjectRepository(settings, logger, dbc);

                        await projectRepo.Update(view.Project);

                        return RedirectToAction("Index", "Project");
                    }
                    else
                    {
                        // Only get here if couldn't update project
                        view.ProjectTypes = (await codeRepo.FindAllByCategory(CodeCategory.PROJECT_TYPE)).ToList();
                        view.StatusTypes = (await codeRepo.FindAllByCategory(CodeCategory.STATUS)).ToList();

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

        #region /Project/Create
        // GET: /Project/Create
        [HttpGet]
        [Route("/[controller]/Create")]
        public async Task<ActionResult> Create()
        {
            ProjectView view = new ProjectView() { Project = new Project(), ProjectTypes = new List<Code>(), StatusTypes = new List<Code>() };
            CodeRepository codeRepo;

            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    codeRepo = new CodeRepository(settings, logger, dbc);

                    view.Project = new Project() { Active = true };
                    view.ProjectTypes = (await codeRepo.FindAllByCategory(CodeCategory.PROJECT_TYPE)).ToList();
                    view.StatusTypes = (await codeRepo.FindAllByCategory(CodeCategory.STATUS)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw (Exception)Activator.CreateInstance(ex.GetType(), ex.Message + ex.StackTrace);
            }

            return View("Create", view);
        }

        //// POST: /Project/Create
        [HttpPost]
        [Route("/[controller]/Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProjectView view)
        {
            ProjectRepository projectRepo;
            CodeRepository codeRepo;

            try
            {
                using (DBConnection dbc = new DBConnection(settings.Database.ConnectionString, logger))
                {
                    codeRepo = new CodeRepository(settings, logger, dbc);

                    if (ModelState.IsValid)
                    {
                        projectRepo = new ProjectRepository(settings, logger, dbc);

                        await projectRepo.Add(view.Project);
                        return RedirectToAction("Index", "Project");
                    }

                    // Only get here if couldn't add project and all tasks
                    view.ProjectTypes = (await codeRepo.FindAllByCategory(CodeCategory.PROJECT_TYPE)).ToList();
                    view.StatusTypes = (await codeRepo.FindAllByCategory(CodeCategory.STATUS)).ToList();
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