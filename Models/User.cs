using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace asp_code_base.Models
{
    public class User
    {

        public Guid id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String name { get; set; }
        public String address { get; set; }

        public User()
        {
            name = String.Empty;
            address = String.Empty;
            username = String.Empty;
            password = String.Empty;
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.username).IsUnique();
            builder.Property(x => x.username).IsRequired().HasMaxLength(50);
            builder.Property(x => x.password).IsRequired().HasMaxLength(50);
            builder.Property(x => x.name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.address).HasMaxLength(100);
        }
    }
}
