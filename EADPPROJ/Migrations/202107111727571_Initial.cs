namespace EADPPROJ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_AdminProfile",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50),
                        HeadIcon = c.String(maxLength: 50),
                        QuestionNo = c.Int(nullable: false),
                        AnswersNo = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.tb_Admin",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Mail = c.String(nullable: false, maxLength: 50),
                        Credit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.tb_Answer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        QuestionCode = c.Int(nullable: false),
                        Username = c.String(maxLength: 50),
                        BestSelected = c.Int(nullable: false),
                        PostTime = c.DateTime(nullable: false),
                        UpVote = c.Int(nullable: false),
                        Section = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_AnswerSection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerId = c.Int(nullable: false),
                        Content = c.String(),
                        Username = c.String(maxLength: 50),
                        ReferenceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Content = c.String(),
                        Poster = c.String(maxLength: 50),
                        PostTime = c.DateTime(nullable: false),
                        Highlight = c.Int(nullable: false),
                        BGImage = c.String(maxLength: 100),
                        BGDefault = c.Int(nullable: false),
                        Tip = c.Int(nullable: false),
                        Favourite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Poster = c.String(maxLength: 50),
                        Username = c.String(maxLength: 50),
                        PostTime = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_ConnectionRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IP = c.String(maxLength: 50),
                        LoginTime = c.DateTime(nullable: false),
                        LeaveTime = c.DateTime(nullable: false),
                        Browser = c.String(maxLength: 50),
                        OS = c.String(maxLength: 50),
                        Username = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_CreditRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Act = c.String(maxLength: 50),
                        CreditValue = c.Int(nullable: false),
                        OccurTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Favourite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                        Username = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Invitation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Code = c.String(maxLength: 50),
                        InviteBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Notification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bool = c.Int(nullable: false),
                        PostTime = c.DateTime(nullable: false),
                        Type = c.String(maxLength: 50),
                        Url = c.String(maxLength: 100),
                        Username = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Price = c.Single(nullable: false),
                        PostTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Content = c.String(),
                        PostTime = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                        Username = c.String(maxLength: 50),
                        SchoolType = c.String(maxLength: 50),
                        State = c.String(maxLength: 30),
                        CreditReward = c.Int(nullable: false),
                        Review = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_Shop",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        School = c.String(maxLength: 50),
                        Image = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_StudentProfile",
                c => new
                    {
                        AdminNo = c.String(nullable: false, maxLength: 50),
                        HeadIcon = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        School = c.String(maxLength: 50),
                        QuestionNo = c.Int(nullable: false),
                        AnswersNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminNo);
            
            CreateTable(
                "dbo.tb_Student",
                c => new
                    {
                        AdminNo = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Mail = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Graduation = c.Int(nullable: false),
                        Sex = c.String(maxLength: 30),
                        Credit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdminNo);
            
            CreateTable(
                "dbo.tb_TeacherProfile",
                c => new
                    {
                        NRIC = c.String(nullable: false, maxLength: 50),
                        HeadIcon = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        QuestionNo = c.Int(nullable: false),
                        AnswersNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NRIC);
            
            CreateTable(
                "dbo.tb_Teacher",
                c => new
                    {
                        NRIC = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Mail = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Sex = c.String(maxLength: 30),
                        Credit = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NRIC);
            
            CreateTable(
                "dbo.tb_UpvoteRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionCode = c.Int(nullable: false),
                        AnswersNo = c.Int(nullable: false),
                        Username = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_UpvoteRecord");
            DropTable("dbo.tb_Teacher");
            DropTable("dbo.tb_TeacherProfile");
            DropTable("dbo.tb_Student");
            DropTable("dbo.tb_StudentProfile");
            DropTable("dbo.tb_Shop");
            DropTable("dbo.tb_Question");
            DropTable("dbo.tb_Order");
            DropTable("dbo.tb_Notification");
            DropTable("dbo.tb_Invoice");
            DropTable("dbo.tb_Invitation");
            DropTable("dbo.tb_Favourite");
            DropTable("dbo.tb_CreditRecord");
            DropTable("dbo.tb_ConnectionRecord");
            DropTable("dbo.tb_Comment");
            DropTable("dbo.tb_Blog");
            DropTable("dbo.tb_AnswerSection");
            DropTable("dbo.tb_Answer");
            DropTable("dbo.tb_Admin");
            DropTable("dbo.tb_AdminProfile");
        }
    }
}
