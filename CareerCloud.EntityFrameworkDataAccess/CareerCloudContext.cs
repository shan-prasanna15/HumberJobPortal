using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext : DbContext
    {
        public DbSet<ApplicantEducationPoco> ApplicantEducation { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(@"Data Source=MSI\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ApplicantEducationPoco
            modelBuilder.Entity<ApplicantEducationPoco>(e => e.Property(p => p.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<ApplicantEducationPoco>().HasOne(p => p.ApplicantProfiles)
                                                            .WithMany(e => e.ApplicantEducations)
                                                            .HasForeignKey(f => f.Applicant);

            #endregion ApplicantEducationPoco
           

            #region ApplicantJobApplicationPoco
            modelBuilder.Entity<ApplicantJobApplicationPoco>(e => e.Property(p => p.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<ApplicantJobApplicationPoco>().HasOne(p => p.ApplicantProfile)
                                                .WithMany(p => p.ApplicantJobApplications)
                                                .HasForeignKey(f => f.Applicant);
            modelBuilder.Entity<ApplicantJobApplicationPoco>().HasOne(p => p.CompanyJob)
                                                .WithMany(p => p.ApplicantJobApplications)
                                                .HasForeignKey(f => f.Job);

            #endregion ApplicantJobApplicationPoco


            #region ApplicantProfilePoco
            modelBuilder.Entity<ApplicantProfilePoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<ApplicantProfilePoco>().HasOne(p => p.SystemCountryCode)
                                                        .WithMany(p => p.ApplicantProfiles)
                                                        .HasForeignKey(f => f.Country);
            modelBuilder.Entity<ApplicantProfilePoco>().HasOne(e => e.SecurityLogin)
                                                        .WithMany(p => p.ApplicantProfiles)
                                                        .HasForeignKey(f => f.Login);
            #endregion ApplicantProfilePoco


            #region ApplicantResumePoco
            modelBuilder.Entity<ApplicantResumePoco>().HasOne(e => e.ApplicantProfile)
                                                        .WithMany(p => p.ApplicantResume)
                                                        .HasForeignKey(f => f.Applicant);
            #endregion ApplicantResumePoco



            #region ApplicantSkillPoco
            modelBuilder.Entity<ApplicantSkillPoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<ApplicantSkillPoco>().HasOne(e => e.ApplicantProfile)
                                            .WithMany(p => p.ApplicantSkills)
                                            .HasForeignKey(f => f.Applicant);
            #endregion ApplicantSkillPoco

            #region ApplicantWorkHistoryPoco
            modelBuilder.Entity<ApplicantWorkHistoryPoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<ApplicantWorkHistoryPoco>().HasOne(e => e.applicantProfile)
                                                            .WithMany(p => p.ApplicantWorkHistories)
                                                            .HasForeignKey(f=> f.Applicant);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>().HasOne(e => e.systemCountryCode)
                                                            .WithMany(p => p.ApplicantWorkHistories)
                                                            .HasForeignKey(f=> f.CountryCode);

            #endregion ApplicantWorkHistoryPoco

            #region CompanyDescriptionPoco
            modelBuilder.Entity<CompanyDescriptionPoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<CompanyDescriptionPoco>().HasOne(e => e.CompanyProfile)
                                                            .WithMany(p => p.CompanyDescriptions)
                                                            .HasForeignKey(f => f.Company);
            modelBuilder.Entity<CompanyDescriptionPoco>().HasOne(e => e.SystemLanguageCode)
                                                                        .WithMany(p => p.CompanyDescriptions)
                                                                        .HasForeignKey(f => f.LanguageId);
            #endregion CompanyDescriptionPoco

            #region CompanyJobDescriptionPoco
            modelBuilder.Entity<CompanyJobDescriptionPoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<CompanyJobDescriptionPoco>().HasOne(e => e.CompanyJob)
                                                             .WithMany(p => p.CompanyJobDescriptions)
                                                             .HasForeignKey(f => f.Job);
            #endregion CompanyJobDescriptionPoco

            #region CompanyJobEducationPoco
            modelBuilder.Entity<CompanyJobEducationPoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<CompanyJobEducationPoco>().HasOne(e => e.CompanyJob)
                                                            .WithMany(p => p.CompanyJobEducations)
                                                            .HasForeignKey(f => f.Job);

            #endregion CompanyJobEducationPoco

            #region CompanyJobPoco
            modelBuilder.Entity<CompanyJobPoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<CompanyJobPoco>().HasOne(e => e.CompanyProfile)
                                                    .WithMany(p => p.CompanyJobs)
                                                    .HasForeignKey(f => f.Company);
            #endregion CompanyJobPoco

            #region CompanyJobSkillPoco
            modelBuilder.Entity<CompanyJobSkillPoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<CompanyJobSkillPoco>().HasOne(e => e.CompanyJob)
                                                        .WithMany(p=> p.CompanyJobSkills).HasForeignKey(f => f.Job);
            #endregion CompanyJobSkillPoco


            #region CompanyLocationPoco
            modelBuilder.Entity<CompanyLocationPoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<CompanyLocationPoco>().HasOne(e => e.CompanyProfile)
                                                        .WithMany(p => p.CompanyLocations)
                                                        .HasForeignKey(f => f.Company);
            #endregion CompanyLocationPoco

            #region CompanyProfilePoco
            modelBuilder.Entity<CompanyProfilePoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            #endregion CompanyProfilePoco



            #region SecurityLoginPoco
            modelBuilder.Entity<SecurityLoginPoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            #endregion SecurityLoginPoco



            #region SecurityLoginsLogPoco
            modelBuilder.Entity<SecurityLoginsLogPoco>().HasOne(e => e.SecurityLogin)
                                                        .WithMany(p => p.SecurityLoginsLogs)
                                                        .HasForeignKey(f => f.Login);
            #endregion SecurityLoginsLogPoco


            #region SecurityLoginsRolePoco
            modelBuilder.Entity<SecurityLoginsRolePoco>(e => e.Property(e => e.TimeStamp).IsRowVersion().IsConcurrencyToken());
            modelBuilder.Entity<SecurityLoginsRolePoco>().HasOne(e => e.SecurityLogin)
                                                         .WithMany(p => p.SecurityLoginsRoles)
                                                         .HasForeignKey(f => f.Login);
            modelBuilder.Entity<SecurityLoginsRolePoco>().HasOne(e => e.SecurityRole)
                                                         .WithMany(p => p.SecurityLoginsRoles)
                                                         .HasForeignKey(f => f.Role);

            #endregion SecurityLoginsRolePoco


            #region SecurityRolePoco
            // No Foreign key or time stamp for this POCO
            #endregion SecurityRolePoco            

            #region SystemCountryCodePoco
            // No Foreign key or time stamp for this POCO
            #endregion SystemCountryCodePoco

            #region SystemLanguageCodePoco
            // No Foreign key or time stamp for this POCO
            #endregion SystemLanguageCodePoco







        }

    }
}
