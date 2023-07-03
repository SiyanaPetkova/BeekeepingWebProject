namespace Beekeeping.Services.Services;

using Beekeeping.Data;
using Beekeeping.Data.Models;
using Beekeeping.Models.Apiary;
using Beekeeping.Services.Interfaces;
using System.Threading.Tasks;

public class ApiaryService : IApiaryService
{
    private readonly BeekeepingDbContext context;

    public ApiaryService(BeekeepingDbContext context)
    {
        this.context = context;
    }

    public async Task AddNewApiaryAsync(ApiaryFormModel model, string ownerId)
    {
        var apiary = new Apiary()
        {
            Name = model.Name,
            NumberOfHives = (int)model.NumberOfHives,
            RegistrationNumber = model.RegistrationNumber,
            Location = model.Location,
            OwnerId = ownerId
        };

        await context.Apiaries.AddAsync(apiary);
        await context.SaveChangesAsync();
    }
}
