﻿using BackendGerenciamentoEquipeEmpresarial.Application.Interfaces;
using BackendGerenciamentoEquipeEmpresarial.Domain.Entities;
using BackendGerenciamentoEquipeEmpresarial.Domain.Interfaces;
using System.Threading.Tasks;

namespace BackendGerenciamentoEquipeEmpresarial.Application.Services
{
    public class TaskAppServices : ITaskAppService
    {
        private readonly ITaskAppRepository _taskAppRepository;

        public TaskAppServices(ITaskAppRepository taskAppRepository)
        {
            _taskAppRepository = taskAppRepository;
        }

        public async Task<TaskApp> Create(TaskApp task)
        {
            return await _taskAppRepository.Create(task);
        }

        public async Task<TaskApp> Update(TaskApp task)
        {
            return await _taskAppRepository.Update(task);
        }

        public async Task<bool> UpdateStatus(int idTask, int idStatus)
        {
            TaskApp task = await _taskAppRepository.GetById(idTask);
            task.StatusTask = new StatusTask() { Id = idStatus };
            await _taskAppRepository.Update(task);
            return true;
        }
    }
}
