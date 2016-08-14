using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Claims;
using PFMO.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PFMO.Contexts
{
    public class PFMO_DB : DbContext
    {
        public PFMO_DB()
            : base("PFMO")
        {
        }
   
        #region DbSets
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentCategory> EquipmentCategories { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<PersonnelDesignation> PersonnelDesignations { get; set; }
        public DbSet<PersonnelTask> PersonnelTasks { get; set; }
        public DbSet<Pinboard> Pinboards { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTeam> ProjectTeams { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionHead> SectionHeads { get; set; }
        public DbSet<SectionHeadDesignation> SectionHeadDesignations { get; set; }
        public DbSet<SectionTask> SectionTasks { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<SupplyCategory> SupplyCategories { get; set; }

        #endregion

    }
}
