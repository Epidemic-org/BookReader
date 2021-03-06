using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class AppUser : IdentityUser<int>
    {
        
        public bool IsActive { get; set; }
        public Person Person { get; set; }

        public ICollection<Campaingn> Campaingns { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CreditType> CreditTypes { get; set; }
        public ICollection<Field> Fields { get; set; }
        public ICollection<Gift> GiftGivers { get; set; }
        public ICollection<Gift> GiftRecipients { get; set; }
        public ICollection<GroupField> GroupFields { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Order> Orders { get; set; }
        
        public ICollection<PermitGeneration> PermitGenerations { get; set; }
        public ICollection<Permit> Permits { get; set; }
        public ICollection<PermitUser> PermitUsers { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ProductDownload> ProductDownloads { get; set; }
        public ICollection<ProductPlay> ProductPlays { get; set; }
        public ICollection<ProductPrice> ProductPrices{ get; set; }
        public ICollection<ProductRate> ProductRates{ get; set; }
        public ICollection<ProductVisit> ProductVisits{ get; set; }
        public ICollection<Product> UserProducts{ get; set; }
        public ICollection<Product> AdminProducts{ get; set; }
        public ICollection<RequestMoney> RequestMoneys{ get; set; }
        public ICollection<ScoreLog> ScoreLogs{ get; set; }
        public ICollection<ScoreType> ScoreTypes { get; set; }
        public ICollection<Shelves> Shelves { get; set; }
        public ICollection<SubscriptionInvoice> SubscriptionInvoices { get; set; }
        public ICollection<SubscriptionType> SubscriptionTypes { get; set; }
        public ICollection<SubscriptionType> SubscriptionTypeItems { get; set; }
        public ICollection<TermType> TermTypes { get; set; }
        public ICollection<TicketMessage> UserTicketMessages { get; set; }
        public ICollection<TicketMessage> AdminTicketMessages { get; set; }

        public ICollection<AppUserClaim> AppUserClaims{ get; set; }
        public ICollection<UserFavorites> UserFavorites{ get; set; }
        public ICollection<AppUserLogin> UserLogins { get; set; }
        public ICollection<UserLogs> UserLogs { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public ICollection<UserShelves> UserShelves { get; set; }
        public ICollection<AppUserToken> UserTokens{ get; set; }
        public ICollection<WalletLog> WalletLogs{ get; set; }


    }
}
