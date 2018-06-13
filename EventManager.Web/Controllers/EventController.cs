using EventManager.Data.Data;
using EventManager.Services;
using EventManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using EventManager.Services.Models;

namespace EventManager.Web.Controllers
{
    public class EventController:Controller
    {
        private IEventService eventService;
        private UserManager<ApplicationUser> userManager;

        public EventController(IEventService eventService,UserManager<ApplicationUser> userManager)
        {
            this.eventService = eventService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(EventFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var user = await this.userManager.FindByNameAsync(this.HttpContext.User.Identity.Name);


            var successCreated = await this.eventService.Create(model.Name,model.Location, model.Start, model.End, user.Id);

            if (!successCreated)
            {
                return BadRequest();
            }

            return RedirectToAction("Index", "Home");
              
        }

        [Authorize]
        public async Task<IActionResult> EventsByUser()
        {
            var user = await this.userManager.FindByNameAsync(this.HttpContext.User.Identity.Name);

            return View(await this.eventService.EventsByUser(user.Id));

        }

        [Authorize]
        public async Task<IActionResult> Edit(long id)
        {
            var eventItem = await this.eventService.FindById(id);
            

            if (eventItem==null)
            {
                return BadRequest();
            }

            var model = new EventFormModel
            {
                Name = eventItem.Name,
                Location = eventItem.Location,
                Start = eventItem.Start,
                End = eventItem.End
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(long id,EventFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await this.userManager.FindByNameAsync(this.HttpContext.User.Identity.Name);

            var successEdited = await this.eventService.Edit(id, model.Name,model.Location, model.Start, model.End,user.Id);

            if (!successEdited)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(EventsByUser));
        }

        [Authorize]
        public async Task<IActionResult> Remove(long id)
        {
            var eventItem = await this.eventService.FindById(id);


            if (eventItem == null)
            {
                return BadRequest();
            }


            return View(id);
        }

        [Authorize]
        public async Task<IActionResult> Delete(long id)
        {
            var user = await this.userManager.FindByNameAsync(this.HttpContext.User.Identity.Name);

            var successRemoved = await this.eventService.Remove(id,user.Id);

            if (!successRemoved)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(EventsByUser));
        }



    }
}
