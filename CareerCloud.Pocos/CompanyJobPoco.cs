using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs")]
    public class CompanyJobPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Company { get; set; }
        [Column("Profile_Created")]
        public DateTime ProfileCreated { get; set; }
        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }
        [Column("Is_Company_Hidden")]
        public Boolean IsCompanyHidden { get; set; }
        [Column("Time_Stamp")]        
        public Byte[] TimeStamp { get; set; }        
        public ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }        
        public ICollection<CompanyJobSkillPoco> CompanyJobSkills { get; set; }        
        public CompanyProfilePoco CompanyProfile { get; set; }        
        public ICollection<CompanyJobEducationPoco> CompanyJobEducations { get; set; }        
        public ICollection<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
    }
}
