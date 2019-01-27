﻿using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TASVideos.Data.Entity;
using TASVideos.Models;
using TASVideos.Services;
using TASVideos.Tasks;

namespace TASVideos.Pages.Users
{
	[AllowAnonymous]
	public class RatingsModel : BasePageModel
	{
		private readonly UserManager _userManager;

		public RatingsModel(
			UserManager userManager,
			UserTasks userTasks)
			: base(userTasks)
		{
			_userManager = userManager;
		}

		[FromRoute]
		public string UserName { get; set; }

		public UserRatingsModel Ratings { get; set; } = new UserRatingsModel();

		public async Task<IActionResult> OnGet()
		{
			Ratings = await _userManager.GetUserRatings(
				UserName,
				UserHas(PermissionTo.SeePrivateRatings));

			if (Ratings == null)
			{
				return NotFound();
			}

			return Page();
		}
	}
}
