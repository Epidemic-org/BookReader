using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public Guid SecurityStamp { get; set; }
        public Guid ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }


        public ICollection<Campaingn> Campaingns { get; set; }
        public ICollection<CommentLikes> CommentLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CreditType> CreditTypes { get; set; }
        public ICollection<Field> Fields { get; set; }
        public ICollection<Gift> GiftGivers { get; set; }
        public ICollection<Gift> GiftRecipients { get; set; }
        public ICollection<GroupField> GroupFields { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<People> Peoples { get; set; }
        public ICollection<PermitGeneration> PermitGenerations { get; set; }
        public ICollection<Permit> Permits { get; set; }
        public ICollection<PermitUser> PermitUsers { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ProductDownload> ProductDownloads { get; set; }
        public ICollection<ProductPlay> ProductPlays { get; set; }
        public ICollection<ProductPrice> ProductPrices{ get; set; }
        public ICollection<ProductRate> ProductRates{ get; set; }
        public ICollection<ProductVisit> ProductVisits{ get; set; }
        public ICollection<Product> Products{ get; set; }
        public ICollection<RequestMoney> RequestMoneys{ get; set; }
        public ICollection<ScoreLog> ScoreLogs{ get; set; }
        public ICollection<ScoreType> ScoreType { get; set; }
        public ICollection<Shelves> Shelves { get; set; }
        public ICollection<SubscriptionInvoice> SubscriptionInvoices { get; set; }
        public ICollection<SubscriptionType> SubscriptionTypes { get; set; }
        public ICollection<SubscriptionType> SubscriptionTypeItems { get; set; }
        public ICollection<TermType> TermTypes { get; set; }
        public ICollection<TicketMessage> TicketMessages { get; set; }
        public ICollection<UserClaim> UserClaims{ get; set; }
        public ICollection<UserFavorites> UserFavorites{ get; set; }


    }
}
