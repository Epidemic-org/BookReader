using BookReader.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories.Interfaces
{
    public interface ICommentLikeRepository : IBaseRepository<CommentLike>
    {
        Task<bool> IsExists(int userId, int commentId);
    }
}
