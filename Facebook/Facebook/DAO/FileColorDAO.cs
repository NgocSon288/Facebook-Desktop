using Facebook.Common;
using Facebook.Helper;
using Facebook.Model.Models;
using Facebook.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Facebook.DAO
{
    public interface IFileColorDAO
    {
        List<FileColor> GetAll();

        FileColor GetByID(int id);

        FileColor GetByExtension(string extension);

        bool DeleteRange(List<FileColor> fileColors);

        bool Insert(FileColor fileColor);

        bool InsertReange(List<FileColor> fileColors);

        bool SaveChanges();
    }

    public class FileColorDAO : IFileColorDAO
    {
        private readonly IFileColorService _fileColorService;

        public FileColorDAO(IFileColorService fileColorService)
        {
            this._fileColorService = fileColorService;
        }

        public bool Insert(FileColor fileColor)
        {
            try
            {
                // add db
                _fileColorService.Insert(fileColor);

                // save db
                SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRange(List<FileColor> fileColors)
        {
            try
            {
                foreach (var item in fileColors)
                {
                    _fileColorService.Delete(item);
                }

                _fileColorService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<FileColor> GetAll()
        {
            return _fileColorService.GetAll().ToList();
        }

        public FileColor GetByExtension(string extension)
        {
            var list = _fileColorService.GetAll();
            var fc = list.FirstOrDefault(f =>
            {
                var ls = StringHelper.StringToStringList(f.Extension);

                return ls.Contains(extension);
            });

            if (fc == null)
            {
                return list.LastOrDefault();
            }
            else
            {
                return fc;
            }
        }

        public FileColor GetByID(int id)
        {
            return GetAll().FirstOrDefault(p => p.ID == id);
        }

        public bool SaveChanges()
        {
            try
            {
                _fileColorService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertReange(List<FileColor> fileColors)
        {
            try
            {
                foreach (var item in fileColors)
                {
                    _fileColorService.Insert(item);
                }

                _fileColorService.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}