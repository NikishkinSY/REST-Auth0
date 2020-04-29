using DBA.Domain.Enums;

namespace DBA.Application.Services.Interfaces
{
    public interface IGeoAppService
    {
        double Distance(double lat1, double lon1, double lat2, double lon2, LenghtUnit lenghtUnit);
    }
}
