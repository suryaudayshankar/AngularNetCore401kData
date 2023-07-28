using AngularNetCore401kData.Models;

namespace AngularNetCore401kData.Interfaces
{
    public interface IRasCode
    {
        IEnumerable <RasSelectCode> Get( string codeValue);
    }
}
