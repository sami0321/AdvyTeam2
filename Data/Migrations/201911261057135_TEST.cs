namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TEST : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "hr.answer",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        juste = c.Boolean(nullable: false),
                        type_reponse = c.String(maxLength: 255, unicode: false),
                        question_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("hr.question", t => t.question_id)
                .Index(t => t.question_id);
            
            CreateTable(
                "hr.question",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        complexity = c.String(maxLength: 255, unicode: false),
                        enonce = c.String(maxLength: 255, unicode: false),
                        indice = c.String(maxLength: 255, unicode: false),
                        point = c.Double(nullable: false),
                        reponsejuste = c.String(maxLength: 255, unicode: false),
                        type = c.String(maxLength: 255, unicode: false),
                        topic_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("hr.topic", t => t.topic_id)
                .Index(t => t.topic_id);
            
            CreateTable(
                "hr.topic",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dureeTopic = c.Int(nullable: false),
                        image = c.String(maxLength: 255, unicode: false),
                        nom = c.String(maxLength: 255, unicode: false),
                        nombre_question = c.Int(nullable: false),
                        domain_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("hr.domain", t => t.domain_id)
                .Index(t => t.domain_id);
            
            CreateTable(
                "hr.domain",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, unicode: false),
                        type = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "hr.reclamation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date_creation = c.DateTime(),
                        date_traitement = c.DateTime(),
                        description = c.String(maxLength: 255, unicode: false),
                        etat = c.String(maxLength: 255, unicode: false),
                        image = c.String(maxLength: 255, unicode: false),
                        objet = c.String(maxLength: 255, unicode: false),
                        candidate_id = c.Long(),
                        topic_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("hr.user", t => t.candidate_id)
                .ForeignKey("hr.topic", t => t.topic_id)
                .Index(t => t.candidate_id)
                .Index(t => t.topic_id);
            
            CreateTable(
                "hr.user",
                c => new
                    {
                        id = c.Long(nullable: false),
                        actif = c.Boolean(nullable: false),
                        birthDate = c.DateTime(storeType: "date"),
                        cin = c.String(maxLength: 255, unicode: false),
                        contrat_type = c.String(maxLength: 255, unicode: false),
                        email = c.String(maxLength: 255, unicode: false),
                        firstName = c.String(maxLength: 255, unicode: false),
                        lastName = c.String(maxLength: 255, unicode: false),
                        password = c.String(maxLength: 255, unicode: false),
                        phoneNumber = c.String(maxLength: 255, unicode: false),
                        role = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "hr.result",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(storeType: "date"),
                        result = c.String(maxLength: 255, unicode: false),
                        score = c.Double(nullable: false),
                        statut = c.String(maxLength: 255, unicode: false),
                        idcandidate = c.Long(),
                        idtopic = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("hr.user", t => t.idcandidate)
                .ForeignKey("hr.topic", t => t.idtopic)
                .Index(t => t.idcandidate)
                .Index(t => t.idtopic);
            
            CreateTable(
                "hr.competence",
                c => new
                    {
                        id_c = c.Int(nullable: false, identity: true),
                        description_c = c.String(maxLength: 255, unicode: false),
                        Famille = c.String(maxLength: 255, unicode: false),
                        niveau = c.Int(),
                        nom_c = c.String(maxLength: 255, unicode: false),
                        metier = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.id_c);
            
            CreateTable(
                "hr.referencecompetence",
                c => new
                    {
                        id_cf = c.Int(nullable: false, identity: true),
                        description_c = c.String(maxLength: 255, unicode: false),
                        niveauAcquis = c.Int(),
                        competence_id_c = c.Int(),
                        employee_U_ID = c.Int(),
                    })
                .PrimaryKey(t => t.id_cf)
                .ForeignKey("hr.employee", t => t.employee_U_ID)
                .ForeignKey("hr.competence", t => t.competence_id_c)
                .Index(t => t.competence_id_c)
                .Index(t => t.employee_U_ID);
            
            CreateTable(
                "hr.employee",
                c => new
                    {
                        U_ID = c.Int(nullable: false, identity: true),
                        U_Cin = c.Long(),
                        U_FirstName = c.String(maxLength: 255, unicode: false),
                        U_LastName = c.String(maxLength: 255, unicode: false),
                        U_PASSSWORD = c.String(maxLength: 255, unicode: false),
                        U_NAME = c.String(maxLength: 255, unicode: false),
                        U_PhoneNumber = c.Long(),
                        U_Role = c.String(maxLength: 255, unicode: false),
                        ficheMetier_id_f = c.Int(),
                    })
                .PrimaryKey(t => t.U_ID)
                .ForeignKey("hr.fichemetier", t => t.ficheMetier_id_f)
                .Index(t => t.ficheMetier_id_f);
            
            CreateTable(
                "hr.fichemetier",
                c => new
                    {
                        id_f = c.Int(nullable: false, identity: true),
                        description_f = c.String(maxLength: 255, unicode: false),
                        F_Famille_Competence = c.String(maxLength: 255, unicode: false),
                        nom_f = c.String(maxLength: 255, unicode: false),
                        Employee_U_ID = c.Int(),
                    })
                .PrimaryKey(t => t.id_f)
                .ForeignKey("hr.employee", t => t.Employee_U_ID)
                .Index(t => t.Employee_U_ID);
            
            CreateTable(
                "hr.quiz",
                c => new
                    {
                        id_q = c.Int(nullable: false, identity: true),
                        ReferenceCompetence_id_cf = c.Int(),
                    })
                .PrimaryKey(t => t.id_q)
                .ForeignKey("hr.referencecompetence", t => t.ReferenceCompetence_id_cf)
                .Index(t => t.ReferenceCompetence_id_cf);
            
        }
        
        public override void Down()
        {
            DropForeignKey("hr.referencecompetence", "competence_id_c", "hr.competence");
            DropForeignKey("hr.quiz", "ReferenceCompetence_id_cf", "hr.referencecompetence");
            DropForeignKey("hr.referencecompetence", "employee_U_ID", "hr.employee");
            DropForeignKey("hr.fichemetier", "Employee_U_ID", "hr.employee");
            DropForeignKey("hr.employee", "ficheMetier_id_f", "hr.fichemetier");
            DropForeignKey("hr.result", "idtopic", "hr.topic");
            DropForeignKey("hr.reclamation", "topic_id", "hr.topic");
            DropForeignKey("hr.result", "idcandidate", "hr.user");
            DropForeignKey("hr.reclamation", "candidate_id", "hr.user");
            DropForeignKey("hr.question", "topic_id", "hr.topic");
            DropForeignKey("hr.topic", "domain_id", "hr.domain");
            DropForeignKey("hr.answer", "question_id", "hr.question");
            DropIndex("hr.quiz", new[] { "ReferenceCompetence_id_cf" });
            DropIndex("hr.fichemetier", new[] { "Employee_U_ID" });
            DropIndex("hr.employee", new[] { "ficheMetier_id_f" });
            DropIndex("hr.referencecompetence", new[] { "employee_U_ID" });
            DropIndex("hr.referencecompetence", new[] { "competence_id_c" });
            DropIndex("hr.result", new[] { "idtopic" });
            DropIndex("hr.result", new[] { "idcandidate" });
            DropIndex("hr.reclamation", new[] { "topic_id" });
            DropIndex("hr.reclamation", new[] { "candidate_id" });
            DropIndex("hr.topic", new[] { "domain_id" });
            DropIndex("hr.question", new[] { "topic_id" });
            DropIndex("hr.answer", new[] { "question_id" });
            DropTable("hr.quiz");
            DropTable("hr.fichemetier");
            DropTable("hr.employee");
            DropTable("hr.referencecompetence");
            DropTable("hr.competence");
            DropTable("hr.result");
            DropTable("hr.user");
            DropTable("hr.reclamation");
            DropTable("hr.domain");
            DropTable("hr.topic");
            DropTable("hr.question");
            DropTable("hr.answer");
        }
    }
}
