using Application.Entity.Entities.CommonModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Application.Service.Services.Interfaces.CommonModule
{
   public interface IVerticalService
    {
        Task<List<Vertical>> GetAllVertical(SearchVertical search);
    }
}
