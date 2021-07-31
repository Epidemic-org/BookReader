using BookReader.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Context.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, AppUser user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
