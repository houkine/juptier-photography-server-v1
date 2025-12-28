namespace jupter_server.Services;

using AutoMapper;
using BCrypt.Net;
using jupter_server.Entities;
using jupter_server.Helpers;
using jupter_server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

public interface IGalleryService
{
    IEnumerable<Gallery> GetAll();
    Gallery GetById(Guid id);
    Gallery GetByName(string name);
    void Create(GalleryCreateRequest model);
    void Update(GalleryUpdateRequest model);
    void Delete(Guid id);
}
public class GalleryService : IGalleryService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly AppSettings _appSettings;


    public GalleryService(
        DataContext context,
        IOptions<AppSettings> appSettings,
        IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
        _appSettings = appSettings.Value;

    }

    public IEnumerable<Gallery> GetAll()
    {
        return _context.Gallery.Include(g => g.ThemeInfos);
    }

    public Gallery GetById(Guid id)
    {
        var record = _context.Gallery
            .Include(g=>g.ThemeInfos.OrderBy(gt=>gt.sequence))
            .ThenInclude(gt=> gt.ThemeAlbumInfos.OrderBy(ta=>ta.sequence))
            .Single(g=>g.id==id);
        if (record==null) throw new KeyNotFoundException("Gallery not found");
        return record;
    }
    public Gallery GetByName(string name)
    {
        var record = _context.Gallery
            .Include(g => g.ThemeInfos.OrderBy(gt => gt.sequence))
            .ThenInclude(gt => gt.ThemeAlbumInfos.OrderBy(ta => ta.sequence))
            .Single(g => g.name == name);
        return record;
    }

    public void Create(GalleryCreateRequest model)
    {
        // validate
        if (_context.Gallery.Any(record => record.name == model.name))
            throw new AppException("Gallery with the name '" + model.name + "' already exists");

        // map model to new gallery object
        Gallery gallery = new Gallery(model.name);
        gallery.backgroundImage = model.backgroundImage;


        // save gallery
        _context.Gallery.Add(gallery);
        _context.SaveChanges();
    }

    public void Update(GalleryUpdateRequest model)
    {
        var gallery = GetById(model.id);

        // validate
        if (model.name != gallery.name && _context.Gallery.Any(record => record.name == model.name))
            throw new AppException("Gallery with the name '" + model.name + "' already exists");


        // copy model to user and save
        //_mapper.Map(model, user);
        //User user = new User();
        gallery.name = model.name;
        gallery.backgroundImage = model.backgroundImage;
        gallery.isValid = model.isValid;

        _context.Gallery.Update(gallery);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var record = GetById(id);
        _context.Gallery.Remove(record);
        _context.SaveChanges();
    }

    //// helper methods

}

