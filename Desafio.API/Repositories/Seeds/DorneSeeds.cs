using Desafio.API.Entities;
using Desafio.API.Enuns;

namespace Desafio.API.Repositories.Seeds
{
    public static class DorneSeeds
    {
        public static List<Drone> GetSeedsDrones()
        {
            var drones = new List<Drone>
            {
    // 1-10: Status = Available
    new Drone { Id = 1,  Latitude = -30.0346m, Longitude = -51.2177m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 2,  Latitude = -29.6897m, Longitude = -53.8069m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 3,  Latitude = -31.7654m, Longitude = -52.3371m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 4,  Latitude = -29.1652m, Longitude = -51.1794m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 5,  Latitude = -30.8955m, Longitude = -55.5328m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 6,  Latitude = -27.6346m, Longitude = -52.2735m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 7,  Latitude = -29.9441m, Longitude = -51.1784m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 8,  Latitude = -30.2775m, Longitude = -57.4963m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 9,  Latitude = -28.6842m, Longitude = -50.9398m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 10, Latitude = -29.6902m, Longitude = -53.8066m, StatusDroneId = StatusDroneEnum.Available },

    // 11-20: Status = Delivering
    new Drone { Id = 11, Latitude = -30.0277m, Longitude = -51.2287m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 12, Latitude = -29.5583m, Longitude = -50.7921m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 13, Latitude = -31.0524m, Longitude = -52.3944m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 14, Latitude = -29.7477m, Longitude = -52.4112m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 15, Latitude = -30.4566m, Longitude = -54.0653m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 16, Latitude = -28.2354m, Longitude = -52.7974m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 17, Latitude = -29.7232m, Longitude = -51.2421m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 18, Latitude = -30.2023m, Longitude = -56.4502m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 19, Latitude = -28.9821m, Longitude = -50.1112m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 20, Latitude = -29.8872m, Longitude = -53.5521m, StatusDroneId = StatusDroneEnum.Delivering },

    // 21-30: Status = Unavailable
    new Drone { Id = 21, Latitude = -30.0012m, Longitude = -51.3087m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 22, Latitude = -29.5683m, Longitude = -53.1921m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 23, Latitude = -31.6224m, Longitude = -52.7544m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 24, Latitude = -29.8477m, Longitude = -52.9112m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 25, Latitude = -30.3766m, Longitude = -54.1653m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 26, Latitude = -28.5354m, Longitude = -52.1974m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 27, Latitude = -29.7232m, Longitude = -51.7421m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 28, Latitude = -30.9023m, Longitude = -56.9502m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 29, Latitude = -28.1921m, Longitude = -50.6112m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 30, Latitude = -29.5872m, Longitude = -53.9521m, StatusDroneId = StatusDroneEnum.Unavailable },

    // 31-40: Status = Available
    new Drone { Id = 31, Latitude = -30.3346m, Longitude = -51.9177m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 32, Latitude = -29.8897m, Longitude = -53.1069m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 33, Latitude = -31.1654m, Longitude = -52.8371m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 34, Latitude = -29.4652m, Longitude = -51.5794m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 35, Latitude = -30.3955m, Longitude = -55.8328m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 36, Latitude = -27.9346m, Longitude = -52.5735m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 37, Latitude = -29.8441m, Longitude = -51.6784m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 38, Latitude = -30.5775m, Longitude = -57.1963m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 39, Latitude = -28.9842m, Longitude = -50.3398m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 40, Latitude = -29.3902m, Longitude = -53.2066m, StatusDroneId = StatusDroneEnum.Available },

    // 41-50: Status = Delivering
    new Drone { Id = 41, Latitude = -30.1277m, Longitude = -51.9287m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 42, Latitude = -29.2583m, Longitude = -50.2921m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 43, Latitude = -31.6524m, Longitude = -52.9944m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 44, Latitude = -29.1477m, Longitude = -52.1112m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 45, Latitude = -30.2566m, Longitude = -54.3653m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 46, Latitude = -28.1354m, Longitude = -52.4974m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 47, Latitude = -29.3232m, Longitude = -51.4421m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 48, Latitude = -30.1023m, Longitude = -56.7502m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 49, Latitude = -28.5821m, Longitude = -50.3112m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 50, Latitude = -29.6872m, Longitude = -53.2521m, StatusDroneId = StatusDroneEnum.Delivering },

    // 51-60: Status = Unavailable
    new Drone { Id = 51, Latitude = -30.7012m, Longitude = -51.8087m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 52, Latitude = -29.0683m, Longitude = -53.9921m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 53, Latitude = -31.3224m, Longitude = -52.4544m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 54, Latitude = -29.4477m, Longitude = -52.1112m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 55, Latitude = -30.2766m, Longitude = -54.0653m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 56, Latitude = -28.9354m, Longitude = -52.6974m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 57, Latitude = -29.4232m, Longitude = -51.9421m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 58, Latitude = -30.5023m, Longitude = -56.4502m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 59, Latitude = -28.1921m, Longitude = -50.4112m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 60, Latitude = -29.8872m, Longitude = -53.6521m, StatusDroneId = StatusDroneEnum.Unavailable },

    // 61-70: Status = Available
    new Drone { Id = 61, Latitude = -30.1346m, Longitude = -51.6177m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 62, Latitude = -29.5897m, Longitude = -53.2069m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 63, Latitude = -31.9654m, Longitude = -52.1371m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 64, Latitude = -29.8652m, Longitude = -51.3794m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 65, Latitude = -30.9955m, Longitude = -55.2328m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 66, Latitude = -27.9346m, Longitude = -52.9735m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 67, Latitude = -29.1441m, Longitude = -51.4784m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 68, Latitude = -30.8775m, Longitude = -57.2963m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 69, Latitude = -28.1842m, Longitude = -50.1398m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 70, Latitude = -29.0902m, Longitude = -53.1066m, StatusDroneId = StatusDroneEnum.Available },

    // 71-80: Status = Delivering
    new Drone { Id = 71, Latitude = -30.8277m, Longitude = -51.5287m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 72, Latitude = -29.3583m, Longitude = -50.4921m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 73, Latitude = -31.8524m, Longitude = -52.1944m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 74, Latitude = -29.2477m, Longitude = -52.3112m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 75, Latitude = -30.1566m, Longitude = -54.2653m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 76, Latitude = -28.6354m, Longitude = -52.3974m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 77, Latitude = -29.8232m, Longitude = -51.1421m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 78, Latitude = -30.3023m, Longitude = -56.1502m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 79, Latitude = -28.4921m, Longitude = -50.2112m, StatusDroneId = StatusDroneEnum.Delivering },
    new Drone { Id = 80, Latitude = -29.4872m, Longitude = -53.3521m, StatusDroneId = StatusDroneEnum.Delivering },

    // 81-90: Status = Unavailable
    new Drone { Id = 81, Latitude = -30.0012m, Longitude = -51.1087m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 82, Latitude = -29.9683m, Longitude = -53.2921m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 83, Latitude = -31.8224m, Longitude = -52.5544m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 84, Latitude = -29.0477m, Longitude = -52.0112m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 85, Latitude = -30.8766m, Longitude = -54.9653m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 86, Latitude = -28.7354m, Longitude = -52.5974m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 87, Latitude = -29.6232m, Longitude = -51.8421m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 88, Latitude = -30.0023m, Longitude = -56.8502m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 89, Latitude = -28.2921m, Longitude = -50.5112m, StatusDroneId = StatusDroneEnum.Unavailable },
    new Drone { Id = 90, Latitude = -29.1872m, Longitude = -53.7521m, StatusDroneId = StatusDroneEnum.Unavailable },

    // 91-100: Status = Available
    new Drone { Id = 91, Latitude = -30.4346m, Longitude = -51.3177m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 92, Latitude = -29.2897m, Longitude = -53.4069m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 93, Latitude = -31.5654m, Longitude = -52.2371m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 94, Latitude = -29.3652m, Longitude = -51.9794m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 95, Latitude = -30.1955m, Longitude = -55.6328m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 96, Latitude = -27.5346m, Longitude = -52.9735m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 97, Latitude = -29.1441m, Longitude = -51.8784m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 98, Latitude = -30.9775m, Longitude = -57.3963m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 99, Latitude = -28.4842m, Longitude = -50.7398m, StatusDroneId = StatusDroneEnum.Available },
    new Drone { Id = 100, Latitude = -29.3902m, Longitude = -53.7066m, StatusDroneId = StatusDroneEnum.Available }
};


            return drones;
        }
    }
}
