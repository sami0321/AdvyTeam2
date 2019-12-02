namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ask : DbMigration
    {
        public override void Up()
        {
            AddColumn("hr.employee", "AdressMail", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("hr.employee", "AdressMail");
        }
    }
}
