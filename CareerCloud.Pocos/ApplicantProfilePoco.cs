using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Profiles")]
    public class ApplicantProfilePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid Login { get; set; }
        [Column("Current_Salary")]
        public Decimal? CurrentSalary { get; set; }
        [Column("Current_Rate")]
        public Decimal? CurrentRate { get; set; }
        public string Currency { get; set; }
        [Column("Country_Code")]
        public string Country { get; set; }
        [Column("State_Province_Code")]
        public string Province { get; set; }
        [Column("Street_Address")]
        public string Street { get; set; }
        [Column("City_Town")]
        public string City { get; set; }
        [Column("Zip_Postal_Code")]
        public string PostalCode { get; set; }
        [Column("Time_Stamp")]        
        public Byte[] TimeStamp { get; set; }
        public ICollection<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        public ICollection<ApplicantEducationPoco> ApplicantEducations { get; set; }
        public SecurityLoginPoco SecurityLogin { get; set; }
        public ICollection<ApplicantResumePoco> ApplicantResume { get; set; }
        public ICollection<ApplicantSkillPoco> ApplicantSkills { get; set; }
        public ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        public SystemCountryCodePoco SystemCountryCode { get; set; }

    }
}
