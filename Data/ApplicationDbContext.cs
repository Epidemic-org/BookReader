using BookReader.Data.Models;
using BookReader.Data.Models.Map;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReader.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole,
        AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }
        public virtual DbSet<Product> Products { get; set; }
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
        public virtual DbSet<vwProduct> vwProducts { get; set; }
        public virtual DbSet<vwUserInvoices> vwUserInvoices { get; set; }




        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration<Product>(new ProductMap());
            builder.ApplyConfiguration<vwProduct>(new vwProductMap());
            builder.ApplyConfiguration<ProductCategory>(new ProductCategoryMap());
            builder.ApplyConfiguration<CampaignItem>(new CampaignItemMap());
            builder.ApplyConfiguration<Campaingn>(new CampaingnMap());
            builder.ApplyConfiguration<Comment>(new CommentMap());
            builder.ApplyConfiguration<CommentLike>(new CommentLikeMap());
            builder.ApplyConfiguration<CreditType>(new CreditTypeMap());
            builder.ApplyConfiguration<Field>(new FieldMap());
            builder.ApplyConfiguration<Order>(new OrderMap());
            builder.ApplyConfiguration<OrderItem>(new OrderItemMap());
            builder.ApplyConfiguration<PermitGeneration>(new PermitGenerationMap());
            builder.ApplyConfiguration<Permit>(new PermitMap());
            builder.ApplyConfiguration<PermitUser>(new PermitUserMap());
            builder.ApplyConfiguration<Person>(new PersonMap());
            builder.ApplyConfiguration<ProductAuthor>(new ProductAuthorMap());
            builder.ApplyConfiguration<ProductCategoryField>(new ProductCategoryFieldMap());
            builder.ApplyConfiguration<ProductCategory>(new ProductCategoryMap());
            builder.ApplyConfiguration<ProductDownload>(new ProductDownloadMap());
            builder.ApplyConfiguration<ProductFieldValue>(new ProductFieldValueMap());
            builder.ApplyConfiguration<ProductFile>(new ProductFileMap());
            builder.ApplyConfiguration<ProductFileNarrator>(new ProductFileNarratorMap());
            builder.ApplyConfiguration<ProductPlay>(new ProductPlayMap());
            builder.ApplyConfiguration<ProductPrice>(new ProductPriceMap());
            builder.ApplyConfiguration<ProductPrice>(new ProductPriceMap());
            builder.ApplyConfiguration(new ProductPublisherMap());
            builder.ApplyConfiguration(new ProductRateMap());
            builder.ApplyConfiguration(new ProductRelationMap());
            builder.ApplyConfiguration(new ProductTranslatorMap());
            builder.ApplyConfiguration(new ProductVisitMap());
            builder.ApplyConfiguration<FieldValue>(new FieldValueMap());
            builder.ApplyConfiguration<FormAction>(new FormActionMap());
            builder.ApplyConfiguration<Gift>(new GiftMap());
            builder.ApplyConfiguration<GroupField>(new GroupFieldMap());
            builder.ApplyConfiguration<Invoice>(new InvoiceMap());
            builder.ApplyConfiguration<InvoicePayment>(new InvoicePaymentMap());
            builder.ApplyConfiguration<InvoiceTerm>(new InvoiceTermMap());
            builder.ApplyConfiguration<RequestMoney>(new RequestMoneyMap());
            builder.ApplyConfiguration<RolePermission>(new RolePermissionMap());
            builder.ApplyConfiguration<ScoreLog>(new ScoreLogMap());
            builder.ApplyConfiguration<ScoreType>(new ScoreTypeMap());
            builder.ApplyConfiguration<ScoreTypeItem>(new ScoreTypeItemMap());
            builder.ApplyConfiguration<Shelves>(new ShelvesMap());
            builder.ApplyConfiguration<SubscriptionInvoice>(new SubscriptionInvoiceMap());
            builder.ApplyConfiguration<SubscriptionInvoiceItem>(new SubscriptionInvoiceItemMap());
            builder.ApplyConfiguration<SubscriptionInvoicePayment>(new SubscriptionInvoicePaymentMap());
            builder.ApplyConfiguration<SubscriptionType>(new SubscriptionTypeMap());
            builder.ApplyConfiguration<SubscriptionTypeItem>(new SubscriptionTypeItemMap());
            builder.ApplyConfiguration<TermType>(new TermTypeMap());
            builder.ApplyConfiguration(new TicketMap());
            builder.ApplyConfiguration(new TicketMessageMap());
            builder.ApplyConfiguration(new TransactionMap());
            builder.ApplyConfiguration(new UserFavoiteMap());
            builder.ApplyConfiguration(new UserLogMap());
            builder.ApplyConfiguration(new UserShelveMap());
            builder.ApplyConfiguration(new WalletMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration<vwUserInvoices>(new vwUserInvoicesMap());
            base.OnModelCreating(builder);
        }
    }
}
