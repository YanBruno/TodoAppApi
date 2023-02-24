using Dapper;
using System.Data;
using TodoApp.Core.Src.Entities;
using TodoApp.Core.Src.Queries.Results;
using TodoApp.Core.Src.Repositories;
using TodoApp.Infra.Src.DataContext.Contracts;
using TodoApp.Infra.Src.Scripts.SqliteScripts;

namespace TodoApp.Infra.Src.Repositories
{
    public class CustomerRepository : DefaultConnection, ICustomerRepository
    {
        public async Task<bool> CheckByEmail(string email)
        {
            bool result = await context.Connection.QueryFirstOrDefaultAsync<bool>(
                SqliteGenericScripts.CheckEmail
                , new
                {
                    email
                }
                , commandType: CommandType.Text
            );

            return result;
        }

        public async Task<bool> CheckByPhone(string phoneCodeArea, string phoneNumber)
        {
            bool result = await context.Connection.QueryFirstOrDefaultAsync<bool>(
                SqliteGenericScripts.CheckPhone
                , new
                {
                    phoneCodeArea
                    ,
                    phoneNumber
                }
                , commandType: CommandType.Text
            );

            return result;
        }

        public async Task<bool> CreateAsync(Customer customer)
        {
            var result = await context.Connection.ExecuteAsync(
                SqliteGenericScripts.InsertCustomer
                , new
                {
                    customer.Id
                    ,
                    customer.Name.FirstName
                    ,
                    customer.Name.LastName
                    ,
                    customer.Email.Address
                    ,
                    customer.Phone.CodeArea
                    ,
                    customer.Phone.Number
                    ,
                    customer.Password.Value
                    ,
                    customer.CreateAt
                }
                , commandType: CommandType.Text
            );

            if (result == 0) return false;

            return true;
        }

        public Task<bool> DeleteAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = new List<Customer>();

            var result = await context
                .Connection
                .QueryAsync<CustomerQueryResult, TodoListQueryResult, TodoItemQueryResult, CustomerQueryResult>(
                    SqliteGenericScripts.GetCustomers
                    , (customerResult, todoListResult, todoItemResult) => {


                        var customer = customers.FirstOrDefault(c => c.Id == Guid.Parse(customerResult.usuario_id));
                        if (customer == null)
                        {
                            customer = customerResult.ToEntity();
                            if (todoListResult != null)
                            {
                                var todoList = todoListResult.ToEntity();
                                if (todoItemResult != null)
                                {
                                    var todoItem = todoItemResult.ToEntity();
                                    todoList.AddTodoItem(todoItem);
                                }
                                customer.AddTodoList(todoList);
                            }
                            customers.Add(customer);
                        }
                        else 
                        {
                            if (todoListResult != null) 
                            {
                                var todoList = customer.Lists.FirstOrDefault(l => l.Id == Guid.Parse(todoListResult.todo_lista_id));
                                if (todoList == null)
                                {
                                    todoList = todoListResult.ToEntity();
                                    if (todoItemResult != null) 
                                        todoList.AddTodoItem(todoItemResult.ToEntity());
                                    
                                    customer.AddTodoList(todoList);
                                }
                                else {
                                    if (todoItemResult != null)
                                        todoList.AddTodoItem(todoItemResult.ToEntity());
                                    
                                }
                            }
                        }

                        return customerResult;
                    }
                    , null
                    , commandType: CommandType.Text
                    , splitOn: "todo_lista_id, todo_item_id"
                );

            return customers;
        }

        public Task<Customer> GetByEmailAsync(string customerEmail)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByIdAsync(Guid customerId)
        {
            var customers = new List<Customer>();

            var result = await context
                .Connection
                .QueryAsync<CustomerQueryResult, TodoListQueryResult, TodoItemQueryResult, CustomerQueryResult>(
                    SqliteGenericScripts.GetCustomerById
                    , (customerResult, todoListResult, todoItemResult) => {

                        var customer = customers.FirstOrDefault(c => c.Id == Guid.Parse(customerResult.usuario_id));
                        if (customer == null)
                        {
                            customer = customerResult.ToEntity();
                            if (todoListResult != null)
                            {
                                var todoList = todoListResult.ToEntity();
                                if (todoItemResult != null)
                                {
                                    var todoItem = todoItemResult.ToEntity();
                                    todoList.AddTodoItem(todoItem);
                                }
                                customer.AddTodoList(todoList);
                            }
                            customers.Add(customer);
                        }
                        else
                        {
                            if (todoListResult != null)
                            {
                                var todoList = customer.Lists.FirstOrDefault(l => l.Id == Guid.Parse(todoListResult.todo_lista_id));
                                if (todoList == null)
                                {
                                    todoList = todoListResult.ToEntity();
                                    if (todoItemResult != null)
                                        todoList.AddTodoItem(todoItemResult.ToEntity());

                                    customer.AddTodoList(todoList);
                                }
                                else
                                {
                                    if (todoItemResult != null)
                                        todoList.AddTodoItem(todoItemResult.ToEntity());

                                }
                            }
                        }

                        return customerResult;
                    }
                    , new { customerId }
                    , commandType: CommandType.Text
                    , splitOn: "todo_lista_id, todo_item_id"
                );

            return customers.FirstOrDefault(c => c.Id == customerId)!;
        }

        public Task<Customer> GetByPhoneAsync(string customerPhone)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
