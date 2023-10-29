﻿using Edukator.EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edukator.DataAccessLayer.Concrete
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-KR485FT\\SQLEXPRESS; initial catalog=EdukatorDb;integrated security=true;");
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<ContactInfo> ContactInfos { get; set; }
		public DbSet<Contact> Contacts { get; set; }
	}
}