using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{ //IdentityDbContext->DbContexten miras alır üstüne kendi işlerinide yapar
  //ÖNEMLİ->IdentityDbContext içerisine WriterUser,WriterRole,int
  //değerlerimi tanımlamadan migration ekleme ve veritabanını güncelleme
    public class Context:IdentityDbContext<WriterUser,WriterRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-VM4NR9R\\SQLEXPRESS;database=DbCoreProje;integrated security=true");
		}
		public DbSet<About> abouts { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Experience> Experiences { get; set; }
		public DbSet<Feature> features { get; set; }
		public DbSet<Message>  Messages { get; set; }
		public DbSet<Portfolio> portfolios { get; set; }
		public DbSet<Service> services { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<SocialMedia> socialMedias { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
		public DbSet<ToDoList> ToDoLists { get; set; }
		public DbSet<Announcement> Announcements { get; set; }
		public DbSet<WriterMessage> WriterMessages { get; set; }
    }
}
