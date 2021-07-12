using System.Collections.Generic;
using System.Globalization;
using System.IO;
using EADPPROJ.Models;

namespace EADPPROJ.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EADPPROJ.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EducationDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EducationDB context)
        {
            //  This method will be called after migrating to the latest version.
            context.Admins.AddOrUpdate(
                new tb_Admin
                {
                    Username = "LoveCordelia",
                    Password = "Cordelia20001121",
                    Mail = "NYPJourneyTestMail@gmail.com",
                    Credit = 100000
                }
                );

            context.AdminProfiles.AddOrUpdate(
                new tb_AdminProfile
                {
                    Username = "LoveCordelia",
                    HeadIcon = "icon.png",
                    QuestionNo = 0,
                    AnswersNo = 0,
                    Name = "Wang Yang"
                });

            context.Students.AddOrUpdate(
                new tb_Student
                {
                    AdminNo = "201001A",
                    Password = "12345678",
                    Mail = "NYPJourneyTestMail@gmail.com",
                    Name = "Student Account",
                    Graduation = 2023,
                    Sex = "Male",
                    Credit = 1000
                });

            context.StudentProfiles.AddOrUpdate(
                new tb_StudentProfile
                {
                    AdminNo = "201001A",
                    HeadIcon = "icon_ASCII.jpg",
                    QuestionNo = 0,
                    AnswersNo = 0,
                    Name = "Student Account",
                    School = "SIT"
                });

            DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();

            dtFormat.ShortDatePattern = "yyyy/MM/dd";

            context.Teachers.AddOrUpdate(
                new tb_Teacher
                {
                    NRIC = "S1000000G",
                    Password = "12345678",
                    Mail = "NYPJourneyTestMail@gmail.com",
                    Name = "Teacher Account",
                    DOB = Convert.ToDateTime("2000/11/21",dtFormat),
                    Sex = "Male",
                    Credit = 10000
                });

            context.TeacherProfiles.AddOrUpdate(
                new tb_TeacherProfile
                {
                    NRIC = "S1000000G",
                    HeadIcon = "icon.png",
                    Name = "Teacher Account",
                    QuestionNo = 0,
                    AnswersNo = 0,
                });

            context.Invitations.AddOrUpdate(
                new tb_Invitation
                {
                    Id = 1,
                    Username = "201001A",
                    Code = "435A31BFF7C6BBC8"
                });

            context.Invitations.AddOrUpdate(
                new tb_Invitation
                {
                    Id = 2,
                    Username = "S1000000G",
                    Code = "7187E779485712E1"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop {
                    Id = 1,
                    Name = "Conquer the Web: The Ultimate Cybersecurity Guide",
                    Description = "Providing practical guidance on steps that readers can take to increase their online security, this book covers topics such as online fraud, cyber bullying and identity theft. It also includes cybersecurity measures for online activities such as online payments and usage of Wi-Fi",
                    Price = 5000,
                    School = "SIT",
                    Image = "is1.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 2,
                    Name = "Cybersecurity in Our Digital Lives: Protecting Our Future",
                    Description = "As cyber-attacks increase in scale and frequency, it is now more important than ever to understand the technology behind our daily digital interactions. This book is suitable for consumers of digital products and services to understand how and why hacks and breaches happen, and to learn ways to mitigate such risks.",
                    Price = 5000,
                    School = "SIT",
                    Image = "is2.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 3,
                    Name = "Cyber Insecurity: Navigating the Perils of the Next Information Age",
                    Description = "Growing dependence on the cyberspace in all aspects of our lives has left us vulnerable to a multitude of cybersecurity threats. This book offers readers information of the digital threats of tomorrow, and provides recommendations to help mitigate these threats.",
                    Price = 5000,
                    School = "SIT",
                    Image = "is3.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 4,
                    Name = "Accounting Made Simple – Accounting Explained in 100 Pages or Less",
                    Description = "this book makes things straight and simple with practical and straightforward examples that help sheds light on the concepts without the unnecessary jargon of the technicalities. The basic concepts of various topics are covered, like Accounting Equation and its significance, reading and preparing financial statements, calculation, and interpretation of several different financial ratios, the concepts, and assumptions behind GAAP. The accounting textbook is a quick read for the early beginners gripping them till the end as well as helping the novice to refresh their concepts. It basically gives a fast and systematic introduction to accounting concepts and is used for instance by business owners and students helping them to prepare for their accounting classes.",
                    Price = 5000,
                    School = "SBM",
                    Image = "af1.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 5,
                    Name = "Accounting All-in-One For Dummies ",
                    Description = "It offers a basic understanding of accounting practices and is relevant for anyone who handles money. Knowing how to balance the books and stay in the black is vital for keeping a business afloat or keeping your check book balanced. If you need to keep your books in order, this new edition of Accounting For Dummies helps you get a handle on all those columns of numbers.",
                    Price = 5000,
                    School = "SBM",
                    Image = "af2.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 6,
                    Name = "Warren Buffett Accounting Book: Reading Financial Statements for Value Investing Buffett Book Edition",
                    Description = "Buffett’s style of investing starts with fundamental analysis before it moves onto pure accounting research. This is the book aimed at enlightening investing professionals who have just set their foot into this industry. It is a treasure trove, as the book is to the point in explaining the requirements to analyse financial statements. There is no beating around the bush or unnecessary examples which will bog you down. It’s a textbook on investing that every fresher should invest in for his successful career in this profession.",
                    Price = 5000,
                    School = "SBM",
                    Image = "af3.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 7,
                    Name = "Industrial Light & Magic: The Art of Innovation",
                    Description = "The first chapters are cantered on the main changes in the visual effects arena after the team developed technologies for the Star Wars movie while the rest of the chapters highlight the challenges that the Industrial Light & Magic team faced while creating different movies, many of which became instant classics.",
                    Price = 5000,
                    School = "SIDM",
                    Image = "aasf1.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 8,
                    Name = "Acting for Animators: 4th Edition",
                    Description = "Ed Hooks, the bestselling author of Acting for Animators: 4th Edition, has been in the entertainment business for 30 years. The guidebook presents all the classical acting disciplines that Hooks used in his three-decade career in animation, explaining everything from character analysis and physical movement to facial expression and scene structure.",
                    Price = 5000,
                    School = "SIDM",
                    Image = "aasf2.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 9,
                    Name = "Illuminated Pixels: The Why, What, and How of Digital Lighting",
                    Description = "The book go beyond highlighting the properties of light in a theoretical sense. Illuminated Pixels seeks the answer to the why, what, and how of lighting. It outlines all the digital tools you could use to hone your lighting skills. It also shows how computer technology, artistry, and real-world physics could be combined to achieve the aesthetic intent of the image.  ",
                    Price = 5000,
                    School = "SIDM",
                    Image = "aasf3.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 10,
                    Name = "Intermediate Physics for Medicine and Biology",
                    Description = "This classic text has been used in over 20 countries by advanced undergraduate and beginning graduate students in biophysics, physiology, medical physics, neuroscience, and biomedical engineering. It bridges the gap between an introductory physics course and the application of physics to the life and biomedical sciences. ",
                    Price = 5000,
                    School = "SEG",
                    Image = "be1.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 11,
                    Name = "Biomedical Engineering Bridging Medicine and Technology",
                    Description = "The second edition of this popular introductory undergraduate textbook uses examples, applications, and profiles of biomedical engineers to show students the relevance of the theory and how it can be used to solve real problems in human medicine. The essential molecular biology, cellular biology, and human physiology background is included for students to understand the context in which biomedical engineers work.",
                    Price = 5000,
                    School = "SEG",
                    Image = "be2.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 12,
                    Name = "Molecular, Cellular, and Tissue Engineering",
                    Description = "Known as the bible of biomedical engineering, The Biomedical Engineering Handbook, Fourth Edition, sets the standard against which all other references of this nature are measured. As such, it has served as a major resource for both skilled professionals and novices to biomedical engineering",
                    Price = 5000,
                    School = "SEG",
                    Image = "be3.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 13,
                    Name = "Graphic Design: The New Basics: Second Edition, Revised and Expanded",
                    Description = "Our bestselling introduction to graphic design is now available in a revised and updated edition. In Graphic Design: The New Basics, bestselling author Ellen Lupton (Thinking with Type, Type on Screen) and design educator Jennifer Cole Phillips explain the key concepts of visual language that inform any work of design, from logo or letterhead to a complex website.",
                    Price = 5000,
                    School = "SDN",
                    Image = "vc1.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 14,
                    Name = "Creative Workshop: 80 Challenges to Sharpen Your Design Skills",
                    Description = "Have you ever struggled to complete a design project on time? Or felt that having a tight deadline stifled your capacity for maximum creativity? If so, then this book is for you.Within these pages, you’ll find 80 creative challenges that will help you achieve a breadth of stronger design solutions, in various media, within any set time period. Exercises range from creating a typeface in an hour to designing a paper robot in an afternoon to designing web pages and other interactive experiences. Each exercise includes compelling visual solutions from other designers and background stories to help you increase your capacity to innovate.",
                    Price = 5000,
                    School = "SDN",
                    Image = "vc2.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 15,
                    Name = "The Non-Designer’s Design Book",
                    Description = "For nearly 20 years, designers and non-designers alike have been introduced to the fundamental principles of great design by author Robin Williams. Through her straightforward and light-hearted style, Robin has taught hundreds of thousands of people how to make their designs look professional using four surprisingly simple principles. Now in its fourth edition, The Non-Designer’s Design Book offers even more practical design advice, including a new chapter on the fundamentals of typography, more quizzes and exercises to train your Designer Eye, updated projects for you to try, and new visual and typographic examples to inspire your creativity.",
                    Price = 5000,
                    School = "SDN",
                    Image = "vc3.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 16,
                    Name = "Biopharmaceutical Processing Development, Design, and Implementation of Manufacturing Processes",
                    Description = "Biopharmaceutical Processing: Development, Design, and Implementation of Manufacturing Processes covers bioprocessing from cell line development to bulk drug substances. The methods and strategies described are essential learning for every scientist, engineer or manager in the biopharmaceutical and vaccines industry.",
                    Price = 5000,
                    School = "SCLS",
                    Image = "bp1.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 17,
                    Name = "Fundamentals of Modern Bioprocessing",
                    Description = "Biological drug and vaccine manufacturing has quickly become one of the highest-value fields of bioprocess engineering, and many bioprocess engineers are now finding job opportunities that have traditionally gone to chemical engineers. Fundamentals of Modern Bioprocessing addresses this growing demand. Written by experts well-established in the field, this book connects the principles and applications of bioprocessing engineering to healthcare product manufacturing and expands on areas of opportunity for qualified bioprocess engineers and students.",
                    Price = 5000,
                    School = "SCLS",
                    Image = "bp2.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 18,
                    Name = "Process Technology Equipment and Systems",
                    Description = "Developed by the recognized authority in the field, PROCESS TECHNOLOGY EQUIPMENT AND SYSTEMS, 4e introduces you to the concepts and techniques used in today's most sophisticated manufacturing facilities. This book delivers technical accuracy along with an engaging writing style, and supports readings with full-color graphics and photos that show how systems and equipment operate in the real world. Chapters explore the workings of valves, vessels, and piping; pumps and compressors; motors and turbines; heat exchangers, cooling towers, boilers, and furnaces; reactors and distillation; extraction and separation systems; process instrumentation; and much more. Upholding the tradition of excellence established by the first two editions, PROCESS TECHNOLOGY EQUIPMENT AND SYSTEMS, 4e can help launch your career as a process technology technician!",
                    Price = 5000,
                    School = "SCLS",
                    Image = "bp3.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 19,
                    Name = "Med-Surg Success : A Q&A Review Applying Critical Thinking to Test Taking [With CDROM] ; 2010 Edition",
                    Description = "Assure your mastery of medical-surgical nursing knowledge while honing your critical thinking and test-taking skills. The 3rd Edition of this popular resource features over 2,300 questions (including 550 alternate-format questions) that reflect the latest advances in medical-surgical nursing and the latest NCLEX-RN® test plan. They organize the seemingly huge volume of information you must master into manageable sections divided by body systems and specific diseases",
                    Price = 5000,
                    School = "SHSS",
                    Image = "n1.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 20,
                    Name = "Fundamentals Success A Q&A Review Applying Critical Thinking to Test Taking",
                    Description = "Master the fundamentals of nursing while developing your critical thinking and test-taking skills. More than 1,340 classroom-tested, NCLEX-style questions—including more than 440 alternate-item-format questions—reflect the latest advances in medical technology as well as the most recent guidelines and standards of care for nursing practice.",
                    Price = 5000,
                    School = "SHSS",
                    Image = "n2.jpg"
                });

            context.Shops.AddOrUpdate(
                new tb_Shop
                {
                    Id = 21,
                    Name = "Mosby's Dictionary of Medicine, Nursing & Health Professions",
                    Description = "Make sense of the complex world of health care with Mosby's Dictionary of Medicine, Nursing & Health Professions, 10th Edition! This one-stop reference includes detailed entries that help you communicate more effectively with colleagues in various disciplines. With over 56,000 definitions, 2,450 photographs and line drawings, and supporting reference appendixes and atlases, it is an indispensable reference for students and professionals alike",
                    Price = 5000,
                    School = "SHSS",
                    Image = "n3.jpg"
                });

            context.Blogs.AddOrUpdate(
                new tb_Blog[5]
                {
                    new tb_Blog
                    {
                        Id = 1,
                        Title = "Brick-&-Mortar Travel Firm Finds its Way to Digitalisation",
                        Content = File.ReadAllText("../Migrations/Blog_1.txt"),
                        Poster = "LoveCordelia",
                        PostTime = DateTime.UtcNow,
                        Highlight = 0,
                        BGImage = "james3.jpg",
                        BGDefault = 0,
                        Tip = 0,
                        Favorite = 0
                    },
                    new tb_Blog
                    {
                        Id = 2,
                        Title = "How SMEs Can Get Help from Budget 2020 to Transform Businesses",
                        Content = File.ReadAllText("../Migrations/Blog_2.txt"),
                        Poster = "LoveCordelia",
                        PostTime = DateTime.UtcNow,
                        Highlight = 1,
                        BGImage = "cq5dam.jpg",
                        BGDefault = 0,
                        Tip = 0,
                        Favorite = 0
                    },
                    new tb_Blog
                    {
                        Id = 3,
                        Title = "Strong Headwinds but Sparks of Light in the F&B Sector",
                        Content = File.ReadAllText("../Migrations/Blog_3.txt"),
                        Poster = "S1000000G",
                        PostTime = DateTime.UtcNow,
                        Highlight = 1,
                        BGImage = "cq5dam2.jpg",
                        BGDefault = 0,
                        Tip = 0,
                        Favorite = 2
                    },
                    new tb_Blog
                    {
                        Id = 4,
                        Title = "Leveraging Budget 2020 for the Retail Sector",
                        Content = File.ReadAllText("../Migrations/Blog_4.txt"),
                        Poster = "201001A",
                        PostTime = DateTime.UtcNow,
                        Highlight = 1,
                        BGImage = "cq5da.jpg",
                        BGDefault = 0,
                        Tip = 0,
                        Favorite = 1
                    },
                    new tb_Blog
                    {
                        Id = 5,
                        Title = "The Resilience Budget - Easing the Cost Pressure on Hospitality & Tourism Sector",
                        Content = File.ReadAllText("../Migrations/Blog_5.txt"),
                        Poster = "201001A",
                        PostTime = DateTime.UtcNow,
                        Highlight = 0,
                        BGImage = "cq5dam1280.jpg",
                        BGDefault = 0,
                        Tip = 0,
                        Favorite = 1
                    }
                });

            context.Favourites.AddOrUpdate(
                new tb_Favourite[4]
                {
                    new tb_Favourite{
                        Id = 1,
                        BlogId = 3,
                        Username = "201001A"
                    },
                    new tb_Favourite
                    {
                        Id = 2,
                        BlogId = 5,
                        Username = "201001A"
                    },
                    new tb_Favourite{
                        Id = 3,
                        BlogId = 3,
                        Username = "S1000000G"
                    },
                    new tb_Favourite
                    {
                        Id = 4,
                        BlogId = 4,
                        Username = "S1000000G"
                    }
                });

            context.Orders.AddOrUpdate(
                new tb_Order[2]
                {
                    new tb_Order
                    {
                        Id = 1,
                        Username = "201001A",
                        Price = 15000,
                        PostTime = DateTime.Now
                    },
                    new tb_Order
                    {
                        Id = 2,
                        Username = "S1000000G",
                        Price = 20000,
                        PostTime = DateTime.Now
                    }
                });

            context.Invoices.AddOrUpdate(
                new tb_Invoice[6]
                {
                    new tb_Invoice
                    {
                        Id = 1,
                        OrderId = 1,
                        BookId = 1,
                        Quantity = 1
                    },
                    new tb_Invoice
                    {
                        Id = 2,
                        OrderId = 1,
                        BookId = 3,
                        Quantity = 2
                    },
                    new tb_Invoice
                    {
                        Id = 3,
                        OrderId = 2,
                        BookId = 5,
                        Quantity = 1
                    },
                    new tb_Invoice
                    {
                        Id = 4,
                        OrderId = 2,
                        BookId = 6,
                        Quantity = 1
                    },
                    new tb_Invoice
                    {
                        Id = 5,
                        OrderId = 2,
                        BookId = 7,
                        Quantity = 1
                    },
                    new tb_Invoice
                    {
                        Id = 6,
                        OrderId = 2,
                        BookId = 8,
                        Quantity = 1
                    }
                });

            context.CreditRecords.AddOrUpdate(
                new tb_CreditRecord[5]
                {
                    new tb_CreditRecord
                    {
                        Id = 1,
                        Username = "S1000000G",
                        Act = "Add",
                        CreditValue = 10000,
                        OccurTime = DateTime.Now
                    },
                    new tb_CreditRecord
                    {
                        Id = 2,
                        Username = "S1000000G",
                        Act = "Minus",
                        CreditValue = 20000,
                        OccurTime = DateTime.Now
                    },
                    new tb_CreditRecord
                    {
                        Id = 3,
                        Username = "LoveCordelia",
                        Act = "Add",
                        CreditValue = 100000,
                        OccurTime = DateTime.Now
                    },
                    new tb_CreditRecord
                    {
                        Id = 4,
                        Username = "201001A",
                        Act = "Add",
                        CreditValue = 1000,
                        OccurTime = DateTime.Now
                    },
                    new tb_CreditRecord
                    {
                        Id = 5,
                        Username = "201001A",
                        Act = "Minus",
                        CreditValue = 15000,
                        OccurTime = DateTime.Now
                    }
                });

            context.Notifications.AddOrUpdate(
                new tb_Notification[3]
                {
                    new tb_Notification
                    {
                        Id = 1,
                        ViewBool = 0,
                        PostTime = DateTime.Now,
                        Type = "Welcome to NYP Journey",
                        Url = "~/index.aspx",
                        Username = "201001A"
                    },
                    new tb_Notification
                    {
                        Id = 2,
                        ViewBool = 0,
                        PostTime = DateTime.Now,
                        Type = "Welcome to NYP Journey",
                        Url = "~/index.aspx",
                        Username = "S1000000G"
                    },
                    new tb_Notification
                    {
                        Id = 3,
                        ViewBool = 0,
                        PostTime = DateTime.Now,
                        Type = "Welcome to NYP Journey",
                        Url = "~/index.aspx",
                        Username = "LoveCordelia"
                    }
                });

            context.Questions.AddOrUpdate(
                new tb_Question[3]
                {
                    new tb_Question
                    {
                        Id = 1,
                        Title = "What are the Minimum Entry Requirements for admission to CET courses",
                        Content = "I really want to CET courses but my grades are quite decent.",
                        PostTime = DateTime.Now,
                        LastUpdate = DateTime.Now,
                        Username = "201001A",
                        SchoolType = "SIT",
                        State = "Solved",
                        CreditReward = 50,
                        Review = 1
                    },
                    new tb_Question
                    {
                        Id = 2,
                        Title = "What is the intake for SEG Diplomas and what is the cut-off point for this year?",
                        Content = "I am currently studying in secondary 4 and considering to apply for SEG",
                        PostTime = DateTime.Now,
                        LastUpdate = DateTime.Now,
                        Username = "201001A",
                        SchoolType = "SEG",
                        State = "Not Solved",
                        CreditReward = 50,
                        Review = 1
                    },
                    new tb_Question
                    {
                        Id = 3,
                        Title = "I have problem with Blackboard/Polymall login.",
                        Content = "I am a current student of the School of Information Technology. I have problem with Blackboard/Polymall login. What can I do?",
                        PostTime = DateTime.Now,
                        LastUpdate = DateTime.Now,
                        Username = "201001A",
                        SchoolType = "SIT",
                        State = "Solved",
                        CreditReward = 50,
                        Review = 1
                    }
                });

            context.Answers.AddOrUpdate(
                new tb_Answer[4]
                {
                    new tb_Answer
                    {
                        Id = 1,
                        Content = File.ReadAllText("../Migrations/Answer.txt"),
                        QuestionCode = 1,
                        Username = "S1000000G",
                        BestSelected = 1,
                        PostTime = DateTime.Now,
                        UpVote = 0
                    },
                    new tb_Answer
                    {
                        Id = 2,
                        Content = "You can resolve the problem by following the steps in NYP BB PolyMall Admin PDF",
                        QuestionCode = 2,
                        Username = "S1000000G",
                        BestSelected = 0,
                        PostTime = DateTime.Now,
                        UpVote = 0,
                    },
                    new tb_Answer
                    {
                        Id = 3,
                        Content = "You can find the latest information on the Intake & JAE ELR2B2 Points from our website http://www.nyp.edu.sg/admissions/full-time-diploma/admission-exercise.htmlPlease use the published JAE ELR2B2 (Last Aggregate Score) as a guide only.",
                        QuestionCode = 2,
                        Username = "S1000000G",
                        BestSelected = 0,
                        PostTime = DateTime.Now,
                        UpVote = 0,
                    },
                    new tb_Answer
                    {
                        Id = 4,
                        Content = "You can resolve the problem by following the steps in NYP BB PolyMall Admin PDF",
                        QuestionCode = 3,
                        Username = "S1000000G",
                        BestSelected = 1,
                        PostTime = DateTime.Now,
                        UpVote = 0,
                    }
                });

            context.Comments.AddOrUpdate(
                new tb_Comment[4]
                {
                    new tb_Comment
                    {
                        Id = 1,
                        Poster = "LoveCordelia",
                        Username = "S1000000G",
                        PostTime = DateTime.Now,
                        Content = "He is a admirable teacher with good content provide to student!"
                    },
                    new tb_Comment
                    {
                        Id = 2,
                        Poster = "S1000000G",
                        Username = "201001A",
                        PostTime = DateTime.Now,
                        Content = "A sincere student!"
                    },
                    new tb_Comment
                    {
                        Id = 3,
                        Poster = "201001A",
                        Username = "S1000000G",
                        PostTime = DateTime.Now,
                        Content = "A great professor!"
                    },
                    new tb_Comment
                    {
                        Id = 4,
                        Poster = "S1000000G",
                        Username = "LoveCordelia",
                        PostTime = DateTime.Now,
                        Content = "Always on duty, good work!"
                    }
                });

            context.SaveChanges();
                //  You can use the DbSet<T>.AddOrUpdate() helper extension method
                //  to avoid creating duplicate seed data.
        }
    }
}
