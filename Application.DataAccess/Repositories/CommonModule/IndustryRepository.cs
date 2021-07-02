﻿using Application.DataAccess.DataContext;
using Application.DataAccess.Repositories.Interfaces.CommonModule;
using Application.Entity.Entities.CommonModule;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repositories.CommonModule
{
    public class IndustryRepository : DatabaseContext, IIndustryRepository
    {
        public IndustryRepository(AppConfiguration appConfiguration)
        : base(appConfiguration)
        { }

        public async Task<List<Industry>> GetAllIndustry(SearchIndustry search)
        {
            try
            {
                List<Industry> returnList = new List<Industry>();
                using (IDbConnection connection = base.GetConnection())
                {
                    var para = new DynamicParameters();
                    para.Add("@IndustryId", search.IndustryId);
                    para.Add("@IsActive", search.IsActive);
                    const string procName = "Usp_Industry_GetAll";
                    connection.Open();
                    returnList = connection.Query<Industry>(procName, para, commandType: CommandType.StoredProcedure).ToList();
                    return await Task.FromResult(returnList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
