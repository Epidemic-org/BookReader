
using BookReader.Context;
using BookReader.Data;
using BookReader.Data;
using BookReader.Data.Models;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories
{

    public class CommentLikeRepository : BaseRepository<CommentLike>, ICommentLikeRepository
    {
        private readonly ApplicationDbContext _db;
        public CommentLikeRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }


        public async Task<bool> IsExists(int userId, int commentId) {
            if (await base.GetAll(c => c.UserId == userId
                    && c.CommentId == commentId).AnyAsync()) {
                return true;
            }
            return false;
        }

    }
}
