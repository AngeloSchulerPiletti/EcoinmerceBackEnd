using Ecoinmerce.Application.Services.Token.Interfaces;
using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Objects.VOs;
using Ecoinmerce.Infra.Repository.Database.Map;
using Ecoinmerce.Infra.Repository.Interfaces;
using Ecoinmerce.Infra.Respository.Database.Context;
using Ecoinmerce.Services.WalletManager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nethereum.Web3.Accounts;

namespace Ecoinmerce.Infra.Repository.Database.Context;

public class EcommerceContext : BaseContext
{
    private readonly ITokenServiceEcommerce _tokenServiceEcommerce;
    private readonly ITokenServiceEcommerceAdmin _tokenServiceEcommerceAdmin;
    private readonly ITokenServiceEcommerceManager _tokenServiceEcommerceManager;
    private readonly IHdWalletManager _walletManager;

    public EcommerceContext(DbContextOptions<EcommerceContext> options,
                            ITokenServiceEcommerceAdmin tokenServiceEcommerceAdmin,
                            ITokenServiceEcommerceManager tokenServiceEcommerceManager,
                            ITokenServiceEcommerce tokenServiceEcommerce,
                            IHdWalletManager walletManager,
                            IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor)
    {
        _tokenServiceEcommerceAdmin = tokenServiceEcommerceAdmin;
        _tokenServiceEcommerceManager = tokenServiceEcommerceManager;
        _tokenServiceEcommerce = tokenServiceEcommerce;
        _walletManager = walletManager;
    }

    public DbSet<Ecommerce> Ecommerces { get; set; }
    public DbSet<EcommerceAdmin> EcommerceAdmins { get; set; }
    public DbSet<EcommerceManager> EcommerceManagers { get; set; }
    public DbSet<EtherWallet> EtherWallets { get; set; }
    public DbSet<ApiCredential> ApiCredentials { get; set; }

    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseCheck> PurchaseChecks { get; set; }
    public DbSet<PurchaseEvent> PurchaseEvents { get; set; }
    public DbSet<PurchaseEventFail> PurchaseEventFails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EcommerceMap());
        modelBuilder.ApplyConfiguration(new EcommerceAdminMap());
        modelBuilder.ApplyConfiguration(new EcommerceManagerMap());
        modelBuilder.ApplyConfiguration(new RoleMap());
        modelBuilder.ApplyConfiguration(new RoleBondMap());
        modelBuilder.ApplyConfiguration(new EtherWalletMap());
        modelBuilder.ApplyConfiguration(new ApiCredentialMap());

        modelBuilder.Entity<EcommerceAdmin>()
            .HasIndex(x => new { x.Username })
            .IsUnique();

        modelBuilder.Entity<EcommerceManager>()
            .HasIndex(x => new { x.Username })
            .IsUnique();

        modelBuilder.Entity<Ecommerce>()
            .HasIndex(x => new { x.Cnpj, x.Email })
            .IsUnique();

        modelBuilder.Entity<EcommerceAdmin>()
            .HasOne(a => a.Ecommerce)
            .WithMany(a => a.Admins)
            .HasForeignKey(a => a.EcommerceId);

        modelBuilder.Entity<EcommerceManager>()
            .HasOne(a => a.Ecommerce)
            .WithOne(a => a.Manager)
            .HasForeignKey<EcommerceManager>(a => a.EcommerceId);

        modelBuilder.Entity<Ecommerce>()
            .HasOne(a => a.Manager)
            .WithOne(a => a.Ecommerce)
            .HasForeignKey<Ecommerce>(a => a.ManagerId);

        modelBuilder.Entity<Ecommerce>()
            .HasMany(a => a.ApiCredentials)
            .WithOne(a => a.Ecommerce)
            .HasForeignKey(a => a.EcommerceId);

        modelBuilder.Entity<EtherWallet>()
            .HasOne(a => a.Ecommerce)
            .WithMany(x => x.EtherWallets)
            .HasForeignKey(x => x.EcommerceId);

        modelBuilder.Entity<RoleBond>()
            .HasOne(a => a.Role)
            .WithMany(a => a.RoleBonds)
            .HasForeignKey(a => a.RoleId);

        modelBuilder.Entity<RoleBond>()
            .HasOne(a => a.EcommerceAdmin)
            .WithMany(a => a.RoleBonds)
            .HasForeignKey(a => a.EcommerceAdminId);

        EcommerceEntitiesStruct angeloEcommerceEntities = FillEntities("angelopiletti@gmail.com", "Angelo", "Schuler Piletti", 1);
        modelBuilder.Entity<EtherWallet>().HasData(angeloEcommerceEntities.EtherWallet);
        modelBuilder.Entity<ApiCredential>().HasData(angeloEcommerceEntities.ApiCredential);
        modelBuilder.Entity<EcommerceAdmin>().HasData(angeloEcommerceEntities.EcommerceAdmin);
        modelBuilder.Entity<EcommerceManager>().HasData(angeloEcommerceEntities.EcommerceManager);
        modelBuilder.Entity<Ecommerce>().HasData(angeloEcommerceEntities.Ecommerce);

        EcommerceEntitiesStruct brunaEcommerceEntities = FillEntities("bruna.fusiger@gmail.com", "Bruna", "Fusiger", 2);
        modelBuilder.Entity<EtherWallet>().HasData(brunaEcommerceEntities.EtherWallet);
        modelBuilder.Entity<ApiCredential>().HasData(brunaEcommerceEntities.ApiCredential);
        modelBuilder.Entity<EcommerceAdmin>().HasData(brunaEcommerceEntities.EcommerceAdmin);
        modelBuilder.Entity<EcommerceManager>().HasData(brunaEcommerceEntities.EcommerceManager);
        modelBuilder.Entity<Ecommerce>().HasData(brunaEcommerceEntities.Ecommerce);

        EcommerceEntitiesStruct lucasEcommerceEntities = FillEntities("lucasoliveira.contatonline@gmail.com", "Lucas", "Oliveira", 3);
        modelBuilder.Entity<EtherWallet>().HasData(lucasEcommerceEntities.EtherWallet);
        modelBuilder.Entity<ApiCredential>().HasData(lucasEcommerceEntities.ApiCredential);
        modelBuilder.Entity<EcommerceAdmin>().HasData(lucasEcommerceEntities.EcommerceAdmin);
        modelBuilder.Entity<EcommerceManager>().HasData(lucasEcommerceEntities.EcommerceManager);
        modelBuilder.Entity<Ecommerce>().HasData(lucasEcommerceEntities.Ecommerce);

        modelBuilder.ApplyConfiguration(new PurchaseMap());
        modelBuilder.ApplyConfiguration(new PurchaseCheckMap());
        modelBuilder.ApplyConfiguration(new PurchaseEventMap());
        modelBuilder.ApplyConfiguration(new PurchaseEventFailMap());

        modelBuilder.Entity<Purchase>()
            .HasOne(a => a.PurchaseCheck)
            .WithOne(a => a.Purchase)
            .HasForeignKey<Purchase>(a => a.PurchaseCheckId);

        modelBuilder.Entity<Purchase>()
            .HasOne(a => a.PurchaseEvent)
            .WithOne(a => a.Purchase)
            .HasForeignKey<Purchase>(a => a.PurchaseEventId);

        modelBuilder.Entity<Purchase>()
            .HasOne(a => a.PurchaseEventFail)
            .WithOne(a => a.Purchase)
            .HasForeignKey<Purchase>(a => a.PurchaseEventFailId);

        modelBuilder.Entity<Purchase>()
            .HasOne(a => a.Ecommerce)
            .WithMany(a => a.Purchases)
            .HasForeignKey(a => a.EcommerceId);
    }

    private EcommerceEntitiesStruct FillEntities(string email,
                                                 string firstName,
                                                 string lastName,
                                                 int id)
    {
        string nakedPassword = "teste";

        EcommerceManager ecommerceManager = GetEcommerceManager(email, firstName, lastName, nakedPassword, id);
        EcommerceAdmin ecommerceAdmin = GetEcommerceAdmin(email, firstName, lastName, nakedPassword, id);
        Ecommerce ecommerce = GetEcommerce(email, id);
        ApiCredential apiCredential = GetApiCredential(ecommerce, id);
        EtherWallet etherWallet = GetEtherWallet(id);

        return (ecommerceManager, ecommerceAdmin, ecommerce, apiCredential, etherWallet);
    }

    private ApiCredential GetApiCredential(Ecommerce ecommerce, int id)
    {
        ApiCredential apiCredential = new()
        {
            Id = id,
            Description = "Esse aqui é um api credencial criado automaticamente como teste",
            Name = "TESTE Credencial",
            ValidityInDays = 20,
            CreatedAt = DateTime.Now,
            CreatedBy = "SYSTEM SEED",
            UpdatedAt = DateTime.Now,
            UpdatedBy = "SYSTEM SEED",
            EcommerceId = id,
        };
        TokenVO token = _tokenServiceEcommerce.GenerateApiToken(ecommerce, (int)apiCredential.ValidityInDays);
        apiCredential.AccessToken = token.Token;
        apiCredential.AccessTokenExpiry = token.TokenData.ValidTo;
        return apiCredential;
    }

    private EtherWallet GetEtherWallet(int id)
    {
        Account etherAccount = _walletManager.GetWalletAccount(id);

        return new EtherWallet()
        {
            Id = id,
            Name = "TEST Wallet",
            Address = etherAccount.Address,
            PrivateKey = etherAccount.PrivateKey,
            PublicKey = etherAccount.PublicKey,
            CreatedAt = DateTime.Now,
            CreatedBy = "SYSTEM SEED",
            UpdatedAt = DateTime.Now,
            UpdatedBy = "SYSTEM SEED",
            IsDeleted = false,
            EcommerceId = id,
        };
    }

    private Ecommerce GetEcommerce(string email, int id)
    {
        return new Ecommerce()
        {
            Id = id,
            AverageAnnualBilling = 10000000m,
            AverageTotalEmployees = 100,
            Cep = "93270420",
            Cnpj = "74544297000192",
            Email = email,
            FantasyName = "TEST Nome Fantasia",
            IsEmailConfirmed = true,
            Phone = "5134732749",
            SocialReason = "TEST S.A",
            Website = "https://google.com",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            IsDeleted = false,
            ConfirmationToken = null,
            ConfirmationTokenExpiry = null,
            ManagerId = id
        };
    }

    private EcommerceManager GetEcommerceManager(string email, string firstName, string lastName, string nakedPassword, int id)
    {
        EcommerceManager ecommerceManager = new()
        {
            Id = id,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            IsEmailConfirmed = true,
            Username = firstName.ToLower() + "Manager",
            Cellphone = "51982505194",
            Cpf = "05105784030",
            Phone = "5134732749",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            IsDeleted = false,
            EcommerceId = id,
        };

        _tokenServiceEcommerceManager.HashPasswordWithNewSalt(ref ecommerceManager, nakedPassword);
        TokenVO managerAccessToken = _tokenServiceEcommerceManager.GenerateAccessToken(ecommerceManager);
        ecommerceManager.SetAccessToken(managerAccessToken);
        TokenVO managerRefreshToken = _tokenServiceEcommerceManager.GenerateRefreshToken(ecommerceManager);
        ecommerceManager.SetRefreshToken(managerRefreshToken);

        return ecommerceManager;
    }

    private EcommerceAdmin GetEcommerceAdmin(string email, string firstName, string lastName, string nakedPassword, int id)
    {
        EcommerceAdmin ecommerceAdmin = new()
        {
            Id = id,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            IsEmailConfirmed = true,
            Username = firstName.ToLower() + "Admin",
            CreatedAt = DateTime.Now,
            CreatedBy = "SYSTEM SEED",
            UpdatedAt = DateTime.Now,
            UpdatedBy = "SYSTEM SEED",
            IsDeleted = false,
            EcommerceId = id
        };

        _tokenServiceEcommerceAdmin.HashPasswordWithNewSalt(ref ecommerceAdmin, nakedPassword);
        TokenVO adminAccessToken = _tokenServiceEcommerceAdmin.GenerateAccessToken(ecommerceAdmin);
        ecommerceAdmin.SetAccessToken(adminAccessToken);
        TokenVO adminRefreshToken = _tokenServiceEcommerceAdmin.GenerateRefreshToken(ecommerceAdmin);
        ecommerceAdmin.SetRefreshToken(adminRefreshToken);

        return ecommerceAdmin;
    }

    private record struct EcommerceEntitiesStruct(EcommerceManager EcommerceManager,
                                                  EcommerceAdmin EcommerceAdmin,
                                                  Ecommerce Ecommerce,
                                                  ApiCredential ApiCredential,
                                                  EtherWallet EtherWallet)
    {
        public static implicit operator (EcommerceManager ecommerceManager,
                                         EcommerceAdmin ecommerceAdmin,
                                         Ecommerce ecommerce,
                                         ApiCredential apiCredential,
                                         EtherWallet etherWallet)(EcommerceEntitiesStruct value)
        {
            return (value.EcommerceManager, value.EcommerceAdmin, value.Ecommerce, value.ApiCredential, value.EtherWallet);
        }

        public static implicit operator EcommerceEntitiesStruct((EcommerceManager ecommerceManager,
                                                                 EcommerceAdmin ecommerceAdmin,
                                                                 Ecommerce ecommerce,
                                                                 ApiCredential apiCredential,
                                                                 EtherWallet etherWallet) value)
        {
            return new EcommerceEntitiesStruct(value.ecommerceManager,
                                               value.ecommerceAdmin,
                                               value.ecommerce,
                                               value.apiCredential,
                                               value.etherWallet);
        }
    }
}