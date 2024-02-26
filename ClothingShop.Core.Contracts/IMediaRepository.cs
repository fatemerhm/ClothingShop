using ClothingShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Core.Contracts
{
    public interface IMediaRepository
    {
        List<Media> GetMedias();
    }
}
