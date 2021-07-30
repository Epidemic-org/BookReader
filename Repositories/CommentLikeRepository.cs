<<<<<<< HEAD
﻿using BookReader.Context;
using BookReader.Data;
=======
﻿using BookReader.Data;
>>>>>>> f9083c5a95dd3fbc71b6ce5de69993c2eaa29a9b
using BookReader.Data.Models;
using BookReader.Repositories.Base;
using BookReader.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories
{
<<<<<<< HEAD
    public class CommentLikeRepository : BaseRepository<CommentLike>, ICommentLikeRepository
    {
        private readonly ApplicationDbContext _db;
        public CommentLikeRepository(ApplicationDbContext db) : base(db) {
=======
    public class CommentLikeRepository : BaseRepository<CommentLike> , ICommentLikeRepository
    {
        private readonly ApplicationDbContext _db;
        public CommentLikeRepository(ApplicationDbContext db) : base(db)
        {
>>>>>>> f9083c5a95dd3fbc71b6ce5de69993c2eaa29a9b
            _db = db;
        }
    }
}
