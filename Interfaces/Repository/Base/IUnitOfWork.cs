﻿using Interfaces.Repository.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Interfaces.Repository.Base
{
    public interface IUnitOfWork
    {
        IInputRepository InputRepository { get; }
        IMachineRepository MachineRepository { get; }
        IInventoryMovementsRepository InventoryMovementsRepository { get; }

        IDbContextTransaction BeginTransaction();
        Task Commit();
        void Dispose();
    }
}