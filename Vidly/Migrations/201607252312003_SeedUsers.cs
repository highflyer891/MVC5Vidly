namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'541ed35f-7d27-4eb4-998a-eec7a99f999c', N'admin@vidly.com', 0, N'AF0RJCm7ruok5fGt2JVl5E6Pprk7K9WCwcUyyivRKtcIK36dIzoOzeGuUlhDNSTosQ==', N'819a6ab0-9513-4355-87b1-f1dc1959c352', NULL, 0, 0, NULL, 1, 0, N'admin1@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab42a9f8-1180-482e-95ff-e3c713329d61', N'guest@vidly.com', 0, N'ABcDwkUlQeh8wE0Gt/jZl2bIkEbiNWh4G1WSjzjM6KPKuPOTSZODK6o4DM8nAtSy+A==', N'a45a440e-2266-468f-a1d7-6851d53b9af9', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                   
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'470a55e7-d90f-4522-92cd-c3c9bde82f11', N'CanManageMovies')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'541ed35f-7d27-4eb4-998a-eec7a99f999c', N'470a55e7-d90f-4522-92cd-c3c9bde82f11')
");
        }
        
        public override void Down()
        {
        }
    }
}
