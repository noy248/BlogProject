namespace ShaulisBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        postID = c.Int(nullable: false),
                        commenter = c.String(),
                        commenterSiteAddr = c.String(),
                        text = c.String(),
                        commentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.postID, cascadeDelete: true)
                .Index(t => t.postID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        author = c.String(),
                        authorSiteAddr = c.String(),
                        postDate = c.DateTime(nullable: false),
                        postText = c.String(),
                        Photos = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        gender = c.String(),
                        birthDate = c.DateTime(nullable: false),
                        clubSeniority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "postID", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "postID" });
            DropTable("dbo.Fans");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
