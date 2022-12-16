﻿
using SmartFinances.Models.Overview;

namespace SmartFinances.Interfaces
{
    public interface IOverviewService
    {
        Task<OverviewVM> GenerateOverview();
    }
}
