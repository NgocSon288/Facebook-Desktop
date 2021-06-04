using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.DAO
{
    public interface IProfileDAO
    {
        List<Profile> GetAll();

        Profile GetByID(int id);

        bool SaveChanges();
    }

    public class ProfileDAO : IProfileDAO
    {
        private readonly IProfileService _profileService;

        private List<Profile> profiles;

        public ProfileDAO(IProfileService profileService)
        {
            this._profileService = profileService;

            profiles = GetAll();
        }

        public List<Profile> GetAll()
        {
            return _profileService.GetAll().ToList();
        }

        public Profile GetByID(int id)
        {
            return profiles.FirstOrDefault(p => p.ID == id);
        }

        public bool SaveChanges()
        {
            try
            {
                _profileService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
