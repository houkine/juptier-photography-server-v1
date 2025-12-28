namespace jupter_server.Services;

using AutoMapper;
using BCrypt.Net;
using jupter_server.Entities;
using jupter_server.Helpers;
using jupter_server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Linq;

public interface IThemeAlbumInfoService
{
    IEnumerable<ThemeAlbumInfo> GetAll();
    IEnumerable<ThemeAlbumInfo> GetAll(Guid GalleryThemeInfoId);
    ThemeAlbumInfo GetById(Guid id);
    ThemeAlbumInfo GetByTitle(string title);
    void Create(ThemeAlbumInfoCreateRequest model);
    void Update(ThemeAlbumInfoUpdateRequest model);
    void Delete(Guid id);
}
public class ThemeAlbumInfoService : IThemeAlbumInfoService
{
    private readonly DataContext _context;
    private readonly AppSettings _appSettings;

    private IGalleryThemeInfoService _galleryThemeInfoService;


    public ThemeAlbumInfoService(
        DataContext context,
        IOptions<AppSettings> appSettings,
        IGalleryThemeInfoService galleryThemeInfoService
    )
    {
        _context = context;
        _appSettings = appSettings.Value;
        _galleryThemeInfoService = galleryThemeInfoService;

    }

    public IEnumerable<ThemeAlbumInfo> GetAll()
    {
        return _context.ThemeAlbumInfo;
    }
    public IEnumerable<ThemeAlbumInfo> GetAll(Guid GalleryThemeInfoId)
    {
        return _context.ThemeAlbumInfo
            .Include(ta => ta.AlbumImageListInfos.OrderBy(ail => ail.sequence))
            .ThenInclude(ail => ail.AlbumImageInfos.OrderBy(ai => ai.sequence))
            .Where(ta=>ta.GalleryThemeInfoId == GalleryThemeInfoId)
            .OrderBy(ta => ta.sequence)
            ;
    }
    public ThemeAlbumInfo GetById(Guid id)
    {
        var record = _context.ThemeAlbumInfo
            .Include(ta => ta.AlbumImageListInfos.OrderBy(ail => ail.sequence))
            .ThenInclude(ail => ail.AlbumImageInfos.OrderBy(ai => ai.sequence))
            .Single(ta => ta.id==id);
        if (record==null) throw new KeyNotFoundException("Album not found");
        return record;
    }
    public ThemeAlbumInfo GetByTitle(string title)
    {
        var record = _context.ThemeAlbumInfo
            .Include(ta => ta.AlbumImageListInfos.OrderBy(ail => ail.sequence))
            .ThenInclude(ail => ail.AlbumImageInfos.OrderBy(ai => ai.sequence))
            .Single(ta => ta.title == title);
        if (record==null) throw new KeyNotFoundException("Album not found");
        return record;
    }

    public void Create (ThemeAlbumInfoCreateRequest model)
    {
        // validate
        GalleryThemeInfo galleryThemeInfo = _galleryThemeInfoService.GetById(model.GalleryThemeInfoId);

        // map model to new ThemeAlbumInfo object
        ThemeAlbumInfo record = new ThemeAlbumInfo();
        record.title = model.title;
        record.description = model.description;
        record.coverImage = model.coverImage;
        record.sequence = model.sequence;
        record.GalleryThemeInfoId = model.GalleryThemeInfoId;

        // add AlbumImageInfos
        AlbumImageListInfo[] ails = ThemeAlbumInfoService.InitAlbumImageListInfoCollection(_appSettings.AlbumListLength, record.id);
        for (int i = 0; i < _appSettings.AlbumListLength; i++)
        {
            record.AlbumImageListInfos.Add(ails[i]);
        }

        // save ThemeAlbumInfo
        galleryThemeInfo.ThemeAlbumInfos.Add(record);
        _context.SaveChanges();
    }

    public void Update(ThemeAlbumInfoUpdateRequest model)
    {
        var record = GetById(model.id);
        
        // copy model to record and save
        record.title = model.title;
        record.description = model.description;
        record.coverImage = model.coverImage;
        if (model.sequence != -1) record.sequence = model.sequence;

        _context.ThemeAlbumInfo.Update(record);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var record = _context.ThemeAlbumInfo
            .Include(ta => ta.AlbumImageListInfos)
            .ThenInclude(ail => ail.AlbumImageInfos)
            .Where(ta => ta.id == id)
            .ToArray();
        if (record.Length > 0) 
        { 
            _context.ThemeAlbumInfo.Remove(record[0]);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException("Album not found");
        }
    }

    //// helper methods
    private static AlbumImageListInfo[] InitAlbumImageListInfoCollection(int length, Guid ThemeAlbumInfoId)
    {
        AlbumImageListInfo[] result = new AlbumImageListInfo[length];
        for (int i = 0; i < length; i++)
        {
            AlbumImageListInfo ail = new AlbumImageListInfo();
            ail.sequence = i + 1;
            ail.ThemeAlbumInfoId = ThemeAlbumInfoId;
            result[i] = ail;
        }
        return result;
    }
}

