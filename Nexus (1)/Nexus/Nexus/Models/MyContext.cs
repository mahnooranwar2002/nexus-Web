using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Nexus.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> Options) : base(Options)
        {

        }
       /*admin table*/
       public DbSet<Admin> tbl_adminsrecords { get; set; }
       
        /*user table*/
        public DbSet<user> tbl_Users { get; set; }  
        /*Retail Shop*/
        public DbSet<retailshop> tbl_retail_stores { get; set; }
        public DbSet<Products> tbl_products { get; set; }
     

        /*for product and foreign key*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            /*for the postion and emplyomee*/
           
            modelBuilder.Entity<employee>()
                .HasOne(e => e.positions)
                .WithMany(p => p.employees)
                .HasForeignKey(p => p.Position_id);


            /*for the products and vendor*/
           
            modelBuilder.Entity<Products>().
                           HasOne(p => p.vendors).
                           WithMany(v => v.products).
                           HasForeignKey(p => p.Vendor_Id);

            /*for the plan Subcribed and product*/

            modelBuilder.Entity<plansubcribed>().
                HasOne(p => p.productdetails).
                WithMany(e => e.planSubdetails).
                HasForeignKey(p=>p.products_id);

            /*for the product and schemes */

            modelBuilder.Entity<schemesubcribed>().
                HasOne(p => p.product).
                WithMany(p => p.schemesDetails).
                HasForeignKey(p => p.product_id);

           /*for the  outlet schmes and product */
            modelBuilder.Entity<schemesOutlet>().
                HasOne(p => p.product).
                WithMany(p => p.SchemesOutlets).
                HasForeignKey(p => p.Product_ID);

            /* for the  outlet schmes and main schemes */

            modelBuilder.Entity<schemesOutlet>().HasOne(p => p.schemes).
                WithMany(p => p.schmesdata)
                .HasForeignKey(p => p.Scheme_Id);

            /*for the main plans and plan by outlet worker*/
            modelBuilder.Entity<planOutlet>().HasOne(p => p.plans)
                .WithMany(p => p.plandetails).
                HasForeignKey(p => p.Plan_Id);
            /*for the  product and plan by outlet worker*/
            modelBuilder.Entity<planOutlet>().HasOne(p => p.product)
                .WithMany(p => p.productDetail).
                HasForeignKey(p => p.Product_ID);
        }
        /*position and employee*/
        public DbSet<positions> tbl_positions { get; set; }
        public DbSet<employee> tbl_employees { get; set; }
        /*for plans*/
       public DbSet<plan> tbl_plans { get; set; }

        public DbSet<plansubcribed> tbl_plansubcribed { get; set; }
        public DbSet<contact> tbl_contact { get; set; }
        public DbSet <faq> tbl_faq { get; set; }
        public DbSet<vendor> tbl_vendors { get; set; }
       public DbSet<scheme> tbl_schemes { get; set; }
        public DbSet<schemesubcribed> tbl_schemesubcribed { get; set; }
        public DbSet<feedback> tbl_feedback { get; set; }
        public DbSet<schemesOutlet> tbl_bookedschemes { get; set; } 
        public DbSet<planOutlet> tbl_bookedplans { get; set; }
    }
}
