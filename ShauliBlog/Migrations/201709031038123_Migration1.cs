namespace ShauliBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentTextContent", c => c.String());
            DropColumn("dbo.Comments", "PostTextContent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "PostTextContent", c => c.String());
            DropColumn("dbo.Comments", "CommentTextContent");
        }
    }
}
