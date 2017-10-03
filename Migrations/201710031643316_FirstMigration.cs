namespace ShaulisBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "postID" });
            CreateIndex("dbo.Comments", "PostID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "PostID" });
            CreateIndex("dbo.Comments", "postID");
        }
    }
}
