using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VasVas.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT [Security].[users] ([Id], [Email], [PasswordHash], [PhoneNumber], [CompanyName], [ConnectionPointName], [SmsIdName], [AccessFailedCount], [ConcurrencyStamp], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'048dbee3-c213-4702-93c8-0e57cb397526', N'admin1@test.com', N'AQAAAAEAACcQAAAAEI/8rObln4d85rkSD6Rhz4i4qkoS4NdJVFVnOHVV2DFxjyB/xFCILcx2lP8bDBV6jg==', N'213123', N'adammm', N'mmmmmdsf', N'ggggg', 0, N'3ef66f5a-629e-43ac-aef0-b5ef46f80dd6', 1, 1, NULL, N'ADMIN1@TEST.COM', N'ADMIN1@TEST.COM', 0, N'SGN26FEYKLIGYO27TMLL35AOUEIZV5AT', 0, N'admin1@test.com')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Security].[Users] WHERE Id = '048dbee3-c213-4702-93c8-0e57cb397526'");

        }
    }
}
