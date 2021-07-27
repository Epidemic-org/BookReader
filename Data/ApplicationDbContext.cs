using BookReader.Data.Models;
using BookReader.Data.Models.Map;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReader.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public virtual DbSet<Campaingn> Campaigns { get; set; }
        public virtual DbSet<CampaignItem> CampaignItems { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentLike> CommentLikes { get; set; }
        public virtual DbSet<CreditType> CreditTypes { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<FieldValue> FieldValues { get; set; }
        public virtual DbSet<FormAction> FormActions { get; set; }
        public virtual DbSet<Gift> Gifts { get; set; }
        public virtual DbSet<GroupField> GroupFields { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<InvoicePayment> InvoicePayments { get; set; }
        public virtual DbSet<InvoiceTerm> InvoiceTerms { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Permit> Permits { get; set; }
        public virtual DbSet<PermitGeneration> PermitGenerations { get; set; }
        public virtual DbSet<PermitUser> PermitUsers { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<ProductAuthor> ProductAuthors { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCategoryField> ProductCategoryFields { get; set; }
        public virtual DbSet<ProductDownload> ProductDownloads { get; set; }
        public virtual DbSet<ProductFieldValue> ProductFieldValues { get; set; }
        public virtual DbSet<ProductFile> ProductFiles { get; set; }
        public virtual DbSet<ProductFileNarrator> ProductFileNarrators { get; set; }
        public virtual DbSet<ProductPlay> ProductPlays { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<ProductPublisher> ProductPublishers { get; set; }
        public virtual DbSet<ProductRate> ProductRates { get; set; }
        public virtual DbSet<ProductRelation> ProductRelations { get; set; }
        public virtual DbSet<ProductTranslator> ProductTranslators { get; set; }
        public virtual DbSet<ProductVisit> ProductVisits { get; set; }
        public virtual DbSet<RequestMoney> RequestMoneys { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<ScoreLog> ScoreLogs { get; set; }
        public virtual DbSet<ScoreType> ScoreTypes { get; set; }
        public virtual DbSet<ScoreTypeItem> ScoreTypeItems { get; set; }
        public virtual DbSet<Shelves> Shelves { get; set; }
        public virtual DbSet<SubscriptionInvoice> SubscriptionInvoices { get; set; }
        public virtual DbSet<SubscriptionInvoiceItem> SubscriptionInvoiceItems { get; set; }
        public virtual DbSet<SubscriptionInvoicePayment> SubscriptionInvoicePayments { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public virtual DbSet<SubscriptionTypeItem> SubscriptionTypeItems { get; set; }
        public virtual DbSet<TermType> TermTypes { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketMessage> TicketMessages { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<UserFavorites> UserFavorites { get; set; }
        public virtual DbSet<UserLogs> UserLogs { get; set; }
        public virtual DbSet<UserShelves> UserShelves { get; set; }
        public virtual DbSet<WalletLog> WalletLogs { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Product>(new ProductMap());
            builder.ApplyConfiguration<ProductCategory>(new ProductCategoryMap());
            builder.ApplyConfiguration<CampaignItem>(new CampaignItemMap());
            builder.ApplyConfiguration<Campaingn>(new CampaingnMap());
            builder.ApplyConfiguration<Comment>(new CommentMap());
            builder.ApplyConfiguration<CommentLike>(new CommentLikeMap());
            builder.ApplyConfiguration<CreditType>(new CreditTypeMap());
            builder.ApplyConfiguration<Field>(new FieldMap());


            base.OnModelCreating(builder);
        }
    }
}
