using glovers_backstore.Data.Enums;

namespace glovers_backstore.Data.Models
{
    public class UnitOfWork<T> where T : class, new()
    {
        public UnitOfWork() { }
        public UnitOfWork(T data, TransactionStatus status) 
        {
            Data = data;
            Status = status;
        }
        public T Data { get; set; } = new T();
        public TransactionStatus Status { get; set; } = TransactionStatus.Unknown;
    };
}
