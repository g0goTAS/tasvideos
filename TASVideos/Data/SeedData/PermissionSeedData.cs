﻿using TASVideos.Data.Entity;

namespace TASVideos.Data.SeedData
{
	public static class PermissionSeedData
	{
		public static Permission[] Permissions =
		{
			new Permission
			{
				Id = PermissionTo.EditWikiPages,
				Name = "Edit Wiki Pages",
				Description = "The ability to edit basic wiki pages. This is the most basic editor privilege but some pages may be restrited to other privileges",
				Group = PermissionGroups.Editing
			},
			new Permission
			{
				Id = PermissionTo.EditGameResources,
				Name = "Edit Game Resource Pages",
				Description = "The ability to edit Game Resource wiki pages. These are basic game information and are considered separate from general wiki pages",
				Group = PermissionGroups.Editing
			},
			new Permission
			{
				Id = PermissionTo.EditSystemPages,
				Name = "Edit System Wiki Pages",
				Description = "The ability to edit System Wiki pages. These pages are more fundamental to the site behavior whan basic wiki pages",
				Group = PermissionGroups.Editing
			},
			new Permission
			{
				Id = PermissionTo.EditRoles,
				Name = "Edit Roles",
				Description = "The ability to create and edit roles and add/remove privileges to those roles",
				Group = PermissionGroups.UserAdministration
			},
			new Permission
			{
				Id = PermissionTo.DeleteRoles,
				Name = "Delete Roles",
				Description = "The ability to delete and existing role",
				Group = PermissionGroups.UserAdministration
			},
			new Permission
			{
				Id = PermissionTo.ViewUsers,
				Name = "View Users",
				Description = "The ability to see other user's profile data in read-only form",
				Group = PermissionGroups.UserAdministration
			},
			new Permission
			{
				Id = PermissionTo.EditUsers,
				Name = "Edit Users",
				Description = "The ability to edit users and assign/remove roles from the user",
				Group = PermissionGroups.UserAdministration
			},
			new Permission
			{
				Id = PermissionTo.EditPermissionDetails,
				Name = "Edit Permission Metadata",
				Description = "The ability to edit the description, groups, and any other metadata related to permissions. Note that the behavior of submissions can not be modified.",
				Group = PermissionGroups.UserAdministration
			}
		};
	}
}
