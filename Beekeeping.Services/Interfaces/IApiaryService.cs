namespace Beekeeping.Services.Interfaces
{
    using Beekeeping.Models.Apiary;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IApiaryService
    {
        Task AddNewApiaryAsync(ApiaryFormModel model, string ownerId);
       
    }
}