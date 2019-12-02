namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oooooooo : DbMigration
    {
        public override void Up()
        {
            AddColumn("hr.competence", "description_c", c => c.String(maxLength: 255, unicode: false));
            AddColumn("hr.competence", "nom_c", c => c.String(maxLength: 255, unicode: false));
            DropColumn("hr.competence", "descriptionc");
            DropColumn("hr.competence", "nomc");
        }
        
        public override void Down()
        {
            AddColumn("hr.competence", "nomc", c => c.String(maxLength: 255, unicode: false));
            AddColumn("hr.competence", "descriptionc", c => c.String(maxLength: 255, unicode: false));
            DropColumn("hr.competence", "nom_c");
            DropColumn("hr.competence", "description_c");
        }
    }
}
