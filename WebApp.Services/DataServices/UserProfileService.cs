using WebApp.Domain.Models;

namespace WebApp.Services.DataServices
{
    public static class UserProfileService
    {
        public static async Task<List<UserProfile>> Profiles()
        {
            List<UserProfile> listOfProfiles = new List<UserProfile>();
            for (int i = 0; i < 25; i++)
            {

                UserProfile profile = new UserProfile();
                profile.Name = Faker.Name.FullName(Faker.NameFormats.WithPrefix);
                profile.Area = $"{Faker.Address.Country()} , {Faker.Address.City()}";
                profile.GovernmentId = Faker.Identification.UKNationalInsuranceNumber();
                profile.Followers = Faker.RandomNumber.Next(0, 1000);
                profile.Biography = String.Join("", Faker.Lorem.Sentences(3));
                listOfProfiles.Add(profile);
            }
            await Task.Delay(5000); // simulated delay of 5 seconds
            return listOfProfiles;
        }
    }
}
