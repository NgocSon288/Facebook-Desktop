using Facebook.Common;
using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Facebook.DAO
{
    public interface IFolderDAO
    {
        List<Folder> GetAll();

        List<Folder> GetByListID(List<int> listID);

        Folder GetByID(int id);

        Folder GetByUserID(int userID);

        bool Create(Folder folder);

        bool SaveChanges();
    }

    public class FolderDAO : IFolderDAO
    {
        private readonly IFolderService _folderService;

        public FolderDAO(IFolderService folderService)
        {
            this._folderService = folderService;
        }

        public bool Create(Folder folder)
        {
            try
            {
                // add db
                _folderService.Insert(folder);

                // save db
                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Folder> GetAll()
        {
            return _folderService.GetAll().ToList();
        }

        public Folder GetByID(int id)
        {
            return GetAll().FirstOrDefault(p => p.ID == id);
        }

        public List<Folder> GetByListID(List<int> listID)
        {
            return GetAll().Join(listID, f => f.ID, i => i, (f, i) => f).ToList();
        }

        public Folder GetByUserID(int userID)
        {
            var folder = GetAll().FirstOrDefault(f => f.UserID == userID);

            if (folder == null)
            {
                folder = new Folder()
                {
                    UserID = userID,
                    ChildrenID = "",
                    Files = "",
                    Name = Constants.UserSession.Name,
                    IsPublic = false,
                    ParentID = null,
                    ShareList = ""
                };

                _folderService.Insert(folder);

                SaveChanges();
            }

            return folder;
        }

        public bool SaveChanges()
        {
            try
            {
                _folderService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}