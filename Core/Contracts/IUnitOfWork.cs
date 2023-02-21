namespace asp_code_base.Core.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepo User { get; }
    }
}
