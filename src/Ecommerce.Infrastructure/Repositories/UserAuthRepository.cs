using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserAuthRepository : IUserAuthRepository
{
    private readonly AppDbContext _context;

    public UserAuthRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<User?> GetUserByEmailAsync(string email, string password)
    {

    }

    public Task<bool> IsEmailTakenAsync(string email)
    {

    }

    public Task<User> RegisterUserAsync(User user)
    {

    }



}