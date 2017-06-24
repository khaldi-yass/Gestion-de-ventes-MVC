namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class MainContext : DbContext
    {
        // Your context has been configured to use a 'Models' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MVC.Models.Models' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Models' 
        // connection string in the application configuration file.
        public MainContext()
            : base("name=Models")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Client>    Clients { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Article>   Articles { get; set; }
        public virtual DbSet<Commande>  Commandes { get; set; }

    }

    public class Client
    {
        public Client()
        {
            this.Commandes = new HashSet<Commande>();
        }

        [Key]
        [Column("NumClient")]
        public int Id { get; set; }

        [Column("login")]
        [Required]
        public string Login { get; set; }

        [Required]
        [Column("MotPasse")]
        public string Password { get; set; }

        [Required]
        [Column("Nom")]
        public string Name { get; set; }

        [Required]
        [Column("Prenom")]
        public string LastName { get; set; }

        [Required]
        [Column("tel")]
        public string Phone { get; set; }

        [Required]
        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [Column("Ville")]
        public string Town { get; set; }

        public ICollection<Commande> Commandes { get; set; }
    }

    public class Categorie
    {
        public Categorie()
        {
            this.Articles = new HashSet<Article>();
        }

        [Key]
        [Column("RefCat")]
        public int Reference { get; set; }

        [Required]
        [Column("Nomcatg")]
        public string Name { get; set; }

        public ICollection<Article> Articles { get; set; }
    }

    public class Article
    {
        public Article()
        {
            this.Commandes = new HashSet<Commande>();
        }

        [Key]
        [Column("NumArticle")]
        public int Number { get; set; }

        [Required]
        [Column("Designation")]
        public string Designation { get; set; }

        [Required]
        [Column("PrixU")]
        public int PricePerUnit { get; set; }

        [Required]
        [Column("stock")]
        public string Stock { get; set; }

        [Column("photo")]
        public string Photo { get; set; }

        [Required]
        [Column("RefCat")]
        public int CategorieReference { get; set; }

        [ForeignKey("CategorieReference")]
        public Categorie Category { get; set; }

        public ICollection<Commande> Commandes;
    }

    public class Commande
    {
        [Key]
        [Column("NumCmd")]
        public int Number { get; set; }

        [Required]
        [Column("DateCmd")]
        public DateTime Date { get; set; }

        [Column("NumClient")]
        public int NumberClient { get; set; }

        [Required]
        [ForeignKey("NumberClient")]
        public Client Client { get; set; }

        [Column("NumArticle")]
        public int NumberArticle { get; set; }

        [Required]
        [ForeignKey("NumberArticle")]
        public Article Article { get; set; }

        [Required]
        [Column("QteArticle")]
        public int QteArticle { get; set; }
    }

}