using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ElearingEnglis.DataCon;

public class DBCon : IdentityDbContext
{
    public DBCon(DbContextOptions<DBCon> options) : base(options)
    {
    }
}
