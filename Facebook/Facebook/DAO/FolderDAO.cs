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

        Folder GetRootByUserID(int userID, bool isShareRoot = false);

        bool DeleteRange(List<Folder> folders);

        bool Create(Folder folder);

        bool CreateRange(List<Folder> folders);

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

        public bool CreateRange(List<Folder> folders)
        {
            try
            {
                // add db
                foreach (var item in folders)
                {
                    _folderService.Insert(item);
                }

                // save db
                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRange(List<Folder> folders)
        {
            try
            {
                foreach (var item in folders)
                {
                    _folderService.Delete(item);
                }

                _folderService.SaveChanges();

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

        public Folder GetRootByUserID(int userID, bool isShareRoot)
        {
            var folder = GetAll().FirstOrDefault(f => f.UserID == userID && f.ParentID == null && f.IsShareRoot == isShareRoot);

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
                    ShareList = "",
                    ColorName = "",
                    IsShareRoot = false
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