namespace OnlineShop.Common
{
    public interface ISlanjeEmailaService
    {
        Task EmailObavestenje(string verifikovan, string email);
    }
}
