using Messager.Customers.Application.Services.Services;
using Messager.Customers.Domain.Interfaces;
using Messager.Customers.Domain.Interfaces.Repositories;
using Messager.Customers.Infrastructure.Services.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Drawing;
using System.Drawing.Imaging;
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

        public async Task<Guid> PostIconAsync(byte[] imageBytes)
        {
            MemoryStream stream = new MemoryStream(imageBytes);
            Image img = Image.FromStream(stream); //only on Windows
            Domain.Core.Models.Icon icon = new Domain.Core.Models.Icon();
            await _repositoryManager.Icons.CreateIconAsync(icon);
            await _repositoryManager.SaveAsync();
            img.Save(_iconsPath + icon.Id.ToString() + ".png", ImageFormat.Png); //only on Windows
            return icon.Id;
        }
    }
}
