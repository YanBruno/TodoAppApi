using TodoApp.Core.Src.Entities;

namespace TodoApp.Core.Src.Repositories;

public interface ICustomerRepository
{
    Task<bool> DeleteAsync(Guid customerId);
    Task<bool> UpdateAsync(Customer customer);
    Task<bool> CreateAsync(Customer customer);
    Task<Customer> GetByIdAsync(Guid customerId);
    Task<Customer> GetByEmailAsync(string customerEmail);
    Task<Customer> GetByPhoneAsync(string customerPhone);
    Task<IEnumerable<Customer>> GetAll();
    Task<bool> CheckByEmail(string email);
    Task<bool> CheckByPhone(string phoneCodeArea, string phoneNumber);
}