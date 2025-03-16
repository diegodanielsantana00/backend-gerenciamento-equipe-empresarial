using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;
using RabbitMQ.Client;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Services
{
    public class RabbitMQService
    {
        //private readonly ITaskAppRepository _taskAppRepository;

        //public TaskService(ITaskAppRepository taskAppRepository)
        //{
        //    _taskAppRepository = taskAppRepository;
        //}

        //private readonly ConnectionFactory _factory;

        //public RabbitMQService()
        //{
        //    _factory = new ConnectionFactory()
        //    {
        //        HostName = "localhost",
        //        UserName = "guest",
        //        Password = "guest"
        //    };
        //}

        //public IConnection GetConnection()
        //{
        //    return _factory.CreateConnection();
        //}
    }
}
