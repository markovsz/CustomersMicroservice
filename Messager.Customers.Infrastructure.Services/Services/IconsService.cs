using Messager.Customers.Application.Services.Services;
using Messager.Customers.Domain.Core.Models;
using Messager.Customers.Domain.Interfaces;
using Messager.Customers.Infrastructure.Services.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Messager.Customers.Infrastructure.Services.Services
{
    public class IconsService : IIconsService
    {
        private IRepositoryManager _repositoryManager;
        private string _iconsPath;

        public IconsService(IRepositoryManager repositoryManager, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _iconsPath = configuration.GetSection("IconsPath").Value;
        }

        public async Task<string> GetIconAsync(Guid iconId)
        {
            var icon = await _repositoryManager.Icons.GetIconAsync(iconId);
            if (icon is null)
                new EntityDoesntExistException<Icon>();
            string iconPath = _iconsPath + iconId.ToString() + ".png";
            FileStream fS = new FileStream(iconPath, FileMode.Open, FileAccess.Read);
            byte[] iconBytes = new byte[fS.Length];
            fS.Read(iconBytes, 0, (int)fS.Length);
            fS.Close();
            string iconBase64 = Convert.ToBase64String(iconBytes);
            return iconBase64;
        }

        public async Task<Guid> PostIconAsync(string iconBase64)
        {
            Icon icon = new Icon();
            await _repositoryManager.Icons.CreateIconAsync(icon);
            await _repositoryManager.SaveAsync();
            string iconPath = _iconsPath + icon.Id.ToString() + ".png";
            File.WriteAllBytes(iconPath, Convert.FromBase64String(iconBase64));
            return icon.Id;
        }
    }
}
