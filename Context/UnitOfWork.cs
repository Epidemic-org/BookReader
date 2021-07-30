﻿using BookReader.Context;
using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Interfaces;
using BookReader.Repositories;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BookReader.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }


        private IProductRepository _productRepository;
        public IProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_db);
                }
                return _productRepository;
            }
        }


        private IOrderRepository _orderRepository;
        public IOrderRepository Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_db);
                }
                return _orderRepository;
            }
        }



        private IInvoiceRepository _invoiceRepository;
        public IInvoiceRepository Invoice
        {
            get
            {
                if (_invoiceRepository == null)
                {
                    _invoiceRepository = new InvoiceRepository(_db);
                }
                return _invoiceRepository;
            }
        }



        private IInvoiceItemRepository _invoiceItemRepository;
        public IInvoiceItemRepository InvoiceItem
        {
            get
            {
                if (_invoiceItemRepository == null)
                {
                    _invoiceItemRepository = new InvoiceItemRepository(_db);
                }
                return _invoiceItemRepository;
            }
        }


        private IInvoiceTermRepository _invoiceTermRepository;
        public IInvoiceTermRepository InvoiceTerm
        {
            get
            {
                if (_invoiceTermRepository == null)
                {
                    _invoiceTermRepository = new InvoiceTermRepository(_db);
                }
                return _invoiceTermRepository;
            }
        }



        private IInvoicePaymentRepository _invoicePayment;
        public IInvoicePaymentRepository InvoicePayments {
            get {
                if (_invoicePayment == null) {
                    _invoicePayment = new InvoicePaymentRepository(_db);
                }
                return _invoicePayment;
            }
        }


        private ICommentRepository _commentRepository;
        public ICommentRepository Comments
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_db);
                }
                return _commentRepository;
            }
        }



        private IProductCategoryRepository _productCategories;
        public IProductCategoryRepository ProductCategories
        {
            get
            {
                if(_productCategories == null)
                {
                    _productCategories = new ProductCategoryRepository(_db);
                }
                return _productCategories;
            }
        }


        private IAppRoleRepository _appRole;
        public IAppRoleRepository AppRole {
            get
            {
                if (_productCategories == null)
                {
                    _appRole = new AppRoleRepository(_db);
                }
                return _appRole;
            }
        }


        public void Dispose() {
            _db.Dispose();
        }


        private IUserRepository _userRepository;
        public IUserRepository AppUsers {
            get {
                if (_userRepository == null) {
                    _userRepository = new UserRepository(_db);
                }
                return _userRepository;
            }
        }


        private ICommentLikeRepository _commentLike;
        public ICommentLikeRepository CommentLikes
        {
            get {
                if (_commentLike == null)
                {
                    _commentLike = new CommentLikeRepository(_db);
                }
                return _commentLike; 
            }
        }

        private IWalletLogRepository _walletLogRepository;
        public IWalletLogRepository WalletLogs {
            get {
                if (_walletLogRepository == null) {
                    _walletLogRepository = new WalletLogRepository(_db);
                }
                return _walletLogRepository;
            }
        }


        private IUserFavoriteRepository _userFavoriteRepository;
        public IUserFavoriteRepository UserFavorites {
            get {
                if (_userFavoriteRepository == null) {
                    _userFavoriteRepository = new UserFavoriteRepository(_db);
                }
                return _userFavoriteRepository;
            }
        }


        private IUserLogRepository _userLogRepository;
        public IUserLogRepository UserLogs {
            get {
                if (_userLogRepository == null) {
                    _userLogRepository = new UserLogRepository(_db);
                }
                return _userLogRepository;
            }
        }

        private ITransactionRepository _transactionRepository;
        public ITransactionRepository Transactions {
            get {
                if (_transactionRepository == null) {
                    _transactionRepository = new TransactionRepository(_db);
                }
                return _transactionRepository;
            }
        }

        private IProductVisitRepository _productVisitRepository;
        public IProductVisitRepository ProductVisits {
            get {
                if (_productVisitRepository == null) {
                    _productVisitRepository = new ProductVisitRepository(_db);
                }
                return _productVisitRepository;
            }
        }


        private IPersonRepository _personRepository;
        public IPersonRepository People {
            get {
                if (_personRepository == null) {
                    _personRepository = new PersonRepository(_db);
                }
                return _personRepository;
            }
        }

        private IProductRateRepository _productRateRepository;
        public IProductRateRepository ProductRates {
            get {
                if (_productRateRepository == null) {
                    _productRateRepository = new ProductRateRepository(_db);
                }
                return _productRateRepository;
            }
        }

        private IProductPrice _productPriceRepository;
        public IProductPrice ProductPrices {
            get {
                if (_productPriceRepository == null) {
                    _productPriceRepository = new ProductPriceRepository(_db);
                }
                return _productPriceRepository;
            }
        }



        private IProductDownloadRepository _productDownloadRepository;
        public IProductDownloadRepository ProductDownloads {
            get {
                if (_productDownloadRepository == null) {
                    _productDownloadRepository = new ProductDownloadRepository(_db);
                }
                return _productDownloadRepository;
            }
        }

        private ICreditTypeRepository _creditTypeRepository;
        public ICreditTypeRepository CreditTypes {
            get {
                if (_creditTypeRepository == null) {
                    _creditTypeRepository = new CreditTypeRepository(_db);
                }
                return _creditTypeRepository;
            }
        }
    }
}
