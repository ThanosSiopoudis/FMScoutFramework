using System;

namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IContract
    {
        ContractBonus[] ContractBonuses { get; }
        ContractClause[] ContractClauses { get; }
        ContractType ContractType { get; }
        DateTime DateExpires { get; }
        DateTime DateStarted { get; }
        bool isTransferListed { get; }
        JobType JobType { get; }
        sbyte SquadNumber { get; }
        SquadStatus SquadStatus { get; }
        Team Team { get; }
        TransferStatus TransferStatus { get; }
        int Wage { get; }
    }
}