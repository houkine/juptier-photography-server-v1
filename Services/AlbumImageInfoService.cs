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

public interface IAlbumImageInfoService
{
    IEnumerable<AlbumImageInfo> GetAll(Guid AlbumImageListInfoId);
    AlbumImageInfo GetById(Guid id);
    void BulkUpdate(AlbumImageInfoCreateRequest[] model, Guid ThemeAlbumInfoId);
    void Delete(Guid id);
}
public class AlbumImageInfoService : IAlbumImageInfoService
{
    private readonly DataContext _context;


    public AlbumImageInfoService(
        DataContext context
    )
    {
        _context = context;

    }

    public IEnumerable<AlbumImageInfo> GetAll(Guid AlbumImageListInfoId)
    {
        return _context.AlbumImageInfo
            .Where(ai=>ai.AlbumImageListInfoId == AlbumImageListInfoId)
            .OrderBy(ai => ai.sequence)
            ;
    }
    public AlbumImageInfo GetById(Guid id)
    {
        var record = _context.AlbumImageInfo
            .Single(ta => ta.id==id);
        if (record==null) throw new KeyNotFoundException("Image not found");
        return record;
    }


    // update all images of the album
    public void BulkUpdate(AlbumImageInfoCreateRequest[] model, Guid ThemeAlbumInfoId)
    {
        // 1 delete all old images
        AlbumImageListInfo[] albumImageListInfos = _context.AlbumImageListInfo.Where(ail => ail.ThemeAlbumInfoId == ThemeAlbumInfoId).ToArray();
        Guid[] albumImageListInfoIds = new Guid[albumImageListInfos.Length];
        for (int i = 0; i < albumImageListInfos.Length; i++)
        {
            albumImageListInfoIds[i] = albumImageListInfos[i].id;
        }
        var oldData = _context.AlbumImageInfo.Where(ai => albumImageListInfoIds.Contains(ai.AlbumImageListInfoId));
        if (oldData.Any())
        {
            _context.AlbumImageInfo.RemoveRange(oldData);
        }

        // 2 add all images
        if (model.Length < 1) return;
        AlbumImageInfo[] newData = new AlbumImageInfo[model.Length];
        for (int i = 0; i < model.Length; i++)
        {
            AlbumImageInfo record = new AlbumImageInfo();
            record.src = model[i].src;
            record.sequence = model[i].sequence;
            record.AlbumImageListInfoId = model[i].AlbumImageListInfoId;
            newData[i] = record;
        }

        // 3 save
        _context.AlbumImageInfo.AddRange(newData);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var record = _context.AlbumImageInfo.Single(ta => ta.id == id);
        if (record!=null) 
        { 
            _context.AlbumImageInfo.Remove(record);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException("Image not found");
        }
    }

    //// helper methods
    private void InitThemeAlbum(Guid ThemeAlbumInfoId)
    {
        AlbumImageListInfo[] albumImageListInfos = _context.AlbumImageListInfo.Where(ail => ail.ThemeAlbumInfoId == ThemeAlbumInfoId).ToArray();
        Guid[] albumImageListInfoIds = new Guid[albumImageListInfos.Length];
        for (int i = 0; i < albumImageListInfos.Length; i++)
        {
            albumImageListInfoIds[i] = albumImageListInfos[i].id;
        }
        AlbumImageInfo[] albumImageInfos = _context.AlbumImageInfo.Where(ai=> albumImageListInfoIds.Contains(ai.AlbumImageListInfoId)).ToArray();
        if (albumImageInfos.Any())
        {
            _context.AlbumImageInfo.RemoveRange(albumImageInfos);
            _context.SaveChanges();

        }
    }
}

