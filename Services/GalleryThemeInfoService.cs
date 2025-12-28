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

public interface IGalleryThemeInfoService
{
    IEnumerable<GalleryThemeInfo> GetAll();
    IEnumerable<GalleryThemeInfo> GetAll(Guid GalleryId);
    GalleryThemeInfo GetById(Guid id);
    GalleryThemeInfo GetByTitle(string title);
    void Create(GalleryThemeInfoCreateRequest model);
    void Update(GalleryThemeInfoUpdateRequest model);
    void Delete(Guid id);
}
public class GalleryThemeInfoService : IGalleryThemeInfoService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;

    private IGalleryService _galleryService;


    public GalleryThemeInfoService(
        DataContext context,
        IOptions<AppSettings> appSettings,
        IMapper mapper,
        IGalleryService galleryService
    )
    {
        _context = context;
        _mapper = mapper;
        _appSettings = appSettings.Value;
        _galleryService = galleryService;

    }

    public IEnumerable<GalleryThemeInfo> GetAll()
    {
        return _context.GalleryThemeInfo;
    }
    public IEnumerable<GalleryThemeInfo> GetAll(Guid GalleryId)
    {
        return _context.GalleryThemeInfo
            .Include(gt => gt.ThemeAlbumInfos.OrderBy(ta => ta.sequence))
            .Where(gt=>gt.GalleryId== GalleryId)
            .OrderBy(gt => gt.sequence)
            ;
    }
    public GalleryThemeInfo GetById(Guid id)
    {
        var record = _context.GalleryThemeInfo
            .Include(gt=> gt.ThemeAlbumInfos.OrderBy(ta=>ta.sequence))
            .Single(gt=>gt.id==id);
        if (record==null) throw new KeyNotFoundException("Theme not found");
        return record;
    }
    public GalleryThemeInfo GetByTitle(string title)
    {
        var record = _context.GalleryThemeInfo
            .Include(gt => gt.ThemeAlbumInfos.OrderBy(ta => ta.sequence))
            .Single(gt => gt.title == title);
        if (record==null) throw new KeyNotFoundException("Theme not found");
        return record;
    }

    public void Create (GalleryThemeInfoCreateRequest model)
    {
        // validate
        Gallery gallery = _galleryService.GetById(model.GalleryId);

        // map model to new GalleryThemeInfo object
        GalleryThemeInfo record = new GalleryThemeInfo();
        record.title = model.title;
        record.description = model.description;
        record.coverImage = model.coverImage;
        record.sequence = model.sequence;
        record.GalleryId = model.GalleryId;


        // save GalleryThemeInfo
        gallery.ThemeInfos.Add(record);
        _context.SaveChanges();
    }

    public void Update(GalleryThemeInfoUpdateRequest model)
    {
        var record = GetById(model.id);
        Gallery gallery = null;

        // validate
        if 
        (
            record.sequence != model.sequence &&
            _context.GalleryThemeInfo.Any(record => record.sequence == model.sequence && record.GalleryId == model.GalleryId)
        )
            throw new AppException("Theme with the sequence '" + model.sequence + "' already exists");

        if(model.GalleryId!= _appSettings.DefaultGuid && record.GalleryId!= model.GalleryId)
        {
            gallery = _galleryService.GetById(model.GalleryId);
        }

        // copy model to record and save
        record.title = model.title;
        record.description = model.description;
        record.coverImage = model.coverImage;
        if (model.sequence != -1) record.sequence = model.sequence;
        record.coverImage = model.coverImage;
        _context.GalleryThemeInfo.Update(record);

        if (gallery == null)
        {
            _context.GalleryThemeInfo.Update(record);
        }
        else
        {
            gallery.ThemeInfos.Add(record);

        }
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var record = GetById(id);
        _context.GalleryThemeInfo.Remove(record);
        _context.SaveChanges();
    }

    //// helper methods

}

