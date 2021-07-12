using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EADPPROJ.Models
{
    public class EducationDB: DbContext
    {
        public DbSet<tb_AdminProfile> AdminProfiles{ get; set; }
        public DbSet<tb_Admin> Admins{ get; set; }
        public DbSet<tb_Answer> Answers{ get; set; }
        public DbSet<tb_AnswerSection> AnswerSections{ get; set; }
        public DbSet<tb_Blog> Blogs{ get; set; }
        public DbSet<tb_Comment> Comments{ get; set; }
        public DbSet<tb_ConnectionRecord> ConnectionRecords{ get; set; }
        public DbSet<tb_CreditRecord> CreditRecords{ get; set; }
        public DbSet<tb_Favourite> Favourites{ get; set; }
        public DbSet<tb_Invitation> Invitations{ get; set; }
        public DbSet<tb_Invoice> Invoices{ get; set; }
        public DbSet<tb_Notification> Notifications{ get; set; }
        public DbSet<tb_Order> Orders{ get; set; }
        public DbSet<tb_Question> Questions{ get; set; }
        public DbSet<tb_Shop> Shops{ get; set; }
        public DbSet<tb_Student> Students{ get; set; }
        public DbSet<tb_StudentProfile> StudentProfiles{ get; set; }
        public DbSet<tb_Teacher> Teachers{ get; set; }
        public DbSet<tb_TeacherProfile> TeacherProfiles{ get; set; }
        public DbSet<tb_UpvoteRecord> UpvoteRecords{ get; set; }
}

    public class tb_Admin
    {
        [Key, Required, StringLength(50)] public string Username { get; set; }
        [Required, StringLength(50)] public string Password { get; set; }
        [Required, StringLength(50)] public string Mail { get; set; }
        public int Credit { get; set; }
    }

    public class tb_AdminProfile
    {
        [Key, Required, StringLength(50)] public string Username { get; set; }
        [StringLength(50)] public string HeadIcon { get; set; }
        public int QuestionNo { get; set; }
        public int AnswersNo { get; set; }
        [StringLength(50)]public string Name { get; set; }
    }

    public class tb_Answer
    {
        [Key, Required]public int Id { get; set; }
        public string Content { get; set; }
        [Required]public int QuestionCode { get; set; }
        [StringLength(50)]public string Username { get; set; }
        public int BestSelected { get; set; }
        public DateTime PostTime { get; set; }
        public int UpVote { get; set; }
}
    public class tb_AnswerSection
    {
        [Key, Required] public int Id { get; set; }
        [Required]public int AnswerId { get; set; }
        public string Content { get; set; }
        [StringLength(50)]public string Username { get; set; }
        public int ReferenceId { get; set; }
    }
    public class tb_Blog
    {
        [Key]public int Id { get; set; }
        [StringLength(100)]public string Title { get; set; }
        public string Content { get; set; }
        [StringLength(50)]public string Poster { get; set; }
        [DataType(DataType.DateTime)]public DateTime PostTime { get; set; }
        public int Highlight { get; set; }
        [StringLength(100)]public string BGImage { get; set; }
        public int BGDefault { get; set; }
        public int Tip { get; set; }
        public int Favorite { get; set; }
    }
    public class tb_Comment
    {
        [Key]public int Id { get; set; }
        [StringLength(50)]public string Poster { get; set; }
        [StringLength(50)] public string Username { get; set; }
        [DataType(DataType.DateTime)] public DateTime PostTime { get; set; }
        public string Content { get; set; }
    }
    public class tb_ConnectionRecord
    {
        [Key] public int Id { get; set; }
        [StringLength(50)]public string IP { get; set; }
        [DataType(DataType.DateTime)]public DateTime LoginTime { get; set; }
        [DataType(DataType.DateTime)] public DateTime LeaveTime { get; set; }
        [StringLength(50)]public string Browser { get; set; }
        [StringLength(50)]public string OS { get; set; }
        [StringLength(50)] public string Username { get; set; }
    }
    public class tb_CreditRecord
    {
        [Key] public int Id { get; set; }
        [StringLength(50)] public string Username { get; set; }
        [StringLength(50)] public string Act { get; set; }
        public int CreditValue { get; set; }
        [DataType(DataType.DateTime)]public DateTime OccurTime { get; set; }
    }
    public class tb_Favourite
    {
        [Key] public int Id { get; set; }
        public int BlogId { get; set; }
        [StringLength(50)]public string Username { get; set; }
    }
    public class tb_Invitation
    {
        [Key] public int Id { get; set; }
        [StringLength(50)] public string Username { get; set; }
        [StringLength(50)]public string Code { get; set; }
        [StringLength(50)] public string InviteBy { get; set; }
    }
    public class tb_Invoice
    {
        [Key] public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
    public class tb_Notification
    {
        [Key] public int Id { get; set; }
        public int ViewBool { get; set; }
        [DataType(DataType.DateTime)]public DateTime PostTime { get; set; }
        [StringLength(50)]public string Type { get; set; }
        [StringLength(100)]public string Url { get; set; }
        [StringLength(50)]public string Username { get; set; }
    }
    public class tb_Order
    {
        [Key] public int Id { get; set; }
        [StringLength(50)] public string Username { get; set; }
        public float Price { get; set; }
        [DataType(DataType.DateTime)] public DateTime PostTime { get; set; }
    }
    public class tb_Question
    {
        [Key] public int Id { get; set; }
        [StringLength(100)]public string Title { get; set; }
        public string Content { get; set; }
        [DataType(DataType.DateTime)]public DateTime PostTime { get; set; }
        [DataType(DataType.DateTime)]public DateTime LastUpdate { get; set; }
        [StringLength(50)]public string Username { get; set; }
        [StringLength(50)]public string SchoolType { get; set; }
        [StringLength(30)]public string State { get; set; }
        public int CreditReward { get; set; }
        public int Review { get; set; }
    }
    public class tb_Shop
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        [StringLength(50)]public string School { get; set; }
        [StringLength(50)]public string Image { get; set; }
    }
    public class tb_Student
    {
        [Key, StringLength(50)] public string AdminNo { get; set; }
        [StringLength(50)]public string Password { get; set; }
        [StringLength(50)] public string Mail { get; set; }
        [StringLength(50)] public string Name { get; set; }
        public int Graduation { get; set; }
        [StringLength(30)]public string Sex { get; set; }
        public int Credit { get; set; }
    }
    public class tb_StudentProfile
    {
        [Key, StringLength(50)] public string AdminNo { get; set; }
        [StringLength(50)] public string HeadIcon { get; set; }
        [StringLength(50)] public string Name { get; set; }
        [StringLength(50)] public string School { get; set; }
        public int QuestionNo { get; set; }
        public int AnswersNo { get; set; }
    }
    public class tb_Teacher
    {
        [Key, StringLength(50)] public string NRIC { get; set; }
        [StringLength(50)] public string Password { get; set; }
        [StringLength(50)] public string Mail { get; set; }
        [StringLength(50)] public string Name { get; set; }
        [StringLength(30)] public string Sex { get; set; }
        public int Credit { get; set; }
        [DataType(DataType.DateTime)]public DateTime DOB { get; set; }
    }
    public class tb_TeacherProfile
    {
        [Key, StringLength(50)] public string NRIC { get; set; }
        [StringLength(50)] public string HeadIcon { get; set; }
        [StringLength(50)] public string Name { get; set; }
        public int QuestionNo { get; set; }
        public int AnswersNo { get; set; }
    }
    public class tb_UpvoteRecord
    {
        [Key] public int Id { get; set; }
        public int QuestionCode { get; set; }
        public int AnswersNo { get; set; }
        [StringLength(50)] public string Username { get; set; }
    }
}