using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SFTAddonDemo.ViewModels;
using SFTAddonDemo.Extensions;
using System.Dynamic;
using System.Net;
using SFTAddonDemo.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SFTAddonDemo.Controllers
{
    [Route("heroku/resources")]
    public class HerokuController : Controller
    {
        private IResourcesRepository _resourcesRepository { get; set; }

        public HerokuController(IResourcesRepository resourcesRepository)
        {
            _resourcesRepository = resourcesRepository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Resource resource)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lResources = resource.ToResources();
                    _resourcesRepository.Add(lResources);

                    return Json(new { id = lResources.uuid });
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return Json(new { id = -1 });
        }

        [HttpPut]
        public IActionResult Update(string id, [FromBody]string plan)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(plan))
                {
                    _resourcesRepository.Update(id, plan);
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return Json(new { });
        }

        [HttpDelete("heroku/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    _resourcesRepository.Remove(id);
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            return Json(new { });
        }
    }
}
