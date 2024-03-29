﻿// <auto-generated />
using System;
using CareerCloud.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CareerCloud.EntityFrameworkDataAccess.Migrations
{
    [DbContext(typeof(CareerCloudContext))]
    [Migration("20200807040128_Initial create Code First DB alteration in connection string")]
    partial class InitialcreateCodeFirstDBalterationinconnectionstring
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantEducationPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Applicant")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CertificateDiploma")
                        .HasColumnName("Certificate_Diploma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CompletionDate")
                        .HasColumnName("Completion_Date")
                        .HasColumnType("datetime2");

                    b.Property<byte?>("CompletionPercent")
                        .HasColumnName("Completion_Percent")
                        .HasColumnType("tinyint");

                    b.Property<string>("Major")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnName("Start_Date")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Applicant");

                    b.ToTable("Applicant_Educations");
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantJobApplicationPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Applicant")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnName("Application_Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Job")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Applicant");

                    b.HasIndex("Job");

                    b.ToTable("Applicant_Job_Applications");
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantProfilePoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnName("City_Town")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnName("Country_Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("CurrentRate")
                        .HasColumnName("Current_Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("CurrentSalary")
                        .HasColumnName("Current_Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("Login")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PostalCode")
                        .HasColumnName("Zip_Postal_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnName("State_Province_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnName("Street_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Country");

                    b.HasIndex("Login");

                    b.ToTable("Applicant_Profiles");
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantResumePoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Applicant")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnName("Last_Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Resume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Applicant");

                    b.ToTable("Applicant_Resumes");
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantSkillPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Applicant")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("EndMonth")
                        .HasColumnName("End_Month")
                        .HasColumnType("tinyint");

                    b.Property<int>("EndYear")
                        .HasColumnName("End_Year")
                        .HasColumnType("int");

                    b.Property<string>("Skill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillLevel")
                        .HasColumnName("Skill_Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("StartMonth")
                        .HasColumnName("Start_Month")
                        .HasColumnType("tinyint");

                    b.Property<int>("StartYear")
                        .HasColumnName("Start_Year")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Applicant");

                    b.ToTable("Applicant_Skills");
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantWorkHistoryPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Applicant")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .HasColumnName("Company_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnName("Country_Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short>("EndMonth")
                        .HasColumnName("End_Month")
                        .HasColumnType("smallint");

                    b.Property<int>("EndYear")
                        .HasColumnName("End_Year")
                        .HasColumnType("int");

                    b.Property<string>("JobDescription")
                        .HasColumnName("Job_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnName("Job_Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("StartMonth")
                        .HasColumnName("Start_Month")
                        .HasColumnType("smallint");

                    b.Property<int>("StartYear")
                        .HasColumnName("Start_Year")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Applicant");

                    b.HasIndex("CountryCode");

                    b.ToTable("Applicant_Work_History");
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyDescriptionPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Company")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyDescription")
                        .HasColumnName("Company_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnName("Company_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Company");

                    b.HasIndex("LanguageId");

                    b.ToTable("Company_Descriptions");
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyJobDescriptionPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Job")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JobDescriptions")
                        .HasColumnName("Job_Descriptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .HasColumnName("Job_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Job");

                    b.ToTable("Company_Jobs_Descriptions");
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyJobEducationPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Importance")
                        .HasColumnType("smallint");

                    b.Property<Guid>("Job")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Major")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Job");

                    b.ToTable("Company_Job_Educations");
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyJobPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Company")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCompanyHidden")
                        .HasColumnName("Is_Company_Hidden")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInactive")
                        .HasColumnName("Is_Inactive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ProfileCreated")
                        .HasColumnName("Profile_Created")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Company");

                    b.ToTable("Company_Jobs");
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyJobSkillPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Importance")
                        .HasColumnType("int");

                    b.Property<Guid>("Job")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Skill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillLevel")
                        .HasColumnName("Skill_Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Job");

                    b.ToTable("Company_Job_Skills");
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyLocationPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnName("City_Town")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Company")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .HasColumnName("Country_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnName("Zip_Postal_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnName("State_Province_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnName("Street_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Company");

                    b.ToTable("Company_Locations");
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyProfilePoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("CompanyLogo")
                        .HasColumnName("Company_Logo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CompanyWebsite")
                        .HasColumnName("Company_Website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .HasColumnName("Contact_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .HasColumnName("Contact_Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnName("Registration_Date")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Company_Profiles");
                });

            modelBuilder.Entity("CareerCloud.Pocos.SecurityLoginPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AgreementAccepted")
                        .HasColumnName("Agreement_Accepted_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnName("Email_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ForceChangePassword")
                        .HasColumnName("Force_Change_Password")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnName("Full_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInactive")
                        .HasColumnName("Is_Inactive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLocked")
                        .HasColumnName("Is_Locked")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordUpdate")
                        .HasColumnName("Password_Update_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefferredLanguage")
                        .HasColumnName("Prefferred_Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Security_Logins");
                });

            modelBuilder.Entity("CareerCloud.Pocos.SecurityLoginsLogPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsSuccesful")
                        .HasColumnName("Is_Succesful")
                        .HasColumnType("bit");

                    b.Property<Guid>("Login")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LogonDate")
                        .HasColumnName("Logon_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("SourceIP")
                        .HasColumnName("Source_IP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Login");

                    b.ToTable("Security_Logins_Log");
                });

            modelBuilder.Entity("CareerCloud.Pocos.SecurityLoginsRolePoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Login")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Role")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("Time_Stamp")
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("Login");

                    b.HasIndex("Role");

                    b.ToTable("Security_Logins_Roles");
                });

            modelBuilder.Entity("CareerCloud.Pocos.SecurityRolePoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsInactive")
                        .HasColumnName("Is_Inactive")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Security_Roles");
                });

            modelBuilder.Entity("CareerCloud.Pocos.SystemCountryCodePoco", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("System_Country_Codes");
                });

            modelBuilder.Entity("CareerCloud.Pocos.SystemLanguageCodePoco", b =>
                {
                    b.Property<string>("LanguageID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NativeName")
                        .HasColumnName("Native_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageID");

                    b.ToTable("System_Language_Codes");
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantEducationPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.ApplicantProfilePoco", "ApplicantProfiles")
                        .WithMany("ApplicantEducations")
                        .HasForeignKey("Applicant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantJobApplicationPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.ApplicantProfilePoco", "ApplicantProfile")
                        .WithMany("ApplicantJobApplications")
                        .HasForeignKey("Applicant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerCloud.Pocos.CompanyJobPoco", "CompanyJob")
                        .WithMany("ApplicantJobApplications")
                        .HasForeignKey("Job")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantProfilePoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.SystemCountryCodePoco", "SystemCountryCode")
                        .WithMany("ApplicantProfiles")
                        .HasForeignKey("Country");

                    b.HasOne("CareerCloud.Pocos.SecurityLoginPoco", "SecurityLogin")
                        .WithMany("ApplicantProfiles")
                        .HasForeignKey("Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantResumePoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.ApplicantProfilePoco", "ApplicantProfile")
                        .WithMany("ApplicantResume")
                        .HasForeignKey("Applicant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantSkillPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.ApplicantProfilePoco", "ApplicantProfile")
                        .WithMany("ApplicantSkills")
                        .HasForeignKey("Applicant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.ApplicantWorkHistoryPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.ApplicantProfilePoco", "applicantProfile")
                        .WithMany("ApplicantWorkHistories")
                        .HasForeignKey("Applicant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerCloud.Pocos.SystemCountryCodePoco", "systemCountryCode")
                        .WithMany("ApplicantWorkHistories")
                        .HasForeignKey("CountryCode");
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyDescriptionPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.CompanyProfilePoco", "CompanyProfile")
                        .WithMany("CompanyDescriptions")
                        .HasForeignKey("Company")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerCloud.Pocos.SystemLanguageCodePoco", "SystemLanguageCode")
                        .WithMany("CompanyDescriptions")
                        .HasForeignKey("LanguageId");
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyJobDescriptionPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.CompanyJobPoco", "CompanyJob")
                        .WithMany("CompanyJobDescriptions")
                        .HasForeignKey("Job")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyJobEducationPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.CompanyJobPoco", "CompanyJob")
                        .WithMany("CompanyJobEducations")
                        .HasForeignKey("Job")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyJobPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.CompanyProfilePoco", "CompanyProfile")
                        .WithMany("CompanyJobs")
                        .HasForeignKey("Company")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyJobSkillPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.CompanyJobPoco", "CompanyJob")
                        .WithMany("CompanyJobSkills")
                        .HasForeignKey("Job")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.CompanyLocationPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.CompanyProfilePoco", "CompanyProfile")
                        .WithMany("CompanyLocations")
                        .HasForeignKey("Company")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.SecurityLoginsLogPoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.SecurityLoginPoco", "SecurityLogin")
                        .WithMany("SecurityLoginsLogs")
                        .HasForeignKey("Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerCloud.Pocos.SecurityLoginsRolePoco", b =>
                {
                    b.HasOne("CareerCloud.Pocos.SecurityLoginPoco", "SecurityLogin")
                        .WithMany("SecurityLoginsRoles")
                        .HasForeignKey("Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerCloud.Pocos.SecurityRolePoco", "SecurityRole")
                        .WithMany("SecurityLoginsRoles")
                        .HasForeignKey("Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
