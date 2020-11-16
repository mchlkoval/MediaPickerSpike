using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPickerSpike.Interface
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}
