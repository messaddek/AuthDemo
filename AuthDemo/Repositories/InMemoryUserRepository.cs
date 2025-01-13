using System;
using System.Collections.Concurrent;
using AuthDemo.Models;

namespace AuthDemo.Repositories;

public class InMemoryRepository : IUserRepository
{
    private readonly ConcurrentDictionary<string, User> _users = new();

    public User? GetByUsername(string username)
    {
        return _users.Values.FirstOrDefault(u => u.Username == username);
    }

    public void Add(User user)
    {
        _users.TryAdd(user.Id, user);
    }
}
