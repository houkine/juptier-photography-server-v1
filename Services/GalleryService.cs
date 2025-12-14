namespace jupter_server.Services;

using AutoMapper;
using BCrypt.Net;
using jupter_server.Helpers;
using jupter_server.Models.GalleryModel;
using jupter_server.Entities;
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
    Gallery GetByNmae(string name);
    void Create(CreateRequest model);
    void Update(UpdateRequest model);
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
        return _context.Gallery;
    }

    public Gallery GetById(Guid id)
    {
        var gallery = _context.Gallery.Find(id);
        //if (user == null) throw new KeyNotFoundException("User not found");
        return gallery;
    }
    public Gallery GetById(string name)
    {
        var gallerys = _context.Gallery
       .Where((record =>
             record.name.Equals(name)
         ))
       .ToArray();
        return gallerys[0];
    }

    public User[] Find(string email,string name,string address, string DOBstart, string DOBend, int skip, int take)
    {
        var users = _context.User
        .Where(FindUserExpression(email, name, address, DOBstart, DOBend))
        .Skip(skip)
        .Take(take)
        .ToArray();
        return users;
    }

    public int Count(string email, string name, string address, string DOBstart, string DOBend)
    {
        int resultCount = _context.User
        .Where(FindUserExpression(email, name, address, DOBstart, DOBend))
        .Count();
        return resultCount;
    }

    public void Create(CreateRequest model)
    {
        // validate
        if (_context.User.Any(x => x.email == model.email))
            throw new AppException("User with the email '" + model.email + "' already exists");

        // map model to new user object
        //var user = _mapper.Map<User>(model);
        User user = new User();
        user.email=model.email;
        user.name = model.name;
        user.dateOfBirth = model.dateOfBirth;
        user.address = model.address;

        // hash password
        user.password = BCrypt.HashPassword(model.password);

        // save user
        _context.User.Add(user);
        _context.SaveChanges();
    }
    public AuthenticateResponse Signin(AuthenticateRequest model)
    {
        // validate
        var user = _context.User.SingleOrDefault(u=>u.email ==model.email);
        if (user==null)
            throw new AppException("User with the email '" + model.email + "' does not exists");
        Console.WriteLine(user.password);
        // compare the password
        string EncryptedPassword = BCrypt.HashPassword(model.password);
        Console.WriteLine(BCrypt.Verify(model.password, user.password));
        if (BCrypt.Verify(model.password, user.password))
        {
            //success
            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }
        else
        {
            //fail
            throw new AppException("User Password incorrect with the email '" + model.email + "' ");

        }

    }

    public void Update(UpdateRequest model)
    {
        var user = GetById(model.id);

        // validate
        if (model.email != user.email && _context.User.Any(x => x.email == model.email))
            throw new AppException("User with the email '" + model.email + "' already exists");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(model.password))
            user.password = BCrypt.HashPassword(model.password);

        // copy model to user and save
        //_mapper.Map(model, user);
        //User user = new User();
        user.email = model.email;
        user.name = model.name;
        user.dateOfBirth = model.dateOfBirth;
        user.address = model.address;
        user.isValid = model.isValid;

        _context.User.Update(user);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var user = GetById(id);
        _context.User.Remove(user);
        _context.SaveChanges();
    }

    //// helper methods

    private Expression<Func<User,bool>> FindUserExpression(string email, string name, string address, string DOBstart, string DOBend)
    {
        DateTime DOBstartDT;
        DateTime DOBendDT;
        DateTime.TryParse(DOBstart, out DOBstartDT);
        DateTime.TryParse(DOBend, out DOBendDT);
        return (u =>
             u.email.Contains(email) &&
             u.name.Contains(name) &&
             u.address.Contains(address) &&
             u.dateOfBirth >= DOBstartDT &&
             u.dateOfBirth <= DOBendDT
         );
    }

    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

